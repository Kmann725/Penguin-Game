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
    /// <param name="jump"></param>
    /// <param name="isJumping"></param>
    /// <param name="xMovement"></param>
    /// <param name="zMovement"></param>
    /// <returns>Bool of IsJumping (set back to false).</returns>
    bool slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, float xMovement, float zMovement);
}

class IsSliding : ISlideable
{
    public bool IsPlayerSliding { get => true; }
    public bool slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, float xMovement, float zMovement)
    {
        if (xMovement != 0 && grounded)
        {
            //rb.AddForce(rb.transform.right * (xMovement * speed * Time.deltaTime), ForceMode.Impulse);
            rb.AddForce(rb.transform.right * (xMovement * speed), ForceMode.Force);
        }

        if (zMovement != 0 && grounded)
        {
            //rb.AddForce(rb.transform.forward * (zMovement * speed * Time.deltaTime), ForceMode.Impulse);
            rb.AddForce(rb.transform.forward * (zMovement * speed), ForceMode.Force);
        }

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jump);
            isJumping = false;
        }

        return isJumping;
    }
}

class NotSliding : ISlideable
{
    public bool IsPlayerSliding { get => false; }
    public bool slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, float xMovement, float zMovement)
    {
        //Enter non sliding movement
        if(grounded)
        {
            Vector3 movement = new Vector3(xMovement, 0f, zMovement).normalized;
            Vector3 velocity = (rb.transform.right * xMovement + rb.transform.forward * zMovement).normalized * speed;
            velocity.y = rb.velocity.y;
            rb.velocity = velocity;
        }

        if(isJumping)
        {
            rb.AddForce(Vector3.up * jump);
            isJumping = false;
        }

        return isJumping;
    }
}
