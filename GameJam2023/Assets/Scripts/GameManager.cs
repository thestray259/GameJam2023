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
        if (sliderOn1)
        {
            if (foreground1.fillAmount < 1)
            {
                foreground1.fillAmount += Time.deltaTime;
            }
            else
            {
                money += GetAmount(amountGained1.text);
                UpdateMoney(money, moneyText);
                foreground1.fillAmount = 0;
            }
        }

        if (sliderOn2)
        {
            if (foreground2.fillAmount < 1)
            {
                foreground2.fillAmount += Time.deltaTime;
            }
            else
            {
                money += GetAmount(amountGained2.text);
                UpdateMoney(money, moneyText);
                foreground2.fillAmount = 0;
            }
        }

        if (sliderOn3)
        {
            if (foreground3.fillAmount < 1)
            {
                foreground3.fillAmount += Time.deltaTime;
            }
            else
            {
                money += GetAmount(amountGained3.text);
                UpdateMoney(money, moneyText);
                foreground3.fillAmount = 0;
            }
        }

        if (sliderOn4)
        {
            if (foreground4.fillAmount < 1)
            {
                foreground4.fillAmount += Time.deltaTime;
            }
            else
            {
                money += GetAmount(amountGained4.text);
                UpdateMoney(money, moneyText);
                foreground4.fillAmount = 0;
            }
        }
    }


    public void UpdateMoney(double money, TMP_Text moneyText)
    {
        money = Math.Round(money, 2);
        moneyText.text = money.ToString();
    }

    public double GetAmount(string amountGained)
    {
        string amount = amountGained.Substring(1);

        return Convert.ToDouble(amount);
    }
}
