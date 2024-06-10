using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
public class CurrentSystem : MonoBehaviour
{
    private static Dictionary<CurrencyType, int> CurrencyAmounts = new Dictionary<CurrencyType, int>();

    [SerializeField] private List<GameObject> texts;

    private Dictionary<CurrencyType, TextMeshProUGUI> currencyTexts = new Dictionary<CurrencyType, TextMeshProUGUI>();

    private void Awake()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            CurrencyAmounts.Add((CurrencyType)i, 0);
            currencyTexts.Add((CurrencyType)i, texts[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>());
        }
    }


    private void Start()
    {
        CurrencyAmounts[CurrencyType.Coins] = 100;
        CurrencyAmounts[CurrencyType.Crystals] = 10;
        UpdateUI();
        EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
        EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnough);
    }

    private void UpdateUI()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            currencyTexts[(CurrencyType)i].text = CurrencyAmounts[(CurrencyType)i].ToString();
        }
    }

    private void OnCurrencyChange(CurrencyChangeGameEvent info)
    {

        if (info.amount < 0)
        {
            if (CurrencyAmounts[info.currencyType] < Math.Abs(info.amount))
            {
                EventManager.Instance.QueueEvent(new NotEnoughCurrencyGameEvent(info.amount, info.currencyType));
                return;
            }

            EventManager.Instance.QueueEvent(new EnoughCurrencyGameEvent());
        }

        CurrencyAmounts[info.currencyType] += info.amount;
        UpdateUI();
    }


    private void OnNotEnough(NotEnoughCurrencyGameEvent info)
    {
        Debug.Log($"You don't have enough of {info.amount} {info.currencyType}");
    }
}




public enum CurrencyType
{
    Coins,
    Crystals
}



