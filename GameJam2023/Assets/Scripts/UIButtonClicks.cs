using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonClicks : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] TMP_Text amountGained1;
    [SerializeField] TMP_Text amountGained2;
    [SerializeField] TMP_Text amountGained3;
    [SerializeField] TMP_Text amountGained4;

    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] Button button3;
    [SerializeField] Button button4;
    [SerializeField] Button settingsButton;
    [SerializeField] Button settingsBackButton;

    [SerializeField] GameObject settingsMenu;

    [SerializeField] Economy economy;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void UpdateMoney(double money, TMP_Text moneyText)
    {
        moneyText.text = money.ToString();
    }

    public void OnButton1Click()
    {
        Debug.Log("Button1 clicked");

        economy.money += GetAmount(amountGained1.text);
        UpdateMoney(economy.money, moneyText);
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
        // get current button clicked
        // get AMOUNT in children
        // GetAmount()
        // compare to money
        // if money >= amount do the upgrade, subtract amount from money and update it

        var thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        var amountObject = GetChildWithName(thisButton, "AMOUNT");
        string s = amountObject.GetComponent<TMP_Text>().text;
        var amountNum = GetAmount(s);

        if (economy.money >= amountNum)
        {
            economy.money -= amountNum;
            UpdateMoney(economy.money, moneyText);
        }


        // increase upgrade amount
        amountNum *= 1.75;
        amountNum = Math.Round(amountNum, 2);
        amountObject.GetComponent<TMP_Text>().text = "$" + amountNum;
        
        // increase gain amount
        var parent = thisButton.GetComponentInParent<Image>();
        var backgroundSlider = GetChildWithName(parent.gameObject, "BackgroundSlider");
        var foregroundSlider = GetChildWithName(backgroundSlider, "ForegroundSlider");
        var amountGained = GetChildWithName(foregroundSlider, "AmountGained");
        var text = amountGained.GetComponent<TMP_Text>().text;

        var amountGainedNum = GetAmount(text);
        amountGainedNum *= 1.75;
        amountGainedNum = Math.Round(amountGainedNum, 2);
        amountGained.GetComponent<TMP_Text>().text = "$" + (amountGainedNum * 1.75);

        // get the num in the parent name, use that to figure out which slider to start
        var parentNum = GetNumInName(parent.name);

        switch  (parentNum) 
        {
            case 1:
                gameManager.sliderOn1 = true;
                break;
            case 2:
                gameManager.sliderOn2 = true;
                break;
            case 3:
                gameManager.sliderOn3 = true;
                break;
            case 4:
                gameManager.sliderOn4 = true;
                break;
            default:
                Debug.Log("Problem with getting num in parent name");
                break;
        }
    }

    public void OnUnlock()
    {
        // get current button clicked
        // get the amount from the text
        // compare to money
        // if enough, unlock it, disable this button, enabled buttons underneath and clicker button, subtract from money

        var thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        string s = thisButton.GetComponentInChildren<TMP_Text>().text;
        var amount = GetUnlockAmount(s);

        if (economy.money >= amount)
        {
            economy.money -= amount;
            UpdateMoney(economy.money, moneyText);
            thisButton.SetActive(false);

            var parent = thisButton.GetComponentInParent<Image>();
            var clicker = GetChildWithName(parent.gameObject, "Button");
            var upgrade = GetChildWithName(parent.gameObject, "UpgradeButton");
            var slider = GetChildWithName(parent.gameObject, "BackgroundSlider");

            clicker.GetComponent<Button>().interactable = true;
            upgrade.SetActive(true);
            slider.SetActive(true);
        }

    }

    public void OnSettings()
    {
        Debug.Log("Settings Clicked");

        settingsMenu.SetActive(true);
    }

    public void OnSettingsBack()
    {
        settingsMenu.SetActive(false);
    }

    // HELPERS
    public double GetAmount(string amountGained)
    {
        string amount = amountGained.Substring(1);        

        return Convert.ToDouble(amount);
    }

    public double GetUnlockAmount(string unlockAmount)
    {
        string amount = unlockAmount.Substring(10);

        return Convert.ToDouble(amount);
    }

    GameObject GetChildWithName(GameObject parent, string name)
    {
        Transform parentTrans = parent.transform;
        Transform childTrans = parentTrans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }

    int GetNumInName(string name)
    {
        string num = Regex.Replace(name, "[^0-9]", "");

        return Convert.ToInt32(num);
    }
}
