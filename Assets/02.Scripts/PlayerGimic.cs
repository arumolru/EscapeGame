using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("TRAPWALL"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            transform.Translate(transform.position + Vector3.up);
        }
    }
}
