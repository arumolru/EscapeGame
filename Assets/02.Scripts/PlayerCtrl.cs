using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도
    private float rotateSpeed = 250f; // 플레이어의 회전 속도

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Move();

        Rotate();
    }

    void Move()
    {
        // 플레이어 이동
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        // 이동 벡터 계산
        Vector3 movement = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.Translate(movement);
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up, mouseX);
    }
}
