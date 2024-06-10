using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb;

    private float upSpeed = 7f;

    [SerializeField]
    private GameObject clearUI;
    [SerializeField]
    private GameObject failedUI;

    [SerializeField]
    private AudioSource portalAudio;
    [SerializeField]
    private AudioSource jumpAudio;
    [SerializeField]
    private AudioSource trapAudio;

    public int stageLevel;
    public int stageDetailLevel;

    static public bool isCleared = false;
    static public bool isfailed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TRAPWALL") || other.gameObject.CompareTag("FALLGROUND"))
        {
            isfailed = true;

            failedUI.SetActive(true);

            Time.timeScale = 0;
        }

        if(other.gameObject.CompareTag("PORTAL"))
        {
            clearUI.SetActive(true);
            isCleared = true;

            Time.timeScale = 0;

            portalAudio.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            rb.AddForce(upSpeed * Vector3.up, ForceMode.Impulse);

            jumpAudio.Play();
        }
    }
}
