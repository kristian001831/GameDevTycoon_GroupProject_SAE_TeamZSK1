using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.Profiling;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.VersionControl;
using System.Runtime.InteropServices.WindowsRuntime;


public class SalesTests
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void RunTests()
    {
        Debug.Log("Running Calculator Tests");
        TestNoNegativeSales();
        TestNoSalesOnCrazyPrice();
    }

    public static void TestNoNegativeSales()
    {
        SalesCalculator calculator = new SalesCalculator();

        for (int i = 0; i < 1000; i++)
        {
            calculator.Quality = Random.Range(0f, 1f);
            calculator.PriceOfProduct = Random.Range(0f, 100f);
            calculator.PriceInvested = Random.Range(0f, 100000f);
            calculator.MagnitudeOfQuality = Random.Range(0f, 10f);
            int day = Random.Range(0, 100);

            float result = calculator.CopiesSoldByDayX(day);

            Debug.Assert(result >= 0, "Calculor calculated negative sales for " + calculator.ToString() + " at day " + day + " Value: " + result);
            if (result < 0)
                return;
        }
    }

    public static void TestNoSalesOnCrazyPrice()
    {
        SalesCalculator calculator = new SalesCalculator();

        calculator.PriceOfProduct = 10000;
        float totalSold = 0;

        for (int i = 0; i < 50; i++)
        {
            calculator.Quality = Random.Range(0f, 1f);
            calculator.PriceInvested = Random.Range(0, 100000);
            calculator.MagnitudeOfQuality = Random.Range(0f, 1f);

            for (int d = 0; d < 100; d++)
            {
                var copiesSold = calculator.CopiesSoldByDayX(d);
                totalSold +=  Mathf.Max(0,copiesSold);
            }
        }

        Debug.Assert(totalSold == 0, "Test Failed, sold more then 0 copies -> " + totalSold);
    }


}

public class SalesCalculator 
{
    float price;
    float invest;

    public float Quality { get; set; } = 1;
    public float PriceOfProduct { get => price; set => price = value; }

    public float PriceInvested { get => invest; set => invest = value; }

    public float MagnitudeOfQuality { get; set; } = 1;


    //public float TrendScaler { get => trendScaler; set => value = 1; }
    //public float PriceToPurchaseRateScaler { get => priceScaler; set => value = 1; }
    //public float InvestmentScaler { get => investmentScaler; set => value = 1; }
    //public float InterestFallOffScaler { get => interestFallOffScaler; set => value = 1; }

    private void Start()
    {
    }


    //clamp every function to 0


    public int CopiesSoldByDayX(float xDaysSinceRelease) //
    {
        float result = 1;
        result *= Mathf.Lerp(1, TrendFunction(xDaysSinceRelease), 1);

        result *= Mathf.Lerp(1, PriceToPurchase(Quality, PriceOfProduct), 1);

        result *= Mathf.Lerp(1, Investment(PriceInvested), 1);

        result *= Mathf.Lerp(1, InterestFalloff(xDaysSinceRelease, Quality, MagnitudeOfQuality), 1);

        return (int) Mathf.Max(0,result);
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