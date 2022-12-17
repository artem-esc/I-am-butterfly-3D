using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledder : MonoBehaviour
{
    public Rigidbody rb;
    public float pLerp = 0.2f;
    public Camera cam;
    public GameObject matras;
    private Material m_Material;
    private CharacterController s1;
    public GameObject p;
    public GameObject punkt;
    public bool podnat = false;
    public float minDist = 3;
    public float toles = 3;
    public float sila;
    Collider m_Collider;
    public GameObject zamena;
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
        float dist = Vector3.Distance(punkt.transform.position, gameObject.transform.position);
        if (Input.GetKey(KeyCode.E) && podnat == true)
        {
            if (dist < toles)
            {
                zamena.SetActive(true);
                Destroy(gameObject);
            }

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
