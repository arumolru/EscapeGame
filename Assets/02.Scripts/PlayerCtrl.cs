using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // �÷��̾��� �̵� �ӵ�

    private float rotateSpeed = 100f; // �÷��̾��� ȸ�� �ӵ�

    public VirtualJoystick joystick; // ���� ���̽�ƽ

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // �÷��̾� �̵� �ڵ�
        float h = joystick.Horizontal();
        float v = joystick.Vertical();

        Vector3 vec = new Vector3(Time.deltaTime * moveSpeed * h, 0f, Time.deltaTime * moveSpeed * v);

        transform.Translate(vec);
    }
}
