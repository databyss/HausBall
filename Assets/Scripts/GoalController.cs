using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

    private GameController gameController;

	// Use this for initialization
	void Start () {
        gameController = GameObject.FindObjectOfType<GameController>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // destroy the ball
            GameObject.Destroy(other.gameObject);

            gameController.BallScored();
        }
    }
}
