using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb;

    private float upSpeed = 6f;

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
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            rb.AddForce(upSpeed * Vector3.up, ForceMode.Impulse);
        }
    }
}
