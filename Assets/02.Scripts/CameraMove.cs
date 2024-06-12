using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform player; // 플레이어의 위치 변수

    public float distance = 3f; // 카메라와 플레이어 사이의 거리
    public float height = 1.5f; // 카메라의 높이

    public float rotationDamping = 3.0f; 
    public float heightDamping = 2.0f;

    void LateUpdate()
    {
        // 에러 차단
        if (!player)
            return;

        float wantedRotationAngle = player.eulerAngles.y; // 회전각 = 플레이어의 y축
        float wantedHeight = player.position.y + height; // 높이 = 플레이어의 y축 + 높이

        float currentRotationAngle = transform.eulerAngles.y; // 현재의 앵글 변수
        float currentHeight = transform.position.y; // 현재의 높이 변수

        // 앵글 각
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // 높이
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // 회전 값
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // 카메라의 위치 조정
        transform.position = player.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // 카메라는 플레이어를 바라보게 설정
        transform.LookAt(player);
    }
}
