using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource buttonSound; // ���� ����

    [SerializeField]
    private TextMeshProUGUI clearText; // Ŭ����ÿ� ��Ÿ���� Ŭ���� �ؽ�Ʈ ���� ex) Stage1-1 Clear
    [SerializeField]
    private GameObject stageSelectReconfirm; // �������� ���� â���� ���� ��Ȯ�� UIâ
    [SerializeField]
    private GameObject lobbyReconfirm; // �κ� â���� ���� ��Ȯ�� UIâ
    [SerializeField]
    private GameObject pauseUI; // ������ �Ͻ����� ���� �� �ߴ� UI
    [SerializeField]
    private GameObject retryReconfirm; // ��Ʈ���� ��Ȯ�� UI

    public int stageLevel; // �������� ���� ����
    public int stageDetailLevel; // ���� �������� ���� ����

    private void Start()
    {
        clearText.text = "Stage" + stageLevel + "-" + stageDetailLevel + " Clear"; // �� �������� ���� Ŭ���� �ؽ�Ʈ�� �ٸ��� ����.
        buttonSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // �Ͻ�����(�÷��̾ ���������� Ŭ�����ϰų� ������ ���� �����ϰ� esc�� ������ �Ͻ����� ��)
        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerGimic.isCleared && !PlayerGimic.isfailed)
        {
            pauseUI.SetActive(true); // �Ͻ����� UI Ȱ��ȭ

            Time.timeScale = 0; // ���� �Ͻ� ����
        }

        // ���̺� ���
        if(PlayerGimic.isCleared)
        {
            PlayerPrefs.SetInt("Stage" + stageLevel + "-" + stageDetailLevel + "Save", 1);
            PlayerPrefs.Save();
        }
    }

    // �ٷ� ���� ���������� �Ѿ�� ��ư
    public void NextStageButton()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        SceneManager.LoadScene("Stage" + stageLevel + "-" + (stageDetailLevel + 1)); // ���� �������� ������ �̵�

        // ���� ���� �������� ������ 10�� ��� �������� + 1 ex) 1-10�� Ŭ���� �ϸ� 2-1�� �̵�
        if (stageDetailLevel == 10)
        {
            SceneManager.LoadScene("Stage" + (stageLevel + 1) + "-" + 1);
        }

        // �Ͻ� ���� ����
        Time.timeScale = 1;
    }

    // �������� ����â���� �̵��ϴ� ��ư
    public void StageSelectButton()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        stageSelectReconfirm.SetActive(true); // �������� ����â���� ������ ��Ȯ���ϴ� UI Ȱ��ȭ
    }

    // �κ�â���� �̵��ϴ� ��ư
    public void LobbyButton()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        lobbyReconfirm.SetActive(true); // �κ�â���� ������ ��Ȯ���ϴ� UIȰ��ȭ
    }


    // �������� ����â ��Ȯ�� UI���� �������� ����â���� �̵��ϴ� ��ư
    public void RealStageSelect()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // �Ͻ����� ����

        SceneManager.LoadScene("StageSelect"); // �������� ���þ����� �̵�
    }

    // �������� ����â ��Ȯ�� UI������ No��ư
    public void StageSelectNo()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        stageSelectReconfirm.SetActive(false); // �������� ���� ��Ȯ�� UI ��Ȱ��ȭ
    }

    // �κ� ��Ȯ�� UI������ Lobby ��ư
    public void RealLobby()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // �Ͻ����� ����

        SceneManager.LoadScene("Lobby"); // �κ� ������ �̵�
    }

    // �κ� ��Ȯ�� UI������ No��ư
    public void LobbyNo()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        lobbyReconfirm .SetActive(false); // �κ� ��Ȯ�� UI ��Ȱ��ȭ
    }

    // �̾ �ϱ� ��ư
    public void ResumeButton()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // �Ͻ����� ����

        pauseUI.SetActive (false); // �Ͻ����� UI ��Ȱ��ȭ
    }

    // �ٽ��ϱ� ��ư
    public void RetryButton()
    {
        buttonSound.Play(); // ���� ���

        PlayerGimic.isCleared = false;

        retryReconfirm.SetActive (true); // �ٽ��ϱ� ��Ȯ�� UI Ȱ��ȭ
    }


    // �ٽ��ϱ� ��Ȯ�� UI������ �ٽ��ϱ� ��ư
    public void RealRetry()
    {
        buttonSound.Play(); // ���� ���
        PlayerGimic.isfailed = false; // bool���� �ʱ�ȭ
        PlayerGimic.isCleared = false;

        Time.timeScale = 1; // �Ͻ����� ����
        SceneManager.LoadScene("Stage" + stageLevel + "-" + stageDetailLevel); // ���� �������� �ε�
    }

    // �ٽ��ϱ� ��Ȯ�� UI������ No ��ư
    public void RetryNo()
    {
        buttonSound.Play(); // ���� ���
        PlayerGimic.isCleared = false;

        retryReconfirm.SetActive(false); // �ٽ��ϱ� ��Ȯ�� UI ��Ȱ��ȭ
    }
}
