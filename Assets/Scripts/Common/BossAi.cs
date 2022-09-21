using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAi : MonoBehaviour
{

    public BossProjectileSpawnPoint bossPSP1, bossPSP2, bossPSP3, bossPSP4, bossPSP5;

    public float lookRadious = 10f;

    public NavMeshAgent agent;
    public Transform target;
    public LayerMask whatIsGround, whatIsPlayer;

   


    [SerializeField] int _bossMaxHealth = 20;
    int _bossCurrentHealth;

    public HealthBar bossHealthBar;

    public float timeBetweenAttacks; // attacking
    bool alreadyAttacked;
    public GameObject projectile; // attacking


    // States
    public float sightRange, attackRange; // added
    public bool playerInSightRange, playerInAttckRange; //added 



    private void Awake() // added
    {
        target = GameObject.Find("Tank").transform; 
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        target = PlayerManager.instacne.player.transform;
        agent = GetComponent<NavMeshAgent>();

        _bossCurrentHealth = _bossMaxHealth;
        
        bossHealthBar.SetMaxHealth(_bossMaxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttckRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttckRange && playerInSightRange) AttackPlayer(); 

        

        if (_bossCurrentHealth <= 0)
        {
            bossKill();
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    public void DecreaseHealth(int amount)
    {
        _bossCurrentHealth -= amount;
        Debug.Log("Boss health: " + _bossCurrentHealth);



    }

    void TakeDamage(int damage)
    {
        _bossCurrentHealth -= damage;

        bossHealthBar.SetHealth(_bossCurrentHealth);


    }
    public void bossKill()
    {
        gameObject.SetActive(false);
        // play particles 
        // play sound
    }
    

    private void OnTriggerEnter(Collider other) // take damage and destroy porjectile
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }

      

    }
    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);

        // make sure enemy does not move

        if (!alreadyAttacked)
        {

            /*Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);

            */


            /*GameObject ballProjectile = Instantiate(projectile, transform.position,
                                                transform.rotation);
            ballProjectile.GetComponent<Projectile>().shoot();
            */

            bossPSP1.shotPlayer();
            bossPSP2.shotPlayer();
            bossPSP3.shotPlayer();
            bossPSP4.shotPlayer();
            bossPSP5.shotPlayer();


            // attack code here 

            alreadyAttacked = true;
            Invoke(nameof(RestAttack), timeBetweenAttacks);
        }
    }

  

    private void RestAttack()
    {
        alreadyAttacked = false;
    }
}
