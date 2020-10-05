using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Profiling;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;
using System.Runtime.InteropServices.WindowsRuntime;

public class SalesCalculator : MonoBehaviour
{
    float price;
    float invest;

    public float Quality { get; set; } = 1;
    public float PriceOfProduct { get => price; set => value = _createProduct.ProductPrice; }

    public float PriceInvested { get => invest; set => value = _createProduct.ProductInvest; }

    public float MagnitudeOfQuality { get; set; } = 1;


    //public float TrendScaler { get => trendScaler; set => value = 1; }
    //public float PriceToPurchaseRateScaler { get => priceScaler; set => value = 1; }
    //public float InvestmentScaler { get => investmentScaler; set => value = 1; }
    //public float InterestFallOffScaler { get => interestFallOffScaler; set => value = 1; }

    [SerializeField] private TMP_InputField _daySinceRelease;
    [SerializeField] private Button _calculateCurrencyButton;

    [SerializeField] private CurrencyHandler _currencyHandler;
    [SerializeField] private CreateProduct _createProduct;

    private void Start()
    {
        _calculateCurrencyButton.onClick.AddListener(CalculateNewCurrency);
    }

    public void CalculateNewCurrency()
    {
        float days = float.Parse(_daySinceRelease.text);

        price = _createProduct.ProductPrice;
        invest = _createProduct.ProductInvest;

        float x = CopiesSoldByDayX(days);

        float calculateNewCurrency = (x * price) - invest;
        _currencyHandler.ModifyCurrency(calculateNewCurrency);
    }


    //clamp every function to 0


    public int CopiesSoldByDayX(float xDaysSinceRelease) //
    {
        float result = 1;
        result *= Mathf.Lerp(1, TrendFunction(xDaysSinceRelease), 1);

        result *= Mathf.Lerp(1, PriceToPurchase(Quality, PriceOfProduct), 1);

        result *= Mathf.Lerp(1, Investment(PriceInvested), 1);

        result *= Mathf.Lerp(1, InterestFalloff(xDaysSinceRelease, Quality, MagnitudeOfQuality), 1);

        return (int)result;
    }

    private float TrendFunction(float xDays)
    {
        //todo: create a gendre for g

        int a = 5;
        int b = 20;
        int c = 50;

        float trendValue = Mathf.Sin(xDays / a) + Mathf.Sin(xDays / b) + Mathf.Sin(xDays / c) + 1;


        return trendValue;

        // Trend(g, x) = sin(x / a) + sin(x / b) + sin(x / c) + 1 
    }


    private float PriceToPurchase(float q, float p)
    {
        float priceOfProduct = ((-1) * (Mathf.Sqrt(p * 0.2f)) + Mathf.Pow((1 + q), 2));

        return priceOfProduct;
        //Price(p, q) = -sqrt(p * 0.2) + (1 + q) ^ 2
    }


    private float Investment(float investment)
    {

        return ((-1) * (1 / investment) + 1);


        //A(i) = -1/i +1
    }

    private float InterestFalloff(float xDays, float q, float m)
    {
        float interestFallOff = (100 / xDays) + (q * m);

        return interestFallOff;
        // InterestFalloff(x) = 100/x + q*m
        // m is the magnitue of the quality
    }
    /*
     * F(x) = Trend(g,x) * PriceToPurchase(p,q) * Advertisement(i) * InterestFalloff(x,q)
     * 
     * F = Quantity sold on day x
     * F(0) = release day
     * q  = Quality (range 0-1)
     * p = Price 
     * x = days since release
     * i = money paid for ads
     * 
     * 
     * InterestFalloff(x) = 100/x + q*m
     * 
     * 
     * Trend(g,x) = sin(x/a) + sin(x/b) + sin(x/c) +1 
     * 
     * where a,b,c are random int >0
     * 
     * Price(p,q) = -sqrt(p*0.2) + (1+q)^2
     * 
     * 
     * 
     * 
     */
}