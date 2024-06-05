using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f;

    public float rotateSpeed = 80f;

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(Time.deltaTime * moveSpeed * h, 0f, Time.deltaTime * moveSpeed * v);

        transform.Translate(vec);

        if(!(h==0 && v==0))
        {

        }

        if (Input.GetKey(KeyCode.LeftShift))
            Dash();

        if(Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed = 3f;
    }

    void Dash()
    {
        moveSpeed = 6f;
    }
}
