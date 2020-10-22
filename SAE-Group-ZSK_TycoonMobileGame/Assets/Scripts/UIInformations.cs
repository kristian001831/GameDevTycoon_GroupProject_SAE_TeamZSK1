using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIInformations : MonoBehaviour
{
    public TextMeshProUGUI InfoTextField;
    [SerializeField] private GameObject infoTextObj;

    void Start()
    {
        // currencyText.SetText("Currency: {0} €", currencyHandler.Currency);
        
        // currencyHandler.OnChangeCurrency += CurrencyDisplayChange;

        infoTextObj.SetActive(false);
    }

    void Update()
    {
        // CurrencyDisplayChange(currencyHandler.Currency);
    }

    // private void CurrencyDisplayChange(float currency)
    // {
    //     // currencyText.SetText("Currency: {0} €", currency);
    // }

    public void ShowHint(string info)
    {
        infoTextObj.SetActive(true);
        InfoTextField.text = info;
        StartCoroutine(ShowTextShort());
    }

    IEnumerator ShowTextShort() 
    {
        yield return new WaitForSeconds(1f);
        infoTextObj.SetActive(false);
    }
}
