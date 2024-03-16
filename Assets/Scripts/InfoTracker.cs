using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoTracker : MonoBehaviour
{
    public static InfoTracker Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);

            if (PlayerPrefs.HasKey("Lives"))
            {
                currentLives = PlayerPrefs.GetInt("Lives");
                currentFruit = PlayerPrefs.GetInt("fruit");
            }           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int currentLives, currentFruit;

    public void GetInfo()
    {
        if (LifeController.instance != null)
        {
            currentLives = LifeController.instance.currentLives;
        }

        if (CollectibleManager.Instance != null)
        {
            currentFruit = CollectibleManager.Instance.collectibleCount;
        }
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetInt("Lives", currentLives);
        PlayerPrefs.SetInt("fruit", currentFruit);
    }
}
