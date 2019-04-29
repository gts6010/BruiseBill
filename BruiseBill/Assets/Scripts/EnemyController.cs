using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] AudioSource ouch, death;
    private byte enemyHP = 25;
    private byte damage = 5;
    [SerializeField] RawImage enemySprite;
    [SerializeField] Texture enemyIdle, enemyHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if (enemyHP <= damage)
            {
                death.Play();
                enemySprite.texture = enemyHit;
                Invoke("DestroyEnemy", 0.30f);
            }
            else
            {
                enemyHP -= damage;
                enemySprite.texture = enemyHit;
                Invoke("BackToIdleSprite", 0.20f);
                ouch.Play();
            }
        }
    }

    void BackToIdleSprite()
    {
        enemySprite.texture = enemyIdle;
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
