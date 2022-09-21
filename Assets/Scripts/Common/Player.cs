using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    int _currentHealth;

    public HealthBar healthBar;

    TankController _tankController;
    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    // Update is called once per frame
    private void Start ()
    {
        _currentHealth = _maxHealth;

        healthBar.SetMaxHealth(_maxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            
            TakeDamage(1);

            
        }
        if (_currentHealth <= 0)
        {
            Kill();
        }

    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth += amount;

        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);

        healthBar.SetHealth(_currentHealth);
    }
    
    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;
        // _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        Debug.Log("Player's health: " + _currentHealth);

        



    }

    public void Kill()
    {
        gameObject.SetActive(false);
        // play particles 
        // play sound
    }

    public void addCoinPoints()
    {
        ScoreManager.instance.AddPoint();
    }

    void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        healthBar.SetHealth(_currentHealth);


    }

    private void OnTriggerEnter(Collider other) // take damage if collides with boss
    {
        if (other.CompareTag("Boss"))
        {
            TakeDamage(1);
            
        }

        if (other.CompareTag("BossBullet"))
        {
            TakeDamage(1);
        }

    }
}
