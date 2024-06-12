using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도

    private float rotateSpeed = 100f; // 플레이어의 회전 속도

    private void FixedUpdate()
    {
        Move();

        Turn();
    }

    void Move()
    {
        // 플레이어 이동 코드
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vec = new Vector3(Time.deltaTime * moveSpeed * h, 0f, Time.deltaTime * moveSpeed * v);

        transform.Translate(vec);
    }

    void Turn()
    {
        // 플레이어의 회전 코드
        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed * Time.deltaTime;

        Vector3 rotate = new Vector3(0, Time.deltaTime * rotateSpeed * mouseX, 0);

        transform.Rotate(rotate);
    } 
}
