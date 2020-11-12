using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using TMPro;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CurrencyHandler : MonoBehaviour
{
    public float Currency { get; private set; } = 1000f;

    [SerializeField] private const string playerPrefNameCurrency = "SavedCurrency";
    [SerializeField] private TextMeshProUGUI currencyText;
    public delegate void ZSK_ChangeCurrency(float currency);
    public event ZSK_ChangeCurrency OnChangeCurrency;


    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;
    [SerializeField] private AttributeSet _attributeSet;





    void Start()
    {
        // SavedCurrency is the value where the saved value is from, TODO: change it from playerprefs to json or so
        if (PlayerPrefs.HasKey(playerPrefNameCurrency))
        {
            Currency = PlayerPrefs.GetFloat(playerPrefNameCurrency);
        }

      //  currencyText.SetText("{0} $", Currency);
        currencyText.SetText(Currency.ToString("F", CultureInfo.InvariantCulture) + " $");



    }

    public void ModifyCurrency(float x)
    {
        Currency += x;

        //Debug.Log("In Modified Currency");
        //Debug.Log("Currency is: " + Currency);
        OnChangeCurrency?.Invoke(Currency);

        //currencyText.SetText("{0} $", Currency);
        currencyText.SetText(Currency.ToString("F", CultureInfo.InvariantCulture) + " $");
    }

    public void SaveCurrency()
    {
        PlayerPrefs.SetFloat(playerPrefNameCurrency, Currency);
    }

}
