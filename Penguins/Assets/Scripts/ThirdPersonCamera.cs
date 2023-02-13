using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public GameObject player;
    public GameObject target;
    public float rotateSpeed = 5;
    public float maxXRot = 60;
    public float minXRot = -60;
    private float rotX;
    private float offset;

    void Start()
    {
        offset = Vector3.Distance(player.transform.position, transform.position);
    }

    void LateUpdate()
    {
        Vector3 newPos;

        float y = Input.GetAxis("Mouse X") * rotateSpeed;
        rotX += Input.GetAxis("Mouse Y") * rotateSpeed;
        rotX = Mathf.Clamp(rotX, minXRot, maxXRot);
        transform.eulerAngles = new Vector3(-rotX, transform.eulerAngles.y + y, 0);
        newPos = target.transform.position - (transform.forward * offset);
        newPos.y += 0.15f;
        transform.position = newPos;

        
    }
}
