using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camTarget;
    public float pLerp = 0.2f;
    public float rLerp = .01f;
    public float MinAngle = 10f;
    public float MaxAngle = 10f;
    public float sens;
    void Update()
    {
        float mouse = Input.GetAxis("Mouse Y");
        transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);

    }
}
