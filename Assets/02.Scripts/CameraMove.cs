using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform player; // �÷��̾��� ��ġ ����

    public float distance = 3f; // ī�޶�� �÷��̾� ������ �Ÿ�
    public float height = 1.5f; // ī�޶��� ����

    public float rotationDamping = 3.0f; 
    public float heightDamping = 2.0f;

    void LateUpdate()
    {
        // ���� ����
        if (!player)
            return;

        float wantedRotationAngle = player.eulerAngles.y; // ȸ���� = �÷��̾��� y��
        float wantedHeight = player.position.y + height; // ���� = �÷��̾��� y�� + ����

        float currentRotationAngle = transform.eulerAngles.y; // ������ �ޱ� ����
        float currentHeight = transform.position.y; // ������ ���� ����

        // �ޱ� ��
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // ����
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

        // ȸ�� ��
        Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

        // ī�޶��� ��ġ ����
        transform.position = player.position;
        transform.position -= currentRotation * Vector3.forward * distance;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

        // ī�޶�� �÷��̾ �ٶ󺸰� ����
        transform.LookAt(player);
    }
}
