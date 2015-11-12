using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speedFactor = 2.0f;
    public float topYValue;
    public float bottomYValue;

	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            EventManager.TriggerEvent("ball_blocked");
        }
    }

	// Update is called once per frame
	void Update () {
        Vector3 thisPosition = gameObject.transform.position;

        float axisMovement = Input.GetAxis("Vertical") * Time.deltaTime * speedFactor;

        if(axisMovement != 0.0f) {
            if (axisMovement >= 0 && thisPosition.y < topYValue)
            {
                thisPosition.y += axisMovement;
            }
            if (axisMovement < 0 && thisPosition.y > bottomYValue)
            {
                thisPosition.y += axisMovement;
            }

            // make sure it stays in bounds
            thisPosition.y = Mathf.Clamp(thisPosition.y, bottomYValue, topYValue);

            gameObject.transform.position = thisPosition;
        }
	}
}
