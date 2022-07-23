using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Visuals")]
    public Camera playerCamera;
    
    [Header("Gameplay")]
    public int initialAmmo = 12;
    public int initialHealth = 100;
    public float knockbackForce = 10;
    public float hurtDuration = 0.5f;
    public AudioSource hurtSound;
    public AudioSource deathSound;
    public AudioSource music;

    private int ammo;
    public int Ammo
    {
        get { return ammo; }
    }

    private int health;
    public int Health { get { return health; } }

    private bool killed;
    public bool Killed { get { return killed; } }

    private bool isHurt;
    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
        ammo = initialAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        music.Play();
        if (Input.GetMouseButtonDown(0))
        {
            if (ammo > 0 && Killed == false)
            {
                ammo--;
                GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet(true);
                bulletObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward;
                bulletObject.transform.forward = playerCamera.transform.forward;

            }
        }
    }
    //Check for collisions
    void OnTriggerEnter(Collider otherCollider)
    {
        //Collect ammo crate.
        if(otherCollider.GetComponent<AmmoCrate>() != null)
        {
            AmmoCrate ammoCrate = otherCollider.GetComponent<AmmoCrate>();
            ammo += ammoCrate.ammo;
            Destroy(ammoCrate.gameObject);
        }
        else if (otherCollider.GetComponent<HealthCrate>() != null)
        {
            HealthCrate healthCrate = otherCollider.GetComponent<HealthCrate>();
            health += healthCrate.health;
            Destroy(healthCrate.gameObject);
        }

        //Enemy Collider
        if (isHurt == false)
        {
            GameObject hazard = null;
            if(otherCollider.GetComponent<Enemy>() != null)
          {
             Enemy enemy = otherCollider.GetComponent<Enemy>();
                if (enemy.Killed == false)
                {
                    health -= enemy.damage;
                    hazard = enemy.gameObject;
                }
                
            }
            else if(otherCollider.GetComponent<Bullet>() != null)
            {
                Bullet bullet = otherCollider.GetComponent<Bullet>();
                if(bullet.ShotByPlayer == false)
                {
                    hazard = bullet.gameObject;
                    health -= bullet.damage;
                    bullet.gameObject.SetActive(false);
                }
            }
            if(hazard != null)
            {
                isHurt = true;
                hurtSound.Play();
                //Perform the Knockback Effect.
                Vector3 hurtDirection = (transform.position -hazard.transform.position).normalized;
                Vector3 knockbackDirection = (hurtDirection + Vector3.up).normalized;
                GetComponent<ForceReceiver>().AddForce(knockbackDirection, knockbackForce);
                StartCoroutine(HurtRoutine());
            }
            if(health <= 0)
            {
                if(killed == false)
                {
                    killed = true;
                    OnKill();
                }
            }
        }
    }
    IEnumerator HurtRoutine()
    {
        yield return new WaitForSeconds(hurtDuration);
        isHurt = false;
    }
    private void OnKill()
    {
        music.Pause();
        deathSound.Play();
        GetComponent<CharacterController>().enabled = false;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
    }
}
