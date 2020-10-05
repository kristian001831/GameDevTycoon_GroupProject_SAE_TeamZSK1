using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SaleTests1 : MonoBehaviour
{
    private SalesCalculator salesCalculator = new SalesCalculator();

    [Range(0,1)]
    [SerializeField] private float qualityTest;

    [Range(0,100)]
    [SerializeField] private float priceOfProdductTest;

    [Range(0,500)]
    [SerializeField] private float priceOfAdsTest;

    [Range(0,1)]
    [SerializeField] private float magnitudeOfQualityTest;

    [SerializeField] private bool paidForAdsTest;


    [SerializeField] int maxDay;
    [SerializeField] float xScale;
    [SerializeField] float yScale;
    [SerializeField] float stepsInGraph;

    [Range(0,1)]
    [SerializeField] float trendScalerTest;
    [Range(0, 1)]
    [SerializeField] float priceToPurchaseRateScalerTest;
    [Range(0, 1)]
    [SerializeField] float advertisementScalerTest;
    [Range(0, 1)]
    [SerializeField] float interestFallOffScalerTest;


    //void Update()
    //{
    //    salesCalculator.Quality = qualityTest;
    //    salesCalculator.PriceOfAdds = priceOfAdsTest;
    //    salesCalculator.PriceOfProduct = priceOfProdductTest;
    //    salesCalculator.MagnitudeOfQuality = magnitudeOfQualityTest;
    //    salesCalculator.PaidForAds = paidForAdsTest;

    //    salesCalculator.TrendScaler = trendScalerTest;
    //    salesCalculator.PriceToPurchaseRateScaler = priceToPurchaseRateScalerTest;
    //    salesCalculator.AdvertisementScaler = advertisementScalerTest;
    //    salesCalculator.InterestFallOffScaler = interestFallOffScalerTest;

       
    //}


    private void OnDrawGizmos()//graph drawing
    {
        if (salesCalculator == null)
            return;

        //Debug.Log(salesCalculator.CopiesSoldByDayX(1));
        
        for (float i = 0; i < stepsInGraph-1; i++)
        {

            float x1 = (i / stepsInGraph) * maxDay; // small steps on x axis
            float y1 = salesCalculator.CopiesSoldByDayX(x1);//scaler for y axis

            float x2 = ((i+1) / stepsInGraph) * maxDay; 
            float y2 = salesCalculator.CopiesSoldByDayX(x2);

            Gizmos.DrawLine(new Vector3(x1 * xScale, y1 *yScale, 0),new Vector3(x2*xScale, y2* yScale,0 ));
        }
        
    }

}
