using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public AudioSource deathSound;
    public float shootingInterval = 4f;
    public float shootingDistance = 3f;
    private Player player;
    private float shootingTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        shootingTimer = Random.Range(0, shootingInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Killed == true)
        {
            this.enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }
        shootingTimer -= Time.deltaTime;
        if(shootingTimer <= 0 && Vector3.Distance(transform.position,player.transform.position) <= shootingDistance)
        {
            shootingTimer = shootingInterval;
            GameObject bullet = ObjectPoolingManager.Instance.GetBullet(false);
            bullet.transform.position = transform.position;
            bullet.transform.forward = (player.transform.position - transform.position).normalized;
        }
    }
    protected override void OnKill()
    {
        base.OnKill();
        deathSound.Play();
        this.enabled = false;
        transform.localEulerAngles = new Vector3(10, transform.localEulerAngles.y, transform.localEulerAngles.z);
    }
}
