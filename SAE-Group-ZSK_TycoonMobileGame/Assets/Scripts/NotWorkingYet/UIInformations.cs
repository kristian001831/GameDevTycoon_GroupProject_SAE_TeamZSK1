using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInformations : MonoBehaviour
{
    private CurrencyHandler currencyHandler = new CurrencyHandler();
    
    [SerializeField] private TextMeshProUGUI currencyText;

    void Start()
    {
        currencyText.SetText("Currency: {0} €", currencyHandler.Currency);
        
        currencyHandler.OnChangeCurrency += CurrencyDisplayChange;
    }

    void Update()
    {
        CurrencyDisplayChange(currencyHandler.Currency);
    }

    private void CurrencyDisplayChange(float currency)
    {
        currencyText.SetText("Currency: {0} €", currency);
    }
}
