using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    AudioSource buttonSound;

    [SerializeField]
    private GameObject[] stageSelect;
    private int stageSelectIndex = 0;

    [SerializeField]
    private Button nextButton;
    [SerializeField]
    private Button beforeButton;

    [SerializeField]
    private Button[] stageButton;
    private int totalStages = 20;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();

        UpdateStageButton();
    }

    private void Update()
    {
        if(stageSelectIndex==1)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
        }

        if(stageSelectIndex==0)
        {
            beforeButton.interactable = false;
        }
        else
        {
            beforeButton.interactable = true;
        }
    }

    void UpdateStageButton()
    {
        for (int i = 0; i < stageButton.Length; i++)
        {
            if (stageButton[i] != null)
            {
                // PlayerPrefs에서 저장된 스테이지 클리어 정보를 불러옵니다.
                int stageLevel = (i / totalStages) + 1;
                int stageDetailLevel = (i % totalStages) + 1;
                int isCleared = PlayerPrefs.GetInt("Stage" + stageLevel + "-" + stageDetailLevel + "Save", 0);

                // 저장된 값에 따라 버튼을 활성화/비활성화합니다.
                if (isCleared == 1)
                {
                    stageButton[i].interactable = true;
                }
                else
                {
                    stageButton[i].interactable = false;
                }
            }
        }
    }

    public void NextStage()
    {       
        stageSelect[stageSelectIndex].SetActive(false);
        stageSelect[stageSelectIndex + 1].SetActive(true);

        stageSelectIndex += 1;

        Debug.Log(stageSelectIndex);
    }

    public void BeforeStage()
    {
        stageSelect[stageSelectIndex].SetActive(false);
        stageSelect[stageSelectIndex - 1].SetActive(true);

        stageSelectIndex -= 1;

        Debug.Log(stageSelectIndex);
    }

    public void Stage1_1()
    {
        buttonSound .Play();
        SceneManager.LoadScene("Stage1-1");
    }

    public void Stage1_2()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-2");
    }

    public void Stage1_3()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-3");
    }

    public void Stage1_4()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-4");
    }

    public void Stage1_5()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-5");
    }

    public void Stage1_6()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-6");
    }

    public void Stage1_7()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-7");
    }

    public void Stage1_8()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-8");
    }

    public void Stage1_9()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-9");
    }

    public void Stage1_10()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage1-10");
    }

    public void Stage2_1()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-1");
    }

    public void Stage2_2()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-2");
    }

    public void Stage2_3()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-3");
    }

    public void Stage2_4()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-4");
    }

    public void Stage2_5()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-5");
    }

    public void Stage2_6()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-6");
    }

    public void Stage2_7()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-7");
    }

    public void Stage2_8()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-8");
    }

    public void Stage2_9()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-9");
    }

    public void Stage2_10()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage2-10");
    }
}
