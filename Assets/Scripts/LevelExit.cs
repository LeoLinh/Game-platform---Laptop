using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public Animator anim;

    private bool isEnding;

    public string nextLevel;

    public float waitToEngLevel = 2f;

    public GameObject blocker;

    public float fadeTime = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEnding == false)
        {
            if (other.CompareTag("Player"))
            {
                isEnding = true;

                anim.SetTrigger("ended");

                AudioManager.Instance.PlayLevelCompeleteMusic();

                blocker.SetActive(true);

                StartCoroutine(EndLevelCo());
            }
        }
        
    }

    IEnumerator EndLevelCo()
    {
        yield return new WaitForSeconds(waitToEngLevel - fadeTime);

        UIController.instance.FadeToBlack();

        yield return new WaitForSeconds(fadeTime);

        InfoTracker.Instance.GetInfo();
        InfoTracker.Instance.SaveInfo();

        PlayerPrefs.SetString("currentLevel", nextLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
