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
    private int totalStages = 10;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();

        UpdateStageButton();
    }

    private void Update()
    {
        if(stageSelectIndex==2)
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
        // stageButton의 개수만큼 반복
        for(int i= 0; i<stageButton.Length; i++)
        {
            // 1-1스테이지 버튼은 상시 활성화
            if (i == 0)
            {
                stageButton[i].interactable = true;
                continue;
            }

            if (stageButton[i] != null)
            {
                // 스테이지의 클리어 정보 가져오기
                int stageLevel = (i / totalStages) + 1;
                int stageDetailLevel = (i % totalStages) + 1;
                int cleared = PlayerPrefs.GetInt("Stage" + stageLevel + "-" + stageDetailLevel + "Save", 0);

                // 클리어 여부에 따라 스테이지 버튼 활성화
                if (cleared == 1)
                {
                    stageButton[i + 1].interactable = true;
                }
                else
                {
                    stageButton[i + 1].interactable = false;
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

    public void Stage3_1()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-1");
    }

    public void Stage3_2()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-2");
    }

    public void Stage3_3()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-3");
    }

    public void Stage3_4()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-4");
    }

    public void Stage3_5()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-5");
    }

    public void Stage3_6()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-6");
    }

    public void Stage3_7()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-7");
    }

    public void Stage3_8()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-8");
    }

    public void Stage3_9()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-9");
    }

    public void Stage3_10()
    {
        buttonSound.Play();
        SceneManager.LoadScene("Stage3-10");
    }
}
