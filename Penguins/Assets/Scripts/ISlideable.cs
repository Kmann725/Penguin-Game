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
    /// <param name="canJump"></param>
    /// <param name="xMovement"></param>
    /// <param name="zMovement"></param>
    /// <returns>Tuple of items. Used to set variables again once they are returned.</returns>
    Tuple<bool, float> slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, bool canJump, float xMovement, float zMovement);
}

class IsSliding : ISlideable
{
    public bool IsPlayerSliding { get => true; }
    public Tuple<bool, float> slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, bool canJump, float xMovement, float zMovement)
    {
        //Enter Sliding Movement Here
        return Tuple.Create(isJumping, speed);
    }
}

class NotSliding : ISlideable
{
    public bool IsPlayerSliding { get => false; }
    public Tuple<bool, float> slide(Rigidbody rb, bool grounded, float speed, float jump, bool isJumping, bool canJump, float xMovement, float zMovement)
    {
        if (xMovement != 0 && grounded)
        {
            rb.AddForce(rb.transform.right * (xMovement * speed * Time.deltaTime), ForceMode.Impulse);
        }

        if (zMovement != 0 && grounded)
        {
            rb.AddForce(rb.transform.forward * (zMovement * speed * Time.deltaTime), ForceMode.Impulse);
        }

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jump);
            isJumping = false;
        }

        return Tuple.Create(isJumping, speed);
    }
}
