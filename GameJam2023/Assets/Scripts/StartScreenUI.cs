using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;

    public void OnStartGame()
    {
        SceneManager.LoadScene("TobieTestScene");
    }

    public void OnOptions()
    {
        OptionsMenu.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnOptionsBack()
    {
        OptionsMenu.SetActive(false);
    }
}
