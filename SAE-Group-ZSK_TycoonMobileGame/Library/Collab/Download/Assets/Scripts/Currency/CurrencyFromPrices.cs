using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyFromPrices : MonoBehaviour
{
    private SalesCalculator _salesCalculator = new SalesCalculator();

    [SerializeField] private CreateProduct _createProduct;
    [SerializeField] private AttributeSet _attributeSet;
    [SerializeField] private CurrencyHandler _currencyHandler;
    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;

    private void Start()
    {
        _timeSystem.NewDay += ChangeCurrencyWithProductPrices;
    }

    private void ChangeCurrencyWithProductPrices()
    {
        float price = _createProduct.ProductPrice;
        float invested = _createProduct.ProductInvest;

        _salesCalculator.PriceOfProduct = price;
        _salesCalculator.PriceInvested = invested;

        _salesCalculator.Quality = _attributeSet.qualityFromAttributes;


        if (_attributeSet.AttributesAreNowSet == true)
        {

            float xDays = _timeSystem.daysPlayedTotal /*- _product.DayCreated*/;

            Debug.Log("Total Count is: " + _product.TotalPrices[0]);
            //foreach (var product in _product.TotalPrices)
            for (int i = 0; i <= _product.TotalPrices.Count - 1; i++)
            {

                float _copiesSold = _salesCalculator.CopiesSoldByDayX(xDays);
                Debug.Log("copiesSold: " + _copiesSold);

                float totalMoneyMade = /*_product.TotalPrices[i] **/ _copiesSold;
                Debug.Log("totalMoney: " + totalMoneyMade);
                if (_copiesSold > 0)
                {
                    _currencyHandler.ModifyCurrency(totalMoneyMade);
                }
            }
        }

    }
}
