using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avtomat : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject to_install;
    public GameObject lamp;
    private Material m_Material;
    private CharacterController s1;
    private GameObject p;
    public Transform camTarget;
    public float pLerp = 0.2f;
    public float rLerp = .01f;
    public float MinAngle = 10f;
    public float MaxAngle = 10f;
    public GameObject cam;
    public float minDist = 3;
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        m_Material.color = new Color(0, 0, 0, 0f);
        s1 = FindObjectOfType<CharacterController>();
        p = GameObject.FindGameObjectWithTag("Player");
    }
    void OnMouseOver()
    {

        float dist = Vector3.Distance(p.transform.position, gameObject.transform.position);
        if (dist < minDist)
        {
            if (s1.items_picked.Contains("Avtomat"))
            {
                m_Material.color = Color.blue;
                if (Input.GetKey(KeyCode.E))
                {
                    Destroy(gameObject);
                    to_install.SetActive(true);
                    lamp.SetActive(true);
                    cam.transform.position = Vector3.Lerp(transform.position, camTarget.position, pLerp);
                    cam.transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);
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
