using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGimic : MonoBehaviour
{
    Rigidbody rb; // 플레이어의 Rigidbody 컴포넌트

    private float upSpeed = 7f; // 플레이어의 점프 속도

    [SerializeField]
    private GameObject clearUI; // 클리어 UI
    [SerializeField]
    private GameObject failedUI; // 게임 실패 UI

    [SerializeField]
    private AudioSource portalAudio; // 포탈에 들어갈 시 사운드
    [SerializeField]
    private AudioSource jumpAudio; // 점프 블록을 밟았을 때의 사운드
    [SerializeField]
    private AudioSource trapAudio; // 트랩을 밟았을 때의 사운드

    public int stageLevel; // 스테이지 레벨
    public int stageDetailLevel; // 스테이지의 세부 레벨

    static public bool isCleared = false; // 스테이지의 클리어 여부
    static public bool isfailed = false; // 스테이지의 실패 여부

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // 붉은 블록이나 떨어졌을 때의 이벤트
        if(other.gameObject.CompareTag("TRAPWALL") || other.gameObject.CompareTag("FALLGROUND"))
        {
            isfailed = true; // 게임 실패 변수

            failedUI.SetActive(true); // 게임 실패 UI 활성화

            Time.timeScale = 0; // 게임 일시 정지
        }

        // 플레이어가 포탈에 닿았을 시
        if(other.gameObject.CompareTag("PORTAL"))
        {
            clearUI.SetActive(true); // 게임 클리어 UI 생성
            isCleared = true; // 게임 클리어

            Time.timeScale = 0; // 일시 정지

            portalAudio.Play(); // 사운드 재생
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 플레이어가 파란 블록과 닿았을 경우
        if(collision.gameObject.CompareTag("UPWALL"))
        {
            rb.AddForce(upSpeed * Vector3.up, ForceMode.Impulse); // 플레이어 점프

            jumpAudio.Play(); // 사운드 재생
        }
    }
}
