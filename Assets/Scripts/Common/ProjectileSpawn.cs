using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{

    [SerializeField] GameObject projectile;
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
        }
    }
}
