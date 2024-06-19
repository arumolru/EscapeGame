using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource buttonSound; // 사운드 변수

    [SerializeField]
    private TextMeshProUGUI clearText; // 클리어시에 나타나는 클리어 텍스트 변수 ex) Stage1-1 Clear
    [SerializeField]
    private GameObject stageSelectReconfirm; // 스테이지 선택 창으로 가는 재확인 UI창
    [SerializeField]
    private GameObject lobbyReconfirm; // 로비 창으로 가는 재확인 UI창
    [SerializeField]
    private GameObject pauseUI; // 게임을 일시정지 했을 때 뜨는 UI
    [SerializeField]
    private GameObject retryReconfirm; // 리트라이 재확인 UI

    public int stageLevel; // 스테이지 레벨 변수
    public int stageDetailLevel; // 세부 스테이지 레벨 변수

    private void Start()
    {
        clearText.text = "Stage" + stageLevel + "-" + stageDetailLevel + " Clear"; // 각 스테이지 별로 클리어 텍스트가 다르게 만듦.
        buttonSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // 일시정지(플레이어가 스테이지를 클리어하거나 실패할 때를 제외하고 esc를 누르면 일시정지 됨)
        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerGimic.isCleared && !PlayerGimic.isfailed)
        {
            pauseUI.SetActive(true); // 일시정지 UI 활성화

            Time.timeScale = 0; // 게임 일시 정지
        }

        // 세이브 기능
        if(PlayerGimic.isCleared)
        {
            PlayerPrefs.SetInt("Stage" + stageLevel + "-" + stageDetailLevel + "Save", 1);
            PlayerPrefs.Save();
        }
    }

    // 바로 다음 스테이지로 넘어가는 버튼
    public void NextStageButton()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        SceneManager.LoadScene("Stage" + stageLevel + "-" + (stageDetailLevel + 1)); // 다음 스테이지 씬으로 이동

        // 만약 세부 스테이지 레벨이 10일 경우 스테이지 + 1 ex) 1-10을 클리어 하면 2-1로 이동
        if (stageDetailLevel == 10)
        {
            SceneManager.LoadScene("Stage" + (stageLevel + 1) + "-" + 1);
        }

        // 일시 정지 해제
        Time.timeScale = 1;
    }

    // 스테이지 선택창으로 이동하는 버튼
    public void StageSelectButton()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        stageSelectReconfirm.SetActive(true); // 스테이지 선택창으로 가는지 재확인하는 UI 활성화
    }

    // 로비창으로 이동하는 버튼
    public void LobbyButton()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        lobbyReconfirm.SetActive(true); // 로비창으로 가는지 재확인하는 UI활성화
    }


    // 스테이지 선택창 재확인 UI에서 스테이지 선택창으로 이동하는 버튼
    public void RealStageSelect()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // 일시정지 해제

        SceneManager.LoadScene("StageSelect"); // 스테이지 선택씬으로 이동
    }

    // 스테이지 선택창 재확인 UI에서의 No버튼
    public void StageSelectNo()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        stageSelectReconfirm.SetActive(false); // 스테이지 선택 재확인 UI 비활성화
    }

    // 로비 재확인 UI에서의 Lobby 버튼
    public void RealLobby()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // 일시정지 해제

        SceneManager.LoadScene("Lobby"); // 로비 씬으로 이동
    }

    // 로비 재확인 UI에서의 No버튼
    public void LobbyNo()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        lobbyReconfirm .SetActive(false); // 로비 재확인 UI 비활성화
    }

    // 이어서 하기 버튼
    public void ResumeButton()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // 일시정지 해제

        pauseUI.SetActive (false); // 일시정지 UI 비활성화
    }

    // 다시하기 버튼
    public void RetryButton()
    {
        buttonSound.Play(); // 사운드 재생

        PlayerGimic.isCleared = false;

        retryReconfirm.SetActive (true); // 다시하기 재확인 UI 활성화
    }


    // 다시하기 재확인 UI에서의 다시하기 버튼
    public void RealRetry()
    {
        buttonSound.Play(); // 사운드 재생
        PlayerGimic.isfailed = false; // bool변수 초기화
        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // 일시정지 해제
        SceneManager.LoadScene("Stage" + stageLevel + "-" + stageDetailLevel); // 기존 스테이지 로드
    }

    // 다시하기 재확인 UI에서의 No 버튼
    public void RetryNo()
    {
        buttonSound.Play(); // 사운드 재생
        PlayerGimic.isCleared = false;

        retryReconfirm.SetActive(false); // 다시하기 재확인 UI 비활성화
    }
}
