using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectileSpawnPoint : MonoBehaviour
{

    [SerializeField] GameObject Bossprojectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shotPlayer ()
    {
        GameObject ballProjectile = Instantiate(Bossprojectile, transform.position,
                                                    transform.rotation);
        ballProjectile.GetComponent<Projectile>().shoot();
    }

}
