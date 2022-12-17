using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Catharsis : MonoBehaviour
{
    public GameObject main;
    public GameObject second;
    public GameObject but;
    public GameObject p;
    public Animator babo;
    public Animation babo2;
    public Animation anim1;
    public Animation anim2;
    public AudioSource audioData;
    public Vector3 pose;
    public GameObject find;
    public AudioSource nenuzh;
    void Awake()
    {
        babo = but.GetComponent<Animator>();
        babo2 = but.GetComponent<Animation>();
        main.SetActive(true);
        second.SetActive(false);
        babo.Play("bab");
    }

    void Start()
    {
        anim1 = second.GetComponent<Animation>();
        anim2 = p.GetComponent<Animation>();
        anim2["Throw"].speed = 0.2f;
    }

    void OnTriggerEnter(Collider collider)
    {
        find.SetActive(false);
        p.GetComponent<CharacterController>().enabled = false;
        p.transform.position = pose;
        nenuzh.Stop();
        audioData.Play();
        main.SetActive(false);
        second.SetActive(true);
        babo.StopPlayback();
        babo.Play("otpusk");
        anim2.Play("Throw");
        anim1.Play("New Animation");
        StartCoroutine(End());

    }
    private IEnumerator End()
    {
        yield return new WaitForSeconds(37);
        SceneManager.LoadScene("Catharsis");
    }
}
