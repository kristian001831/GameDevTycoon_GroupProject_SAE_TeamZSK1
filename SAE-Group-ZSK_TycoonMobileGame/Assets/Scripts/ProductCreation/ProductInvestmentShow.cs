using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ProductInvestmentShow : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;

    private Product _product;

    void Awake()
    {
        _product = GetComponentInParent<Product>();
    }

    void Start()
    {
        _sliders[0].value = _product.GamePlay;
        _sliders[1].value = _product.Graphics;
        _sliders[2].value = _product.Dialogue;
        _sliders[3].value = _product.GameDesign;
        _sliders[4].value = _product.Ai;
        _sliders[5].value = _product.Audio;
        _sliders[6].value = _product.WorldDesign;
    }
}
