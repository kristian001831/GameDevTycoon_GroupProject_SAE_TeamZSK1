using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencyHandler : MonoBehaviour
{
    public float Currency { get; private set; } = 1000f;

    [SerializeField] private const string playerPrefNameCurrency = "SavedCurrency";
    [SerializeField] private TextMeshProUGUI currencyText;
    public delegate void ZSK_ChangeCurrency(float currency);
    public event ZSK_ChangeCurrency OnChangeCurrency;

    void Start()
    {
        // SavedCurrency is the value where the saved value is from, TODO: change it from playerprefs to json or so
        if (PlayerPrefs.HasKey(playerPrefNameCurrency))
        {
            Currency = PlayerPrefs.GetFloat(playerPrefNameCurrency);
        }
        
        currencyText.SetText("{0} $", Currency);
    }

    public void ModifyCurrency(float x)
    {
        Currency += x;
        
        Debug.Log("In Modified Currency");
        Debug.Log("Currency is: " + Currency);
        OnChangeCurrency?.Invoke(Currency);
        
        currencyText.SetText("{0} $", Currency);
    }

    public void SaveCurrency()
    {
        PlayerPrefs.SetFloat(playerPrefNameCurrency, Currency);
    }
}
