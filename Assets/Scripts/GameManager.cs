using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject completeLevelUI;
    public InputHandler inputHandler;
    public float restartDelay = 3f;

    public void GameOver()
    {
        Debug.Log(gameHasEnded);
        if (!gameHasEnded)
        {
            if (inputHandler._isRecording)
            {
                inputHandler.StopRecording();
                inputHandler.Invoke("StartReplay", restartDelay);
            }
            else if (inputHandler._isReplaying)
            {
                gameHasEnded = true;
                inputHandler.StopReplay();
                Invoke("Restart", restartDelay);
            }
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void CompleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }
}
