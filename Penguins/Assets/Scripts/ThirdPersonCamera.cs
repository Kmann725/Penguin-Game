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
    Vector3 offset;

    void Start()
    {
        offset = player.transform.position - transform.position;
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.transform.Rotate(vertical, horizontal, 0);
        player.transform.Rotate(0, horizontal, 0);
        float yAngle = target.transform.eulerAngles.y;
        float xAngle = target.transform.eulerAngles.x;
        Quaternion rotation = Quaternion.Euler(xAngle, yAngle, 0);
        transform.position = target.transform.position - (rotation * offset);

        transform.LookAt(target.transform);
    }
}
