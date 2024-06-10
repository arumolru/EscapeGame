using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource buttonSound;

    [SerializeField]
    private TextMeshProUGUI clearText;
    [SerializeField]
    private GameObject stageSelectReconfirm;
    [SerializeField]
    private GameObject lobbyReconfirm;
    [SerializeField]
    private GameObject pauseUI;
    [SerializeField]
    private GameObject retryReconfirm;

    public int stageLevel;
    public int stageDetailLevel;

    private void Start()
    {
        clearText.text = "Stage" + stageLevel + "-" + stageDetailLevel + " Clear";
        buttonSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerGimic.isCleared && !PlayerGimic.isfailed)
        {
            pauseUI.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void NextStageButton()
    {
        buttonSound.Play();

        SceneManager.LoadScene("Stage" + stageLevel + "-" + (stageDetailLevel + 1));

        if (stageDetailLevel == 10)
        {
            SceneManager.LoadScene("Stage" + (stageLevel + 1) + "-" + 1);
        }

        Time.timeScale = 1;
    }

    public void StageSelectButton()
    {
        buttonSound.Play();

        stageSelectReconfirm.SetActive(true);
    }

    public void LobbyButton()
    {
        buttonSound.Play();

        lobbyReconfirm.SetActive(true);
    }

    public void RealStageSelect()
    {
        buttonSound.Play();

        Time.timeScale = 1;

        SceneManager.LoadScene("StageSelect");
    }

    public void StageSelectNo()
    {
        buttonSound.Play();

        stageSelectReconfirm.SetActive(false);
    }

    public void RealLobby()
    {
        buttonSound.Play();

        Time.timeScale = 1;

        SceneManager.LoadScene("Lobby");
    }

    public void LobbyNo()
    {
        buttonSound.Play();

        lobbyReconfirm .SetActive(false);
    }

    public void ResumeButton()
    {
        buttonSound.Play();

        Time.timeScale = 1;

        pauseUI.SetActive (false);
    }

    public void RetryButton()
    {
        buttonSound.Play();

        retryReconfirm.SetActive (true);
    }

    public void RealRetry()
    {
        buttonSound.Play();
        PlayerGimic.isfailed = false;

        Time.timeScale = 1;
        SceneManager.LoadScene("Stage" + stageLevel + "-" + stageDetailLevel);
    }

    public void RetryNo()
    {
        buttonSound.Play();

        retryReconfirm.SetActive(false);
    }
}
