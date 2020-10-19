using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class AttributeSet : MonoBehaviour
{
    [SerializeField] private ProductsHolder _list;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Slider[] _sliders;
    [SerializeField] private GameObject _playerStats;

    public void AttributesAreSet()
    {
        GameObject product = _list.Products[_list.Products.Count - 1];
        Product productInfo = product.GetComponent<Product>();

        productInfo.GamePlay = _sliders[0].value;
        productInfo.Graphics = _sliders[1].value;
        productInfo.Dialogue = _sliders[2].value;
        productInfo.GameDesign = _sliders[3].value;
        productInfo.Ai = _sliders[4].value;
        productInfo.Audio = _sliders[5].value;
        productInfo.WorldDesign = _sliders[6].value;

        product.SetActive(true);
        _playerStats.SetActive(true);
        _panel.SetActive(false);
    }
}
