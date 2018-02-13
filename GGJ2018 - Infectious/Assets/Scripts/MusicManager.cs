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
		if(!hasWon && !hasLost && GameManager.instance.win)
        {
            hasWon = true;
            aSource.clip = victorySounds[Random.Range((int)0,(int)victorySounds.Length)-1];
            aSource.Stop();
            aSource.Play();
        }
        else if (!hasWon && !hasLost && GameManager.instance.gameOver)
        {
            hasLost = true;
            print(lossSounds.Length);
            aSource.clip = lossSounds[Random.Range((int)0, (int)lossSounds.Length-1)];
            aSource.Stop();
            aSource.Play();
        }
        else
        {
            if(!aSource.isPlaying && !hasLost && !hasWon)
            {
                aSource.clip = songs[Random.Range((int)0, (int)songs.Length-1)];
                aSource.Stop();
                aSource.Play();
            }
        }
    }
}
