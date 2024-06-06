using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI clearText;

    public int stageLevel;

    private void Start()
    {
        clearText.text = "Stage" + stageLevel + "Clear";
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage" + (stageLevel + 1));
    }

    public void StageSelect()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
