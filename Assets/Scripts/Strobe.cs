using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Strobe : MonoBehaviour
{
    public bool blink = false;
    public float min = 0.0f;
    public float max = 5f;
    public Light myLight;
    public GameObject Lamp;
    void Start()
    {
        Light myLight = GetComponent<Light>();
        if (blink == true)
            StartCoroutine(Blink());
    }
    IEnumerator Blink()
    {
        float r = Random.Range(min, max);
        myLight.intensity = Mathf.PingPong(Time.time, r);
        if(r < 1)
        {
            Lamp.SetActive(false);
        }
        else
        {
            Lamp.SetActive(true);
        }
        yield return new WaitForSeconds(.1f);
        StartCoroutine(Blink());
    }
}
