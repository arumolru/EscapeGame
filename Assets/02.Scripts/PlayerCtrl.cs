using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도
    private float rotateSpeed = 100f; // 플레이어의 회전 속도

    public VirtualJoystick joystick; // 플레이어 조이 스틱 스크립트

    private void FixedUpdate()
    {
        Move();
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
}
