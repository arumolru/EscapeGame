using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb;

    private float upSpeed = 6f;

    [SerializeField]
    private GameObject clearUI;

    [SerializeField]
    private AudioSource portalAudio;
    [SerializeField]
    private AudioSource jumpAudio;

    static public bool isCleared = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TRAPWALL"))
        {
            Destroy(gameObject);
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
