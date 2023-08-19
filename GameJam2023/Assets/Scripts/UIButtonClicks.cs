using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonClicks : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button settingsButton;
    [SerializeField] Button settingsBackButton;

    private Economy economy;

    public void UpdateMoney(double money, TMP_Text moneyText)
    {
        moneyText.text = money.ToString();
    }

    public void OnButton1Click()
    {
        Debug.Log("Button1 clicked");
    }

    public void OnButton2Click()
    {
        Debug.Log("Button2 clicked");
    }

    public void OnButton3Click()
    {
        Debug.Log("Button3 clicked");
    }

    public void OnButton4Click()
    {
        Debug.Log("Button4 clicked");
    }

    public void OnUpgrade()
    {
        Debug.Log("Upgrade Clicked");
    }

    public void OnSettings()
    {
        Debug.Log("Settings Clicked");
    }
}
