
using UnityEngine;
using System;

public class GoalScoredData : EventArgs
{
    public String jugador;
}


// Observado
public class BallMovementManager : MonoBehaviour
{
    public Vector3 initialSpeed;
    public AudioClip goalSound;
    public AudioClip paddleCollisionSound;
    public AudioClip wallCollisionSound;

    private Vector3 speed;

    private event EventHandler mGoalScored;
    private bool mIsMoving = true;
    private AudioSource mAudioSource;

    private void Start()
    {
        //StartGame();
        mAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (mIsMoving)
        {
            transform.position += (speed * Time.deltaTime);
        }
    }
        
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Paddle"))
        {
            mAudioSource.clip = paddleCollisionSound;
            mAudioSource.Play();
            speed = new Vector3(
                -speed.x,
                UnityEngine.Random.Range(-10f, 10f),
                0f
            );
        }else if (collision.gameObject.CompareTag("Wall"))
        {
            mAudioSource.clip = wallCollisionSound;
            mAudioSource.Play();
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
        mAudioSource.clip = goalSound;
        mAudioSource.Play();
        mIsMoving = false;
        GoalScoredData data = new GoalScoredData();
        if (collision.gameObject.name == "LeftWall")
        {
            // Goal del Paddle2
            data.jugador = "Paddle2";
            mGoalScored?.Invoke(this, data);
        }
        else 
        {
            // Goal del Paddle1
            data.jugador = "Paddle1";
            mGoalScored?.Invoke(this, data);
        }
        
    }

    public void StartGame()
    {
        transform.position = new Vector3(0f, 0f, 0f);
        speed = initialSpeed;
        mIsMoving = true;
    }

    public void AddGoalScoredDelegate(EventHandler eventHandler)
    {
        mGoalScored += eventHandler;
    }
}
