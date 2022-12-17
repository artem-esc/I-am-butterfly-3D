using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    public GameObject p;
    public float minDist;
    public Animation anim;
    public float step;
    public Rigidbody rb;
    public GameObject cam;
    public Transform camTarget;
    private float progress;
    public float rot;
    public float pos;
    public Transform final;
    public float tofin;
    void Start()
    {
        rb = p.GetComponent<Rigidbody>();
        anim = p.GetComponent<Animation>();
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(1);
        if(collider.gameObject.tag == "Player" && gameObject.active == true)
        {
            rb.isKinematic = true;
            Debug.Log(2);
            p.transform.position += new Vector3(0, step * Time.deltaTime, 0);
            cam.transform.position = Vector3.Lerp(transform.position, camTarget.position, pos);
            cam.transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rot);

        }

        
    }
    void OnTriggerExit(Collider collider)
    {
        rb.isKinematic = false;
        float dist = Vector3.Distance(p.transform.position, final.transform.position);
        if (dist < tofin)
        {
            p.transform.position += new Vector3(1, 0.1f, 0);
        }
    }
}
