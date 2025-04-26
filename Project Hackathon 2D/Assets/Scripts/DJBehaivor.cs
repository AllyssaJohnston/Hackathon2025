using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJBehaivor : MonoBehaviour
{
    // Store itself so that it doesn't create duplicates
    private static DJBehaivor dJInstance;


    // Stores our music files
    List<AudioClip> playList = new List<AudioClip>();

    // The main audio source
    AudioSource aS;

    // Where we are pulling from in the playlist
    int tune;

    // Put all the music into a list, then start playing the menu theme
    private void Awake()
    {
        // If we haven't created a dJInstance yet, store itself and continue...
        // Otherwise, delete ourselves so we don't create duplicates
        if (dJInstance == null)
        {
            dJInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Makes sure the DJ isn't destroyed between scenes
        DontDestroyOnLoad(transform.gameObject);

        playList.Add((AudioClip) Resources.Load("Music/INeedSomeHelp"));
        playList.Add((AudioClip)Resources.Load("Music/CityNeedsSomeHelp"));
        playList.Add((AudioClip)Resources.Load("Music/ParkNeedsSomeHelp"));
        playList.Add((AudioClip)Resources.Load("Music/BeachNeedsSomeHelp"));
        aS = gameObject.GetComponent<AudioSource>();
        tune = 0;
        aS.clip = playList[tune];
        aS.Play();
    }

    // Increment to the next area theme
    public void nextTune()
    {
        tune++;
        if (tune >= playList.Count)
        {
            StartCoroutine(startTune(false));
        }
        else
        {
            resetTune();
        }
    }

    // If we want to reset back to the main menu
    public void resetTune()
    {
        tune = 0;
        StartCoroutine(startTune(false));
    }

    // If there aren't any tunes left, disable the music
    public void stopTune()
    {
        StartCoroutine(startTune(true));
    }

    // Fade out music, start the next tune, fade back in
    IEnumerator startTune(bool stopingTune)
    {
        // Fade out if something is playing
        if (aS.isPlaying)
        {
            for (int i = 0; i < 5; i++)
            {
                aS.volume -= 0.04f;
                yield return new WaitForSeconds(0.05f);
            }
            aS.Stop();
            yield return new WaitForSeconds(0.25f);
        }
        // Fade in unless we are trying to stop a tune
        if (!stopingTune)
        {
            aS.clip = playList[tune];
            aS.Play();
            for (int i = 0; i < 10; i++)
            {
                aS.volume += 0.02f;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
