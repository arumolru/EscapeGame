using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMoveCube : MonoBehaviour
{
    private float moveSpeed = 3f;

    private bool isCrash = false;

    private void Update()
    {
        if (!isCrash)
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.right);
        }
        else
        {
            transform.Translate(Time.deltaTime * moveSpeed * Vector3.left);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("MOVECUBE"))
        {
            isCrash = !isCrash;
        }
    }
}
