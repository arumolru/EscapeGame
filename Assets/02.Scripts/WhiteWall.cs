using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteWall : MonoBehaviour
{
    private float deleteTime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            StartCoroutine(DeleteWall());
        }
    }

    IEnumerator DeleteWall()
    {
        yield return new WaitForSeconds(deleteTime);

        Destroy(gameObject);
    }
}
