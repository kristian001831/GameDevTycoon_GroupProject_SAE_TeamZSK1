using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyHandler : MonoBehaviour
{
    public float Currency { get; private set;}
    [SerializeField] private const string playerPrefNameCurrency = "SavedCurrency";

    public delegate void ZSK_ChangeCurrency(float currency);
    public event ZSK_ChangeCurrency OnChangeCurrency;

    void Start()
    {
        //TODO: Debug, delete after that
        Currency = 1000f;
        
        // SavedCurrency is the value where the saved value is from, TODO: change it from playerprefs to json or so
        if (PlayerPrefs.HasKey(playerPrefNameCurrency))
        {
            Currency = PlayerPrefs.GetFloat(playerPrefNameCurrency);
        }
    }

    public void ModifyCurrency(float x)
    {
        Currency += x;
        
        Debug.Log("In Modified Currency");

        OnChangeCurrency?.Invoke(Currency);
    }

    public void SaveCurrency()
    {
        PlayerPrefs.SetFloat(playerPrefNameCurrency, Currency);
    }
}
