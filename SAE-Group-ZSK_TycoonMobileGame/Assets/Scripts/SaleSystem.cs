using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaleSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
     * Trend(g,x) = sin(x/a) + sin(x/b) + sin(x/c) +1 1
     * 
     * where a,b,c are random int >0
     * 
     * Price(p,q) = -sqrt(p*0.2) + (1+q)^2
     * 
     * A(i) = -1/i + 1
     * 
     * 
     */
}
