using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도

    private float rotateSpeed = 100f; // 플레이어의 회전 속도

    public VirtualJoystick joystick; // 가상 조이스틱

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // 플레이어 이동 코드
        float h = joystick.Horizontal();
        float v = joystick.Vertical();

        Vector3 vec = new Vector3(Time.deltaTime * moveSpeed * h, 0f, Time.deltaTime * moveSpeed * v);

        transform.Translate(vec);
    }
}
