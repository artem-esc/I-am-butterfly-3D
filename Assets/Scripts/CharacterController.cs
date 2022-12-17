using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 5.0f;
    public float Shiftspeed = 7.0f;
    public float Shiftrspeed = 7.0f;
    public float rspeed = 2.1f;
    public float jumpforce = 5f;
    public Animation anim;
    public Rigidbody rb;
    public Camera myCamera;
    public float fovlerp = 2.1f;
    public List<string> items_picked = new List<string>();

    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Shiftspeed);
                anim.Play("running");
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70, fovlerp);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1 * Vector3.forward * Time.deltaTime * Shiftspeed);
                anim.Play("running");
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70, fovlerp);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -1 * Shiftrspeed * Time.deltaTime, 0);
                anim.Play("running");
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70, fovlerp);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 1 * Shiftrspeed * Time.deltaTime, 0);
                anim.Play("running");
                myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 70, fovlerp);
            }
        }
        else
        {
            myCamera.fieldOfView = Mathf.Lerp(myCamera.fieldOfView, 44, fovlerp);
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate( Vector3.forward * Time.deltaTime * speed);
                anim.Play("walking");
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(-1 * Vector3.forward * Time.deltaTime * speed);
                anim.Play("walking");
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -1 * rspeed * Time.deltaTime, 0  );
                anim.Play("walking");
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 1 * rspeed * Time.deltaTime, 0 );
                anim.Play("walking");
            }
            if (Input.GetKey(KeyCode.Space))
            {
                anim.Play("jumping");
            }
        }

    }
}