using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float minVelocity;
    public float maxVelocity;

    public float topY, bottomY, leftX, rightX;

    private Rigidbody2D rbody;
    private float velocityRange;

    // Initialize Ball on creation
    void Start()
    {
        velocityRange = maxVelocity - minVelocity;
        rbody = gameObject.GetComponent<Rigidbody2D>();

        moveBall();
    }

    void Update()
    {
        // ensure it's always moving somewhere left and right
        if (rbody.velocity.x >= -0.01f && rbody.velocity.x <= 0.01f)
        {
            rbody.velocity = new Vector2(0.1f, rbody.velocity.y);
        }
    }

    // set initial velocity
    void moveBall()
    {
        Vector2 newVelocity = new Vector2(((Random.value * velocityRange) + minVelocity), 0.0f);
        newVelocity = Rotate(newVelocity, ((Random.value * 160.0f) - 80.0f));
        rbody.velocity = newVelocity;
    }

    // Helper function to rotate a 2d vector
    static Vector2 Rotate(Vector2 v, float degrees)
    {
        float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;
        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);
        return v;
    }

}
