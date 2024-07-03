using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerCtrl : MonoBehaviour
{
    private float moveSpeed = 3f; // 플레이어의 이동 속도
    public float rotateSpeed = 400f; // 플레이어의 회전 속도

    [SerializeField]
    private Button leftTurnButton;
    [SerializeField] 
    private Button rightTurnButton;

    [SerializeField]
    private VirtualJoystick joystick;

    private void Start()
    {
        leftTurnButton.name = "Fire1";
        rightTurnButton.name = "Fire2";
    }

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up);
        }

        else if(Input.GetButton("Fire2"))
        {
            transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.down);
        }
    }

    private void FixedUpdate()
    {
        Move();

        //Rotate();
    }

    void Move()
    {
        // 플레이어 이동
        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        float h = joystick.Horizontal();
        float v = joystick.Vertical();

        // 이동 벡터 계산
        Vector3 movement = new Vector3(h, 0f, v) * moveSpeed * Time.deltaTime;

        // 이동 적용
        transform.Translate(movement);
    }

    /*void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X");

        transform.Rotate(Time.deltaTime * rotateSpeed * Vector3.up, mouseX);
    }*/
}
