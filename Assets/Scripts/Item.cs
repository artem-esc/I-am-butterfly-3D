using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Material m_Material;
    private CharacterController s1;
    private GameObject p;
    public Animation anim;
    public float minDist = 3;
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
        print("Materials " + Resources.FindObjectsOfTypeAll(typeof(Material)).Length);
        s1 = FindObjectOfType<CharacterController>();
        p = GameObject.Find("Character");
        anim = p.GetComponent<Animation>();
        anim["PickLow"].speed = 1.5f;
        anim["PickMid"].speed = 1.5f;
        anim["PickHigh"].speed = 1.5f;
    }
    void OnMouseOver()
    {
        
        float dist = Vector3.Distance(p.transform.position, gameObject.transform.position);
        if (dist < minDist)
        {
            m_Material.color = Color.blue;
            if (Input.GetKey(KeyCode.C))
            {
                if(gameObject.transform.position.y < 0.5)
                {
                    anim.Play("PickLow");
                }
                else if (gameObject.transform.position.y < 1 && gameObject.transform.position.y > 0.5)
                {
                    anim.Play("PickMid");
                }
                else if (gameObject.transform.position.y > 1)
                {
                    anim.Play("PickHigh");
                }
                StartCoroutine(Dele());
            }
        }
    }
    private IEnumerator Dele()
    {
        yield return new WaitForSeconds(2);
        s1.items_picked.Add(gameObject.name);
        Destroy(gameObject);
    }
    void OnMouseExit()
    {
        m_Material.color = Color.white;
    }
}
