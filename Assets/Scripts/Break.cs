using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject to_break;
    private Material m_Material;
    private CharacterController s1;
    private GameObject p;
    public float minDist = 3;
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = new Color(0, 0, 0, 0f);
        rb = to_break.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        s1 = FindObjectOfType<CharacterController>();
        p = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseOver()
    {

        float dist = Vector3.Distance(p.transform.position, gameObject.transform.position);
        if (dist < minDist)
        {
            if (s1.items_picked.Contains("Lom"))
            {
                m_Material.color = Color.blue;
                if (Input.GetKey(KeyCode.E))
                {
                    Destroy(gameObject);
                    rb.isKinematic = false;
                }
            }
            else
            {
                m_Material.color = Color.red;
            }
           
        }
    }
    void OnMouseExit()
    {
        m_Material.color = new Color(0, 0, 0, 0f);
    }
}
