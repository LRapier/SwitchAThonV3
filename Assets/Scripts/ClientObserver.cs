using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClientObserver : MonoBehaviour
{
    private PlayerMovement _player;
    public GameObject explode;
    private bool exploded;
    public Text distanceText;
    public GameManager gameManager;

    void Start()
    {
        _player =
            (PlayerMovement)
            FindObjectOfType(typeof(PlayerMovement));
        exploded = false;
    }

    void Update()
    {
        if (int.Parse(distanceText.text) >= 275 && _player.enabled)
        {
            exploded = true;
            _player.enabled = false;
            gameManager.CompleteLevel();
            Invoke("LoadNextLevel", 3f);
        }

        if (Input.GetKeyDown("space"))
        {
            _player.PolarityParticles();
        }

        if(!_player.enabled && exploded == false)
        {
            explode.SetActive(true);
            Invoke("StopExplode", 1.65f);
        }
    }

    void StopExplode()
    {
        explode.SetActive(false);
        exploded = true;
        Invoke("ResetExplode", .25f);
    }

    void ResetExplode()
    {
        exploded = false;
    }

    void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
