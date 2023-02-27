using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public float maxSize = 6f;
    public float minSize = 0.4f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((rb.velocity.x >= 0.15f || rb.velocity.x <= -0.15f) && (rb.velocity.z >= 0.15f || rb.velocity.z <= -0.15f) && collision.gameObject.CompareTag("GroundSnow") && transform.localScale.x <= maxSize)
        {
            transform.localScale = transform.localScale * (1.005f);
        }
        if (collision.gameObject.CompareTag("GroundIce") && transform.localScale.x >= minSize)
        {
            transform.localScale = transform.localScale * (0.999f);
        }
    }
}
