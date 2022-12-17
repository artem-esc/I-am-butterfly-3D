using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyItem : MonoBehaviour
{
    GameObject too;
    void Start()
    {
        too = GameObject.FindGameObjectWithTag("Heavy");
        too.SetActive(false);
    }
    void OnMouseOver()
    {
        too.SetActive(true);
    }
    void OnMouseExit()
    {
        too.SetActive(false);
    }
}
