using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSoundPlayer : MonoBehaviour
{
    private AudioSource projectileHitSound;

    void Start()
    {
        projectileHitSound = GetComponent<AudioSource>();
    }

    public void PlayProjectileHitSound()
    {
        projectileHitSound.Play();
    }
}
