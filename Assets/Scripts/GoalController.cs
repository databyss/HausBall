using UnityEngine;

public class GoalController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // destroy the ball
            GameObject.Destroy(other.gameObject);

            EventManager.TriggerEvent("ball_scored");
        }
    }
}
