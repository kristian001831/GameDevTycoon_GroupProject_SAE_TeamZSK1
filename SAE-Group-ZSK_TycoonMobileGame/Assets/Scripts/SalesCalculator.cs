using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Profiling;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.PlayerLoop;

public class SalesCalculator : MonoBehaviour
{
    float price;
    float invest;
    float trendScaler;
    float priceScaler;
    float investmentScaler;
    float interestFallOffScaler;
    float qualityMagnitude;

    public float Quality { get; set; }
    public float PriceOfProduct { get => price; set => price = value; }

    public float PriceInvested { get => invest; set => invest = value; }

    public float MagnitudeOfQuality { get => qualityMagnitude; set => value = 1; }

    //ask luca to look over the properties.
    public float TrendScaler { get => trendScaler; set => value = 1; }
    public float PriceToPurchaseRateScaler { get => priceScaler; set => value = 1; }
    public float InvestmentScaler { get => investmentScaler; set => value = 1; }
    public float InterestFallOffScaler { get => interestFallOffScaler; set => value = 1; }

    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;
    [SerializeField] private CurrencyHandler _currency;



    private void Update() 
    {
        ChangeCurrency();
    }

    private void ChangeCurrency()
    {
        float xDays = _timeSystem.daysPlayedTotal;

        float copiesSold = CopiesSoldByDayX(xDays);
        float totalMoneyMade = _product.Price * copiesSold;

        _currency.ModifyCurrency(totalMoneyMade);



        //foreach (var item in _productsHolder.Products)
        //{
        //}
    }
        


    public int CopiesSoldByDayX(float xDaysSinceRelease) //
    {
        float result = 1;
        result *= Mathf.Clamp(  Mathf.Lerp(1, TrendFunction(xDaysSinceRelease), 1),     0f, 1f);

        result *= Mathf.Clamp(  Mathf.Lerp(1, PriceToPurchase(Quality, PriceOfProduct), 1),  0f, 1f);

        result *= Mathf.Clamp(  Mathf.Lerp(1, Investment(PriceInvested), 1),     0f,1f);

        result *= Mathf.Clamp(  Mathf.Lerp(1, InterestFalloff(xDaysSinceRelease, Quality, MagnitudeOfQuality), 1),   0f, 1f);
       
        return (int) result;
    }


    public override string ToString()
    {
        return "SalesCalculator(" + Quality + ", " + PriceOfProduct + ", " + PriceInvested + ", " + MagnitudeOfQuality + ")";
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
}