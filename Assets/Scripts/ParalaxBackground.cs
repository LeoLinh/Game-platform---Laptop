using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ParalaxBackground : MonoBehaviour
{
    public static ParalaxBackground instance;

    private void Awake()
    {
        instance = this;
    }

    private Transform theCam;

    public Transform Sky, treeline;
    [Range(0f, 1f)]
    public float parallaxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        theCam = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Sky.position = new Vector3 (theCam.position.x, theCam.position.y, Sky.position.z);

        //treeline.position = new Vector3(
        //    theCam.position.x * parallaxSpeed,
        //    theCam.position.y * parallaxSpeed,
        //    treeline.position.y);
    }

    public void moveBackGround()
    {
        Sky.position = new Vector3(theCam.position.x, theCam.position.y, Sky.position.z);

        treeline.position = new Vector3(
            theCam.position.x * parallaxSpeed,
            theCam.position.y * parallaxSpeed,
            treeline.position.y);
    }
}
