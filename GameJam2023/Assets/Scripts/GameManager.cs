using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image foreground1;
    [SerializeField] Image foreground2;
    [SerializeField] Image foreground3;
    [SerializeField] Image foreground4;

    [SerializeField] TMP_Text amountGained1;
    [SerializeField] TMP_Text amountGained2;
    [SerializeField] TMP_Text amountGained3;
    [SerializeField] TMP_Text amountGained4;
    [SerializeField] TMP_Text moneyText;

    public bool sliderOn1 = false;
    public bool sliderOn2 = false;
    public bool sliderOn3 = false;
    public bool sliderOn4 = false;

    public double money = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        float multiplier;

        if (sliderOn1)
        {
            multiplier = GetMultiplier(amountGained1);
            UpdateSlider(foreground1, amountGained1, multiplier);
        }

        if (sliderOn2)
        {
            multiplier = GetMultiplier(amountGained2);
            UpdateSlider(foreground2, amountGained2, multiplier);
        }

        if (sliderOn3)
        {
            multiplier = GetMultiplier(amountGained3);
            UpdateSlider(foreground3, amountGained3, multiplier);
        }

        if (sliderOn4)
        {
            multiplier = GetMultiplier(amountGained4);
            UpdateSlider(foreground4, amountGained4, multiplier);
        }
    }

    // HELPERS
    public void UpdateMoney(double money, TMP_Text moneyText)
    {
        money = Math.Round(money, 2);
        moneyText.text = money.ToString();
    }

    public void UpdateMoney(string money, TMP_Text moneyText)
    {
        moneyText.text = money;
    }

    public double GetAmount(string amountGained)
    {
        string amount = amountGained.Substring(1);

        return Convert.ToDouble(amount);
    }

    public void UpdateSlider(Image foreground, TMP_Text amountGained, float moneyMultiplier, float timeMultiplier = 1)
    {
        if (foreground.fillAmount < 1)
        {
            foreground.fillAmount += Time.deltaTime * timeMultiplier;
        }
        else
        {
            money += GetAmount(amountGained.text) * moneyMultiplier;
            SetMoney(money, moneyText);
            foreground.fillAmount = 0;
        }
    }

    public float GetMultiplier(TMP_Text amountGained)
    {
        double num = GetAmount(amountGained.text);
        float multiplier;

        if (num < 150)
        {
            multiplier = 1.75f;
        }
        else if (num < 500)
        {
            multiplier = 1.6f;
        }
        else if (num < 1500)
        {
            multiplier = 1.45f;
        }
        else if (num < 3000)
        {
            multiplier = 1.2f;
        }
        else multiplier = 1.05f;

        return multiplier;
    }

    // CURRENTLY DOESN'T WORK CORRECTLY
    public void SetMoney(double money, TMP_Text text)
    {
        string moneyString = "";

        if (money % 1000 <= 999)
        {
            UpdateMoney(money, text);
            return;
        }
        else if (money % 1000 >= 999999) // 1 thousand
        {
            money /= 1000;
            moneyString += money + " K";
        }
        else if (money % 1000000 > 999999999) // 1 million
        {
            money /= 1000000;
            moneyString += money + " M";
        }
        else if (money % 1000000000 > 999999999999) // 1 billion
        {
            money /= 1000000000;
            moneyString += money + " B";
        }
        else if (money % 1000000000000 > 999999999999999) // 1 trillion
        {
            money /= 1000000000;
            moneyString += money + " T";
        }

        Math.Round(money, 2);
        UpdateMoney(moneyString, text);
    }
}
