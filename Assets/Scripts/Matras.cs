using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matras : MonoBehaviour
{
    public Rigidbody rb;
    public float pLerp = 0.2f;
    public Camera cam;
    public GameObject matras;
    private Material m_Material;
    private CharacterController s1;
    public GameObject p;
    public GameObject les;
    public bool podnat = false;
    public float minDist = 3;
    public float toles = 3;
    public float sila;
    Collider m_Collider;
    void Start()
    {
        m_Collider = GetComponent<Collider>();
        m_Material = GetComponent<Renderer>().material;
        rb = matras.GetComponent<Rigidbody>();
        s1 = FindObjectOfType<CharacterController>();
        
    }
    void Update()
    {
        Vector3 direction = Camera.main.transform.forward + Camera.main.transform.up;
        float dist = Vector3.Distance(les.transform.position, gameObject.transform.position);
        if (dist < toles)
        {
            Debug.Log("SBIL");
            les.transform.Translate(0,0,-3);
            les.transform.Rotate(5, 0, 0);
        }
        if (Input.GetKey(KeyCode.E) && podnat == true)
        {
            m_Collider.enabled = true;
            podnat = false;
            rb.isKinematic = false;
            rb.AddForce(0, sila, 0);
        }
        else if (podnat == true)
        {
            transform.position = p.transform.position;
        }
        
    }
    void OnMouseOver()
    {
        
        float dist = Vector3.Distance(p.transform.position, gameObject.transform.position);
        if (dist < minDist && s1.items_picked.Contains("Lom") && s1.items_picked.Contains("Avtomat"))
        {
            m_Material.color = Color.blue;
            if (Input.GetKey(KeyCode.C) && podnat == false)
            {
                m_Collider.enabled = false;
                rb.isKinematic = true;
                transform.position = p.transform.position;
                podnat = true;
            }

        }
        else if (dist < minDist)
        {
            m_Material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        m_Material.color = Color.white;
    }
}
