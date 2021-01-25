using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_MainMenu : MonoBehaviour
{
	// Start is called before the first frame update
	GameObject[] instructionObjects;
	GameObject[] mainmenuObjects;
	GameObject[] mainMenuOptions;
	public AudioSource mainMusic;
	public static bool musicMuted = false;
	void Start()
	{
		instructionObjects = GameObject.FindGameObjectsWithTag("Instructions");
		mainMenuOptions = GameObject.FindGameObjectsWithTag("OptionsMainMenu");
		mainmenuObjects    = GameObject.FindGameObjectsWithTag("mainMenuObjects");
		//Debug.Log(instructionObjects.Length);
		foreach (GameObject g in instructionObjects) {
			g.SetActive(false);
		}

		foreach (GameObject g in mainMenuOptions) {
			g.SetActive(false);
		}

		Text[] txts =  FindObjectsOfType<Text>();
		foreach (Text t in txts) {
			if (t.name.Equals("MusicLabel")) {
				t.text = "Music: On";
				t.color = Color.green;
			}
		}
	}

	public void Play() {
		mainMusic.Stop();
		SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
		SceneManager.UnloadSceneAsync(this.gameObject.scene);
	}

	public void Instructions() {
		foreach (GameObject g in mainmenuObjects) {
			g.SetActive(false);
		}

		foreach (GameObject g in instructionObjects) {
			g.SetActive(true);
		}
	}

	public void InstructionsBack() {
		foreach (GameObject g in instructionObjects) {
			g.SetActive(false);
		}
		
		foreach (GameObject g in mainmenuObjects) {
			g.SetActive(true);
		}
	}

	public void Options() {
		foreach (GameObject g in mainmenuObjects) {
			g.SetActive(false);
		}

		foreach (GameObject g in mainMenuOptions) {
			g.SetActive(true);
		}
	}

	public void OptionsBack() {
		foreach (GameObject g in mainMenuOptions) {
			g.SetActive(false);
		}

		foreach (GameObject g in mainmenuObjects) {
			g.SetActive(true);
		}
	}

	public void ToggleMusic() {
		UIManager_MainMenu.musicMuted = !UIManager_MainMenu.musicMuted;
		FindObjectOfType<AudioSource>().mute = UIManager_MainMenu.musicMuted;
		if (UIManager_MainMenu.musicMuted) {
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

	public void Quit() {
		Application.Quit(0);
	}
}
