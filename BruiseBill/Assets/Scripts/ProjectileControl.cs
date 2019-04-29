using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControl : MonoBehaviour
{
    private Transform projectileTransform;
    private float bulletSpeed = 0.7f;
    [SerializeField] HitSoundPlayer hitSoundPlayer;
    [SerializeField] UpgradeSystem upgradeSystem;

    // Start is called before the first frame update
    void Start()
    {
        projectileTransform = gameObject.transform;
        Invoke("DestroyProjectile",3.0f);
        hitSoundPlayer = (HitSoundPlayer)FindObjectOfType(typeof(HitSoundPlayer));
    }

    // Update is called once per frame
    void Update()
    {
        projectileTransform.Translate(bulletSpeed, 0.0f, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Invoke("DestroyProjectile",0.1f);
    }

    private void DestroyProjectile ()
    {
        hitSoundPlayer.PlayProjectileHitSound();
        Destroy(this.gameObject);
    }
}