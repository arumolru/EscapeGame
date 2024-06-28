using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도
    private float rotateSpeed = 50f; // 플레이어의 회전 속도

    public VirtualJoystick joystick; // 플레이어 조이 스틱 스크립트

    private bool isLeftRotating = false; // 플레이어의 왼쪽 회전 여부
    private bool isRightRotating = false; // 플레이어의 오른쪽 회전 여부

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        Move();

        if(isLeftRotating && !isRightRotating)
        {
            transform.Rotate(Time.deltaTime * -rotateSpeed * Vector3.up);
        }

        if(isRightRotating && !isLeftRotating)
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up);
        }
    }

    void Move()
    {
        // 플레이어 이동
        float h = joystick.Horizontal(); // 가상 조이스틱의 수평값 (-1에서 1 사이)
        float v = joystick.Vertical(); // 가상 조이스틱의 수직값 (-1에서 1 사이)

        // 이동 벡터 계산
        Vector3 movement = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.Translate(movement);
    }

    public void LeftRotate()
    {
        if(!isLeftRotating)
        {
            isLeftRotating = true;
            isRightRotating = false;
        }
        else
        {
            isLeftRotating = false;
            isRightRotating = false;
        }
    }

    public void RightRotate()
    {
        if(!isRightRotating)
        {
            isRightRotating = true;
            isLeftRotating = false;
        }
        else
        {
            isRightRotating = false;
            isLeftRotating = false;
        }
    }
}
