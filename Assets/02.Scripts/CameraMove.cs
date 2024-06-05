using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target; // ������ ��� ������Ʈ

    public float distance = 10.0f; // ������Ʈ���� ī�޶��� �Ÿ�
    public float height = 5.0f; // ������Ʈ���� ī�޶��� ����

    public float rotationDamping = 3.0f; // ȸ�� �ӵ�
    public float heightDamping = 2.0f; // ���� �ӵ�

    void LateUpdate()
    {
        if (!target)
            return;

        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // ī�޶��� ȸ�� ����
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // ī�޶��� ���� ����
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // ī�޶��� ��ġ ���
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // ī�޶� ������Ʈ�� �ٶ󺸵��� ȸ��
        transform.LookAt(target);
    }
}
