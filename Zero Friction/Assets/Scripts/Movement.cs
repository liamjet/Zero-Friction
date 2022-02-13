using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    float inputX;
    float inputY;
    bool inputBoost;
    bool inputBrake;
    private float thrustY = 2f;
    private float thrustX = 1f;
    private float boost = 4f;
    public Vector3 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        inputY = Input.GetAxisRaw("Vertical");
        bool inputBoost = Input.GetButtonDown("Boost");
        bool inputBrake = Input.GetButton("Brake");
        if (inputBoost == true)
        {
            rb.AddForce(transform.right * boost, ForceMode2D.Impulse);
        }
        if (inputBrake == true)
        {
            rb.drag = 5;
        }
        else
        {
            rb.drag = 0;
        }
        currentVelocity = rb.velocity;
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.up * thrustX * inputX);
        rb.AddForce(transform.right * thrustY * inputY);
    }
}
