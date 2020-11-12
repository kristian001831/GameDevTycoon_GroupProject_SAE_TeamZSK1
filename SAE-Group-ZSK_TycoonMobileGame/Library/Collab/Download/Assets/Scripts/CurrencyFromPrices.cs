using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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


    [SerializeField] TextMeshProUGUI _productsSold;
    public int ProductsSold;

    private void Start()
    {
    }

    private void Update()
    {
       
        ChangeCurrencyWithProductPrices();     
        
    }

    private void ChangeCurrencyWithProductPrices()
    {
        if (_timeSystem.ChangedDay == true)
        {
            float price = _createProduct.ProductPrice;
            float invested = _createProduct.ProductInvest;

            _salesCalculator.PriceOfProduct = price;
            _salesCalculator.PriceInvested = invested;

            _salesCalculator.Quality = _attributeSet.qualityFromAttributes;


            if (_attributeSet.AttributesAreNowSet == true)
            {

                float xDays = _timeSystem.daysPlayedTotal - _product.DayCreated;


                foreach (var item in _productsHolder.Products)
                {
                    float _copiesSold = _salesCalculator.CopiesSoldByDayX(xDays);
                    float copiesSold = 1f;
                    //Debug.Log("copiesSold: " + copiesSold);


                    float totalMoneyMade = price * copiesSold;
                    //Debug.Log("totalMoney" + totalMoneyMade);
                    if (copiesSold > 0)
                    {
                        _currencyHandler.ModifyCurrency(totalMoneyMade);
                    }

                    ProductsSold += (int)copiesSold;
                    _productsSold.text = ProductsSold.ToString();
                }
            }
        }
    }
}
