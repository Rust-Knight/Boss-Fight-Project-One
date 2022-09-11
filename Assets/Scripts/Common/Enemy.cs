using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent( typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmount = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound = null;
    
    Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            PlayerImpact(player);
            ImpactFeedback();
        }

        
    }
    protected virtual void PlayerImpact(Player player) // when emeny collider is touched by another dynmaic collider check for player script if does regesiter hit. 
    { // The term virtual lets the derived class or classes change the function, if they want. 

        //protected: Allow a member item to only be accessed from internal or derived source.

        //private: Allow a member item to only be accessed from its owner.

        player.DecreaseHealth(_damageAmount);
    }

    private void ImpactFeedback()
    {
        // particles 
        if (_impactParticles != null)
        {
            _impactParticles = Instantiate(_impactParticles,
                transform.position, Quaternion.identity);
        }

        // audio. TODO - consider Object pooling for Performance 
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {

    }





}
