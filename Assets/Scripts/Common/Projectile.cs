using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] GameObject projectile; // public GameObject projectile;
    [SerializeField] float launchVelocity = 700f;
    [SerializeField] int damage;
    [SerializeField] float timeToDestroy = 3;


    public void shoot()
    {
        /*ballProjectile.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, 0));*/


        GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, launchVelocity, 0));

        Destroy(gameObject, timeToDestroy);


    }
    void Update()
    {


        
       
    }

   


}
