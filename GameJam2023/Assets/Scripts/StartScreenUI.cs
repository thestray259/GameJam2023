using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenUI : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;
    private AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = GameObject.Find("AudioPlayer").GetComponent<AudioPlayer>();
    }

    public void OnStartGame()
    {
        audioPlayer.playAudio("MenuButtons");
        SceneManager.LoadScene("TobieTestScene");
    }

    public void OnOptions()
    {
        audioPlayer.playAudio("MenuButtons");
        OptionsMenu.SetActive(true);
    }

    public void OnQuit()
    {
        audioPlayer.playAudio("MenuButtons");
        Application.Quit();
    }

    public void OnOptionsBack()
    {
        audioPlayer.playAudio("MenuButtons");
        OptionsMenu.SetActive(false);
    }

    public void OnMasterVolumeChanged()
    {
        var thisSlider = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
        var value = thisSlider.GetComponent<Slider>().value;

        audioPlayer.SetMaster(value);
    }
}
