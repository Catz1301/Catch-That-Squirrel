using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class UIManager : MonoBehaviour
{

    GameObject[] pauseObjects;
    GameObject[] optionPause;
    private bool isPaused = false;
    public static bool musicMuted = false;
    private bool showingOptionSubMenu = false;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("showOnPause");
        optionPause = GameObject.FindGameObjectsWithTag("showOnPauseSub");
        //Debug.Log(pauseObjects.Length);
        Text[] txts =  FindObjectsOfType<Text>();
        foreach (Text t in txts) {
            if (t.name.Equals("MusicLabel")) {
                t.text = "Music: On";
                t.color = Color.green;
            }
        }
        hidePaused();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                showPaused();
			} else {
                hidePaused();
			}
        }
    }

    public void showPaused() {
        isPaused = true;
        Time.timeScale = 0;
        foreach (GameObject g in pauseObjects) {
            g.SetActive(true);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void hidePaused() {
        Time.timeScale = 1;
        foreach (GameObject g in pauseObjects) {
            g.SetActive(false);
        }
        foreach (GameObject g in optionPause) {
            g.SetActive(false);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    public void Resume() {
        //Time.timeScale = 1;
        hidePaused();
    }

    public void Restart() {
        Debug.Log("Restart Clicked");
        int GameScene = 0;
        int totalScenes = SceneManager.sceneCount;
        for (int i = 0; i < totalScenes; i++) {
            if (SceneManager.GetSceneAt(i).name.Contains("Sample")) {
                GameScene = SceneManager.GetSceneAt(i).buildIndex;
            }
        }
        SceneManager.LoadScene(GameScene);
    }

    public void MainMenu() {
        //int MainMenuScene = 0;
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void Options() {
        foreach (GameObject g in pauseObjects) {
            g.SetActive(false);
        }
        foreach (GameObject g in optionPause) {
            g.SetActive(true);
        }
    }

    public void ToggleMusic() {
        UIManager.musicMuted = !UIManager.musicMuted;
        FindObjectOfType<AudioSource>().mute = UIManager.musicMuted;
        if (UIManager.musicMuted) {
            Text[] txts =  FindObjectsOfType<Text>();
            foreach (Text t in txts) {
                if (t.name.Equals("MusicLabel")) {
                    t.text = "Music: Off";
                    t.color = Color.red;
				}
			}
        } else {
            Text[] txts =  FindObjectsOfType<Text>();
            foreach (Text t in txts) {
                if (t.name.Equals("MusicLabel")) {
                    t.text = "Music: On";
                    t.color = Color.green;
                }
            }
        }
	}

    public void SubMenuBack() {
        foreach (GameObject g in pauseObjects) {
            g.SetActive(true);
        }
        foreach (GameObject g in optionPause) {
            g.SetActive(false);
        }
    }
}
