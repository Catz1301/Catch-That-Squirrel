using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
	public AudioClip[] audios;
	public AudioSource audioSource;
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		if (audioSource.isPlaying == false) {
			int trackNum = Random.Range(0, audios.Length);
			Debug.Log("Track Number: " + trackNum + ";");
			Debug.Log("Track Name: " + audios[trackNum].name);
			audioSource.clip = audios[Random.Range(0, audios.Length)];
			audioSource.Play();
		}
	}
}
