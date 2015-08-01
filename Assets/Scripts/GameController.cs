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
    

	// Use this for initialization
	void Start () {
        // Demo URL: https://www.youtube.com/watch?v=ySSQEJGHbNc&feature=youtu.be&t=3105
        lives = startingLives;
        UpdateScore();
        UpdateLives();
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

    public void GoalScored() {
        score += goalPoints;
        UpdateScore();
    }

    public void BallBlocked() {
        score += ballPoints;
        UpdateScore();
    }

    public void BallScored() {
        lives -= 1;
        UpdateLives();

        if (lives <= 0)
        {
            Application.LoadLevel("EndMenu");
        }
    }
}
