using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public static LifeController instance;
    private void Awake()
    {
        instance = this;
    }

    private PlayerController thePlayer;

    public float respawnDelay = 2f;

    public int currentLives = 3;

    public GameObject deathEffect, respawnEffect;

    // Start is called before the first frame update
    void Start()
    {
        thePlayer = FindFirstObjectByType<PlayerController>();

        UpdateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        //thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPosition;

       //PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxhealth);

        thePlayer.gameObject.SetActive(false);
        thePlayer.theRB.velocity = Vector2.zero;

        currentLives--;

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCo());
        }
        else
        {
            currentLives = 0;

            StartCoroutine(GameOverCo());
        }
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }

        UpdateDisplay();

        Instantiate(deathEffect, thePlayer.transform.position, deathEffect.transform.rotation);

        AudioManager.Instance.PLaySFX(11);
    }

    public IEnumerator RespawnCo()
    {
        yield return new WaitForSeconds(respawnDelay);

        thePlayer.transform.position = FindFirstObjectByType<CheckpointManager>().respawnPosition;

        PlayerHealthController.Instance.AddHealth(PlayerHealthController.Instance.maxhealth);

        thePlayer.gameObject.SetActive(true);

        Instantiate(respawnEffect, thePlayer.transform.position, Quaternion.identity);
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(respawnDelay);

        if (UIController.instance != null)
        {
            UIController.instance.ShowGameOver();
        }
    }

    public void AddLife()
    {
        currentLives++;

        UpdateDisplay();

        AudioManager.Instance.PLaySFX(8);
    }

    public void UpdateDisplay()
    {
        if (UIController.instance != null)
        {
            UIController.instance.UpdateLivesDisplay(currentLives);
        }
    }
}
