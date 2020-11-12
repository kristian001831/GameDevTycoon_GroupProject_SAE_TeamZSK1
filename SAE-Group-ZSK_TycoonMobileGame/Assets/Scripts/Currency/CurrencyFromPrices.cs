using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyFromPrices : MonoBehaviour
{
    private SalesCalculator _salesCalculator = new SalesCalculator();

    [SerializeField] private CreateProduct _createProduct;
    [SerializeField] private AttributeSet _attributeSet;
    [SerializeField] private CurrencyHandler _currencyHandler;
    [SerializeField] private TimeSystem _timeSystem;
    [SerializeField] private ProductsHolder _productsHolder;
    [SerializeField] private Product _product;

    [SerializeField] private TextMeshProUGUI _currencyPerSec;
    private void Start()
    {
        _timeSystem.NewDay += ChangeCurrencyWithProductPrices;
        _currencyPerSec.SetText("{0}/s $", 0f);
    }

    private void ChangeCurrencyWithProductPrices()
    {

        if (_attributeSet.AttributesAreNowSet == true)
        {


            _salesCalculator.Quality = _attributeSet.qualityFromAttributes;
            float xDays = _timeSystem.daysPlayedTotal /*- _product.DayCreated*/;



            for (int i = 0; i <= _createProduct.TotalPrices.Count - 1; i++)
            {
                if (_createProduct.TotalPrices.Count < 0)
                    return;

                _salesCalculator.PriceOfProduct = _createProduct.TotalPrices[i];
                _salesCalculator.PriceInvested = _createProduct.TotalInvested[i];

                float _copiesSold = _salesCalculator.CopiesSoldByDayX(xDays);
                float moneyMadeFromCopies = _createProduct.TotalPrices[i] * _copiesSold;


                _currencyPerSec.SetText(moneyMadeFromCopies.ToString("F", CultureInfo.InvariantCulture) + "/s $" );


                if (_copiesSold > 0)
                {
                    _currencyHandler.ModifyCurrency(moneyMadeFromCopies);
                }
            }
        }

    }
}
