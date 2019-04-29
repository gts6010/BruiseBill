using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade_Generic : MonoBehaviour
{
    private Transform upgradeTransform;

    void Start()
    {
        upgradeTransform = gameObject.transform;
    }

    void Update()
    {
        upgradeTransform.Translate(0.0f,Mathf.Sin(Time.timeSinceLevelLoad)*0.005f,0.0f);
    }
}
