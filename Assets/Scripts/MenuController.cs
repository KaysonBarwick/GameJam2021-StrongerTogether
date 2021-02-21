using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public bool hideMenu = false;

    void Start()
    {
        if (hideMenu) { this.gameObject.SetActive(false); }
    }
    public void ChangeScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        this.gameObject.SetActive(true);
    }
}
