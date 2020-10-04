using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInformations : MonoBehaviour
{
    private CurrencyHandler currencyHandler = new CurrencyHandler();

    void Start()
    {
        TextMeshPro textMeshPro = GetComponent<TextMeshPro>();
        textMeshPro.SetText("Currency: {0} €", currencyHandler.Currency);
        
        currencyHandler.OnChangeCurrency += CurrencyDisplayChange;
    }

    private void CurrencyDisplayChange(float currency)
    {
        if (currency <= 0)
        {
            
        }
    }
}
