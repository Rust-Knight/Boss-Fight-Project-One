using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float bossVelocity = 10f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calculateNewMovementVector();
    }

    void calculateNewMovementVector()
    {
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;

        movementPerSecond = movementDirection * bossVelocity;
    }


    void Update()
    {
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calculateNewMovementVector();
        }

        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime), transform.position.y + (movementPerSecond.y * Time.deltaTime));
    }
}
