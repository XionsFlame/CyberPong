using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ball;

    public Starter starter;

    private BallController ballController;

    public TextMeshProUGUI ScoreLeftText;
    public TextMeshProUGUI ScoreRightText;

    private bool isStarted = false;

    private int scoreLeft = 0;
    private int scoreRight = 0;

    private Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        this.ballController = ball.GetComponent<BallController>();
        startingPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)
        {
            return;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            isStarted = true;
            starter.StartCountdown();
        }
    }

    public void ScoreGoalLeft() 
    {    
        scoreRight += 1;
        UpdateUI();
        ResetBall();
    }

    public void ScoreGoalRight() 
    { 
        scoreLeft += 1;
        UpdateUI();
        ResetBall();
    }

    private void UpdateUI()
    {
        ScoreLeftText.text = scoreLeft.ToString();
        ScoreRightText.text = scoreRight.ToString();    
    }

    private void ResetBall()
    {
        ballController.Stop();
        ball.transform.position = startingPosition;
        starter.StartCountdown();
    }

    public void StartGame()
    {
        ballController.Go();
    }
}
