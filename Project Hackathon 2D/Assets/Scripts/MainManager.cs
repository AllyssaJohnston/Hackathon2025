using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    private static bool readyToTransition = true;

    //make this a singleton
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    static public void ChangeStage(int number)
    {
        int newIndex = SceneManager.GetActiveScene().buildIndex + number;

        //bounds check
        if(0 > newIndex || newIndex > SceneManager.sceneCountInBuildSettings - 1)
        {
            Debug.Log("No more scenes!");
            return;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + number);
        readyToTransition = false;
    }

    static public void PreviousStage()
    {
        ChangeStage(-1);
    }

    static public void NextStage()
    {
        ChangeStage(1);
    }

    static public void ReloadStage()
    {
        ChangeStage(0);
    }

    static public void SetReadyToTransition(bool ready)
    {
        readyToTransition = ready; 
    }


    static public void AttemptToTransition(bool lastArea)
    {
        if (readyToTransition)
        {
            // If it's the last level in an area, start changing the music
            if (lastArea)
            {
                GameObject musicPlayer = GameObject.FindGameObjectWithTag("MusicPlayer");
                // Makes sure that the game doesn't crash if the DJ isn't in that scene for testing
                if (musicPlayer != null)
                {
                    // Plays the next tune in the playlist
                    musicPlayer.GetComponent<DJBehaivor>().nextTune();
                }
            }
            NextStage();
        }
    }
}
