using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    AudioSource buttonSound;

    private void Start()
    {
        buttonSound = GetComponent<AudioSource>();
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
}
