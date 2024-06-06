using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource buttonSound; // 버튼 사운드

    [SerializeField]
    private GameObject exitReconfirmUI; // 종료 재확인 UI; 

    public void StartButton()
    {
        buttonSound.Play(); // 사운드 재생

        StartCoroutine(LoadSelect()); // 스테이지 선택 창으로 이동
    }

    public void Exit()
    {
        buttonSound.Play(); // 사운드 재생

        exitReconfirmUI.SetActive(true); // 종료 재확인 창 활성화
    }

    // 1초후 레벨 선택 씬으로 이동
    IEnumerator LoadSelect()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("StageSelect");
    }

    public void RealExit()
    {
        buttonSound.Play(); // 사운드 재생

        Application.Quit(); // 게임 종료
    }

    public void No()
    {
        buttonSound.Play(); // 사운드 재생

        exitReconfirmUI.SetActive(false); // 재확인 UI 비활성화
    }
}
