using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float acceleration = 5f;
    [SerializeField] private float maxSpeed = 10f;
    private Rigidbody2D rb;
    public bool IsStartRun = false;

    private void Start()
    {
        // Get the Rigidbody2D component attached to the car
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Increase the velocity of the car along the x-axis when the "Accelerate" action is triggered
        if (IsStartRun) // You can change this to any input you prefer
        {
            Accelerate();
        }
    }

    private void Accelerate()
    {
        // Get the current velocity
        Vector2 currentVelocity = rb.velocity;

        // Increase the x component of the velocity (acceleration)
        currentVelocity.x += acceleration * Time.deltaTime;

        // Update the Rigidbody2D velocity with the new value
        rb.velocity = currentVelocity;
    }
}
