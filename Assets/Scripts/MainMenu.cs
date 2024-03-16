using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel;

    public int startingLives = 3, startingfruit = 0;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMenuMusic();

        if (PlayerPrefs.HasKey("currentLevel"))
        {
            continueButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.Instance.PlayLevelMusic(1);
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.DeleteAll();
        }
#endif
    }

    public void StartGame()
    {
        InfoTracker.Instance.currentLives = startingLives;
        InfoTracker.Instance.currentFruit = startingfruit;

        InfoTracker.Instance.SaveInfo();

        SceneManager.LoadScene(firstLevel);
    }

    public void QuitGame()
    {
        Application.Quit();

        Debug.Log("I quit");
    }

    public void Continue()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("currentLevel"));
    }
}
