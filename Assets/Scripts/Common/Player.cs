using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] AudioClip _playerTakingDamage;
    [SerializeField] ParticleSystem _playerTakingDamageParticle = null;
    [SerializeField] AudioClip _playerDeath;

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
        PlayerDeath();
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
            PlayerTakingDamage();
        }

        if (other.CompareTag("BossBullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
            PlayerTakingDamage();
            PlayerTakingDamageParticle();

        }

    }

    private void PlayerTakingDamage()
    {

        if (_playerTakingDamage != null)
        {
            AudioHelper.PlayClip2D(_playerTakingDamage, 1f);
        }

    }

    private void PlayerTakingDamageParticle()
    {
        _playerTakingDamageParticle.Play();
    }

    private void PlayerDeath()
    {
        if (_playerTakingDamage != null)
        {
            AudioHelper.PlayClip2D(_playerDeath, 1f);
        }
    }

}
