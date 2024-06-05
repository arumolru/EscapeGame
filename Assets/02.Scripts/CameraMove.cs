using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 cameraPos;

    [SerializeField]
    private GameObject player;

    public float offsetX = 0f;
    public float offsetY = 10f;
    public float offsetZ = -10f;

    public float cameraSpeed = 10f;

    private void FixedUpdate()
    {
        cameraPos = new Vector3(player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);

        transform.position = Vector3.Lerp(transform.position, cameraPos, Time.deltaTime * cameraSpeed);
    }
}
