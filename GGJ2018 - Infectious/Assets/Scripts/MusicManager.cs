using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] victorySounds;
    public AudioClip[] lossSounds;
    public AudioClip[] songs;

    bool hasWon = false;
    bool hasLost = false;

    AudioSource aSource;

	// Use this for initialization
	void Start ()
    {
        aSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(!hasWon && GameManager.instance.win)
        {
            hasWon = true;
            aSource.clip = victorySounds[Random.Range((int)0,(int)victorySounds.Length)];
            aSource.Stop();
            aSource.Play();
        }
        else if (!hasWon && GameManager.instance.gameOver)
        {
            hasLost = true;
            aSource.clip = lossSounds[Random.Range((int)0, (int)lossSounds.Length)];
            aSource.Stop();
            aSource.Play();
        }
        else
        {
            if(!aSource.isPlaying && !hasLost && !hasWon)
            {
                aSource.clip = songs[Random.Range((int)0, (int)songs.Length)];
                aSource.Stop();
                aSource.Play();
            }
        }
    }
}
