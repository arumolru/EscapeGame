using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb; // 플레이어 Rigidbody

    private float upSpeed = 7f; // 플레이어의 점프력 변수

    [SerializeField]
    private GameObject clearUI; // 클리어 UI
    [SerializeField]
    private GameObject failedUI; // 실패 UI

    [SerializeField]
    private AudioSource portalAudio; // 포탈에 닿았을 때 사운드
    [SerializeField]
    private AudioSource jumpAudio; // 점프 사운드
    [SerializeField]
    private AudioSource trapAudio; // 트랩 사운드
    [SerializeField]
    private AudioSource deleteAudio; // 사라지는 발판의 오디오

    static public bool isCleared = false; // 스테이지 클리어 여부
    static public bool isfailed = false; // 스테이지 실패 여부

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 게임 오버(트랩 또는 떨어졌을 경우)
        if(other.gameObject.CompareTag("TRAPWALL") || other.gameObject.CompareTag("FALLGROUND"))
        {
            isfailed = true; // 스테이지 실패 여부를 true로

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            failedUI.SetActive(true); // 실패 UI를 활성화

            Time.timeScale = 0; // 게임 일시 정지
        }

        // 게임 클리어(포탈에 닿았을 경우)
        if(other.gameObject.CompareTag("PORTAL"))
        {
            clearUI.SetActive(true); // 클리어 UI 활성화
            isCleared = true; // 스테이지 클리어 여부를 true로

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            Time.timeScale = 0; // 게임 일시 정지

            portalAudio.Play(); // 사운드 재생
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �÷��̾ �Ķ� ��ϰ� ����� ���
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            rb.AddForce(upSpeed * Vector3.up, ForceMode.Impulse); // �÷��̾� ����

            jumpAudio.Play(); // ���� ���
        }

        // �÷��̾ �Ͼ� ����� ����� ���
        if(collision.gameObject.CompareTag("DELETEWALL"))
        {
            StartCoroutine(DeleteSound());
        }
    }

    IEnumerator DeleteSound()
    {
        yield return new WaitForSeconds(1f);

        deleteAudio.Play(); // ���� ���
    }
}
