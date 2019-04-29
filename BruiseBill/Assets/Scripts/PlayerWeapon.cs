using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    [Range(0.0f, 3.0f)] public float firingrate = 0.5f;
    private float firingtimer = 0.0f;
    [SerializeField] GameObject energyShotPrefab;
    [SerializeField] AudioSource weaponSound;
    private Transform weaponTipTransform;

    void Start()
    {
        firingtimer = Time.timeSinceLevelLoad;
        weaponTipTransform = gameObject.transform;
    }

    void Update()
    {
        if ((Input.GetAxis("Fire1") > 0.0f) && (Time.timeSinceLevelLoad - firingtimer > firingrate))
        {
            Instantiate(energyShotPrefab, weaponTipTransform.position, weaponTipTransform.rotation);
            weaponSound.Play();
            firingtimer = Time.timeSinceLevelLoad;
        }
    }
}
