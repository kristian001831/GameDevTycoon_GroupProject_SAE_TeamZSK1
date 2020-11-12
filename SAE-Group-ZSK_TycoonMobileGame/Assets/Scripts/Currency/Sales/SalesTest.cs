using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalesTest : MonoBehaviour
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
                totalSold += Mathf.Max(0, copiesSold);
            }
        }

        Debug.Assert(totalSold == 0, "Test Failed, sold more then 0 copies -> " + totalSold);
    }



}
