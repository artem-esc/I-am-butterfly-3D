using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHint : MonoBehaviour
{
    public string texts;
    public float time;
    public TextMeshProUGUI textmeshPro;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Debug.Log(22);
            textmeshPro.text = texts;
            StartCoroutine(Shadow());
        }
    }


    private IEnumerator Shadow()
    {
        yield return new WaitForSeconds(time);
        textmeshPro.text = string.Empty;
    }

}
