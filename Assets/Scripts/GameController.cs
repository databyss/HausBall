using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text livesText;

    public int goalPoints;
    public int ballPoints;
    public int startingLives;

    private int score, lives;
    private EventManager em;
    

	// Use this for initialization
	void OnEnable() {
        // Demo URL: https://www.youtube.com/watch?v=ySSQEJGHbNc&feature=youtu.be&t=3105
        lives = startingLives;
        UpdateScore();
        UpdateLives();

        // subscribe to events
        EventManager.StartListening("ball_scored", this.BallScored);
        EventManager.StartListening("ball_blocked", this.BallBlocked);
        EventManager.StartListening("goal_scored", this.BallScored);
    }

    // Use for destruction
    void OnDisable()
    {
        // unsubscribe to events
        EventManager.StopListening("ball_scored", this.BallScored);
        EventManager.StopListening("ball_blocked", this.BallBlocked);
        EventManager.StopListening("goal_scored", this.BallScored);
    }

    void Update() {
        // go to end screen on ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("EndMenu");
        }
    }

    // update Score UI
    void UpdateScore() {
        // Format score with commas
        if (score > 999)
        {
            scoreText.text = "Score: " + score.ToString("0,0");
        }
        else
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // update Lives UI
    void UpdateLives() {
        livesText.text = "Lives: " + lives.ToString();
    }

    void GoalScored() {
        score += goalPoints;
        UpdateScore();
    }

    void BallBlocked() {
        score += ballPoints;
        UpdateScore();
    }

    void BallScored() {
        lives -= 1;
        UpdateLives();

        if (lives <= 0)
        {
            Application.LoadLevel("EndMenu");
        }
    }
}
