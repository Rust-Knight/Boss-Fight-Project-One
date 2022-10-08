using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    [SerializeField] AudioClip _playerShoot;
    [SerializeField] GameObject projectile;
    [SerializeField] ParticleSystem _playerShootParticle = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject ballProjectile = Instantiate(projectile, transform.position,
                                                     transform.rotation);
            ballProjectile.GetComponent<Projectile>().shoot();

            PlayerShooting();
            PlayerShootingProjectile();
        }
    }

    private void PlayerShooting()
    {
        
        // audio. TODO - consider Object Pooling for preformance
        if (_playerShoot != null)
        {
            AudioHelper.PlayClip2D(_playerShoot, 1f);


        }

    }

    private void PlayerShootingProjectile()
    {
        _playerShootParticle.Play();
    }
}
