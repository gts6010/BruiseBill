using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBillboarding : MonoBehaviour
{
    private Camera mainCamera;
    private Transform cameraTranform, projectileTransform;

    void Start()
    {
        mainCamera = Camera.main;
        cameraTranform = mainCamera.transform;
        projectileTransform = gameObject.transform;
        projectileTransform.LookAt(cameraTranform);
    }

    // Update is called once per frame
    void Update()
    {
        projectileTransform.LookAt(cameraTranform);
    }
}
