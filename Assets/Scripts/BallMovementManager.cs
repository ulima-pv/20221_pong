
using UnityEngine;
using System;

// Observado
public class BallMovementManager : MonoBehaviour
{
    public Vector3 initialSpeed;
    private Vector3 speed;

    private event EventHandler mGoalScored;

    private void Start()
    {
        //StartGame();
    }

    private void Update()
    {
        
        transform.position += (speed * Time.deltaTime);
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            speed = new Vector3(
                -speed.x,
                UnityEngine.Random.Range(-10f, 10f),
                0f
            );
        }else if (collision.gameObject.CompareTag("Wall"))
        {
            speed = new Vector3(
                speed.x,
                -speed.y,
                0f
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Goal!
        mGoalScored?.Invoke(this, EventArgs.Empty);
    }

    public void StartGame()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        speed = initialSpeed;
    }

    public void AddGoalScoredDelegate(EventHandler eventHandler)
    {
        mGoalScored += eventHandler;
    }
}
