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
        yield return new WaitForSeconds(waitToEngLevel);

        SceneManager.LoadScene(nextLevel);
    }
}
