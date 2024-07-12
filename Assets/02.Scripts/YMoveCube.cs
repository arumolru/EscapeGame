using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YMoveCube : MonoBehaviour
{
    private float moveSpeed = 2f;

    private bool isCrash = false;

    private void Update()
    {
        if (!isCrash)
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.down);
        }
        else
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.up);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("MOVECUBE"))
        {
            isCrash = !isCrash;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GROUND") || collision.gameObject.CompareTag("DELETEWALL"))
        {
            isCrash = !isCrash;
        }
    }
}
