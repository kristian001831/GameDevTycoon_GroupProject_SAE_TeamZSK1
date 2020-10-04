using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Unity.Profiling;
using UnityEngine;


public class SalesCalculator
{
    public float Quality { get; set; }
    public float PriceOfProduct { get; set; }
    public float PriceOfAdds { get; set; }
    public float MagnitudeOfQuality { get; set; }
    public bool  PaidForAds { get; set; }

    public float TrendScaler { get; set; }
    public float PriceToPurchaseRateScaler { get; set; }
    public float AdvertisementScaler { get; set; }
    public float InterestFallOffScaler { get; set; }


    //clamp every function to 0


    public float CopiesSoldByDayX(float xDaysSinceRelease) //
    {
        float result = 1;

        result *= Mathf.Lerp(1,TrendFunction(xDaysSinceRelease),TrendScaler);

        result *= Mathf.Lerp(1,PriceToPurchase(Quality, PriceOfProduct),PriceToPurchaseRateScaler);

        result *= Mathf.Lerp(1,Advertisement(PriceOfAdds, PaidForAds),AdvertisementScaler);
       // UnityEngine.Debug.Log(result);

        result *= Mathf.Lerp(1,InterestFalloff(xDaysSinceRelease, Quality, MagnitudeOfQuality),InterestFallOffScaler);

  
        return result;
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


    private float Advertisement(float adsPrice, bool paidForAdds)
    {
        
        if (paidForAdds == true)
        {
           return ((-1) * (1 / adsPrice) + 1);
        }
        else
        {
           return  1;
        }

        //A(i) = -1/i +1
    }

    private float InterestFalloff(float xDays, float q, float m)
    {
        float interestFallOff = ((100 / xDays) + (q * m));

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
