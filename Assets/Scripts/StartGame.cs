using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public float time;
    public float time2;
    public string s1;
    public string s2;
    public string s3;
    public TextMeshProUGUI textmeshPro;

    void Start()
    {
        StartCoroutine(First());
        
        
    }

    private IEnumerator First()
    {
        textmeshPro.text = s1;
        yield return new WaitForSeconds(time);
        StartCoroutine(Second());
    }
    private IEnumerator Second()
    {
        textmeshPro.text = s2;
        yield return new WaitForSeconds(time);
        StartCoroutine(Third());
    }
    private IEnumerator Third()
    {
        textmeshPro.text = s3;
        yield return new WaitForSeconds(time);
        StartCoroutine(Scene());
    }
    private IEnumerator Scene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene("SampleScene");
       
        
    }

}
