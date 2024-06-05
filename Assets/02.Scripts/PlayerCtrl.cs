using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Animator anim;

    private float moveSpeed = 3f;

    public float rotateSpeed = 80f;

    private void Start()
    {
        anim= GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();

        Turn();

        if (Input.GetKey(KeyCode.LeftShift))
            Dash();

        if(Input.GetKeyUp(KeyCode.LeftShift))
            moveSpeed = 3f;
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(Time.deltaTime * moveSpeed * h, 0f, Time.deltaTime * moveSpeed * v);

        transform.Translate(vec);
    }

    void Turn()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        Vector3 rotate = new Vector3(0, Time.deltaTime * rotateSpeed * mouseX, 0);

        transform.Rotate(rotate);
    }    

    void Dash()
    {
        moveSpeed = 6f;
    }
}
