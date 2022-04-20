
using UnityEngine;
using UnityEngine.UI;
using System;

// Observador
public class GameManager : MonoBehaviour
{
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject ball;
    public Text tituloUI;
    public Text mensajeUI;

    private bool mRunning = false;
    private BallMovementManager mBallMovementManager;

    private void Start()
    {
        mBallMovementManager = ball.GetComponent<BallMovementManager>();
        mBallMovementManager.AddGoalScoredDelegate(OnGoalScoredDelegate);
    }

    private void Update()
    {
        if (!mRunning && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        ball.SetActive(true);
        mBallMovementManager.StartGame();
        tituloUI.gameObject.SetActive(false);
        mensajeUI.gameObject.SetActive(false);
        mRunning = true;
    }

    public void OnGoalScoredDelegate(object sender, EventArgs e)
    {
        Debug.Log("Goal");
        mRunning = false;
    }
}
