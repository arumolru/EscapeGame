using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // 움직일 대상 오브젝트

    public float distance = 10.0f; // 오브젝트에서 카메라의 거리
    public float height = 5.0f; // 오브젝트에서 카메라의 높이

    public float rotationDamping = 3.0f; // 회전 속도
    public float heightDamping = 2.0f; // 높이 속도

    void LateUpdate()
    {
        if (!target)
            return;

        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // 카메라의 회전 조절
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // 카메라의 높이 조절
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // 카메라의 위치 계산
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // 카메라가 오브젝트를 바라보도록 회전
        transform.LookAt(target);
    }
}
