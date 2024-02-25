using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public int collectibleCount;

    public int extraLifeThreshold;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCollectible(int amount)
    {
        collectibleCount += amount;

        if (collectibleCount >= extraLifeThreshold)
        {
            collectibleCount -= extraLifeThreshold;

            if (LifeController.instance != null)
            {
                LifeController.instance.AddLife();
            }
        }

        if(UIController.instance != null)
        {
            UIController.instance.UpdateCollectibles(collectibleCount);
        }
    }
}
