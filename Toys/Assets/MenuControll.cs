using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControll : MonoBehaviour
{
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void TitleScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Title Scene");
    }

    public void SampleScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
