using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAi : MonoBehaviour
{
    public float lookRadious = 10f;

    Transform target;
    NavMeshAgent agent;

    [SerializeField] int _bossMaxHealth = 20;
    int _bossCurrentHealth;

    public HealthBar bossHealthBar;


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
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= agent.stoppingDistance)
        {
            agent.SetDestination(target.position);
            
            FaceTarget();
        }

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

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadious);
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

}
