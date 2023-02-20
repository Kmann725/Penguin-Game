using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public interface ISlideable
{
    bool IsPlayerSliding { get; }
    /// <summary>
    /// Handles Player Movement.
    /// </summary>
    /// <param name="rb"></param>
    /// <param name="grounded"></param>
    /// <param name="speed"></param>
    /// <param name="slidingSpeed"></param>
    /// <param name="jump"></param>
    /// <param name="isJumping"></param>
    /// <param name="xMovement"></param>
    /// <param name="zMovement"></param>
    /// <returns>Bool of IsJumping (set back to false).</returns>
    bool slide(Rigidbody rb, bool grounded, float speed, float slidingSpeed, float jump, bool isJumping, float xMovement, float zMovement);
}

class IsSliding : ISlideable
{
    public bool IsPlayerSliding { get => true; }
    public bool slide(Rigidbody rb, bool grounded, float speed, float slidingSpeed, float jump, bool isJumping, float xMovement, float zMovement)
    {
        if (xMovement != 0 && grounded)
        {
            //rb.AddForce(rb.transform.right * (xMovement * speed * Time.deltaTime), ForceMode.Impulse);
            rb.AddForce(rb.transform.right * (xMovement * slidingSpeed), ForceMode.Force);
        }

        if (zMovement != 0 && grounded)
        {
            //rb.AddForce(rb.transform.forward * (zMovement * speed * Time.deltaTime), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (zMovement * slidingSpeed), ForceMode.Force);
        }

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jump);
            isJumping = false;
            PlayerController.ThisPlayerController.SetSlideMode(new NotSliding());
            PlayerController.ThisPlayerController.NotifyPlayerObservers();
        }

        return isJumping;
    }
}

class NotSliding : ISlideable
{
    public bool IsPlayerSliding { get => false; }
    public bool slide(Rigidbody rb, bool grounded, float speed, float slidingSpeed, float jump, bool isJumping, float xMovement, float zMovement)
    {
        Vector3 velocity = Vector3.zero;
        //Enter non sliding movement
        if (grounded)
        {
            if (xMovement != 0)
            {
                velocity += rb.transform.right * xMovement;
                //velocity = (rb.transform.right * xMovement + rb.transform.forward * zMovement).normalized * speed;
            }

            if (zMovement != 0)
            {
                velocity += rb.transform.forward * zMovement;
            }
            velocity = velocity.normalized * speed;
            velocity.y = rb.velocity.y;
        }
        else
        {
            velocity = rb.velocity;
        }
        rb.velocity = velocity;

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jump);
            isJumping = false;
            PlayerController.ThisPlayerController.SetSlideMode(new IsSliding());
        }

        return isJumping;
    }
}
