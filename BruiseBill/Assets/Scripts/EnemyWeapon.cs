using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWeapon : MonoBehaviour
{

    [Range(0.0f, 3.0f)] public float firingrate = 0.7f;
    private float firingtimer = 0.0f;
    [SerializeField] GameObject energyShotPrefab;
    [SerializeField] AudioSource weaponSound;
    private Transform weaponTipTransform;
    private Camera mainCamera;
    private Vector3 playerDistance;
    [SerializeField] RawImage enemySprite;
    [SerializeField] Texture enemyIdle, enemyShooting;

    void Start()
    {
        firingtimer = Time.timeSinceLevelLoad;
        weaponTipTransform = gameObject.transform;
        mainCamera = Camera.main;
        enemySprite.texture = enemyIdle;
    }

    void Update()
    {
        if ((Time.timeSinceLevelLoad - firingtimer > firingrate))
        {
            playerDistance = mainCamera.transform.position - gameObject.transform.position;
            if (playerDistance.magnitude < 25.0f)
            {
                enemySprite.texture = enemyShooting;
                Instantiate(energyShotPrefab, weaponTipTransform.position, weaponTipTransform.rotation);
                weaponSound.Play();
                firingtimer = Time.timeSinceLevelLoad;
                Invoke("BackToIdleSprite", 0.3f);
            }
        }
    }

    void BackToIdleSprite()
    {
        enemySprite.texture = enemyIdle;
    }
}
