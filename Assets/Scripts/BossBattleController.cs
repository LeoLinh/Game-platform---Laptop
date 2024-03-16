using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossBattleController : MonoBehaviour
{
    private bool bossActive;

    public GameObject blocker;

    public Transform camPoint;
    private CameraController camController;
    public float cameraMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        camController = FindAnyObjectByType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (bossActive == true)
        {
            camController.transform.position = Vector3.MoveTowards(camController.transform.position,
                camPoint.position,
                cameraMoveSpeed * Time.deltaTime);
        }
    }

    public void ActivateBattle()
    {
        bossActive = true;

        blocker.SetActive(true);

        camController.enabled = false;
    }
}
