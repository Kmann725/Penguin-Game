using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float maxSize = 6f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if (rb.velocity.x >= 0.05f && rb.velocity.z >= 0.05f && collision.gameObject.CompareTag("GroundSnow") && transform.localScale.x <= maxSize)
        {

            transform.localScale = transform.localScale * (1.005f);
        }
    }
}