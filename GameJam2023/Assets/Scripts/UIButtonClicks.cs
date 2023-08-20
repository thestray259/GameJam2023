using System;
using System.Collections;
using System.Collections.Generic;
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
        // else do nothing

        var thisButton = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;

        var amountObject = GetChildWithName(thisButton, "AMOUNT");
        string s = amountObject.GetComponent<TMP_Text>().text;
        var amountNum = GetAmount(s);

        if (economy.money >= amountNum)
        {
            economy.money -= amountNum;
            UpdateMoney(economy.money, moneyText);
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

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }


}
