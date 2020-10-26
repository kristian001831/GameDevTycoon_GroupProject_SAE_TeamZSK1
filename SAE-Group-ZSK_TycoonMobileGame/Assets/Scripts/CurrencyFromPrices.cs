using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyFromPrices : MonoBehaviour
{
    private SalesCalculator _salesCalculator = new SalesCalculator();


    //_salesCalculator.Quality = product.QualityOfTheProduct;
    [SerializeField] private CreateProduct _createProduct;
    [SerializeField] private AttributeSet _attributeSet;
    [SerializeField] private CurrencyHandler _currencyHandler;
    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;

    private void Start()
    {
        _createProduct = GetComponent<CreateProduct>();
    }

    private void FixedUpdate()
    {
        while (_timeSystem.coroutine)
        {
            ChangeCurrencyWithProductPrices();     
        }
    }

    private void ChangeCurrencyWithProductPrices()
    {
        _attributeSet.AttributesAreSet();
       
        _salesCalculator.PriceOfProduct = _createProduct.ProductPrice;
        _salesCalculator.PriceInvested = _createProduct.ProductInvest;

       _salesCalculator.Quality = _attributeSet.qualityFromAttributes;


        if (_attributeSet.AttributesAreNowSet == true)
        {
            Debug.Log("stepped into if"  );

            float xDays = _timeSystem.daysPlayedTotal - _product.DayCreated;

            Debug.Log("xDays" + xDays );

            foreach (var item in _productsHolder.Products)
            {
                float copiesSold = _salesCalculator.CopiesSoldByDayX(xDays);

                Debug.Log("copiesSold: " + copiesSold);


                float totalMoneyMade = _product.Price * copiesSold;
                Debug.Log("totalMoney" + totalMoneyMade);
                if (copiesSold > 0)
                {
                    _currencyHandler.ModifyCurrency(totalMoneyMade);
                }
            }
        }
    }
}
