using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Runtime.InteropServices;

public class CreateProduct : MonoBehaviour
{

    [SerializeField] private GameObject _createObjectUI;
    [SerializeField] private GameObject _productPrefab;
    [SerializeField] private Transform _productsParent;
    [SerializeField] private ProductsHolder _list;
    [SerializeField] private RectTransform _addButton;
    [SerializeField] private RectTransform _container;
    [SerializeField] private GameObject _nextPanel;

    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMPro.TMP_Dropdown _genre;
    [SerializeField] private TMP_InputField _price;
    [SerializeField] private TMP_InputField _invest;

    private CurrencyHandler currencyHandler;

    private Product _productInfo;
    private RectTransform _display;
    public float ProductPrice;
    public float ProductInvest;

    void Start()
    {
        currencyHandler = FindObjectOfType<CurrencyHandler>();
        Debug.Log(currencyHandler);
    }

    public void CreateAProduct()
    {
        GameObject obj = Instantiate(_productPrefab);
        obj.name = _name.text;

        _productInfo = obj.GetComponent<Product>();
        _productInfo.Name = _name.text;
        _productInfo.Genre = (Product.EGenre)_genre.value;

        if (float.TryParse(_price.text, out _productInfo.Price))
        {
            _productInfo.Price = float.Parse(_price.text);
            double tempP = (double)Math.Round(_productInfo.Price, 2);
            _productInfo.Price = (float)tempP;
            ProductPrice = (float)tempP;
        }
        else
        {
            _productInfo.Price = 0.0f;
            ProductPrice = 0.0f;
        }

        if (float.TryParse(_invest.text, out _productInfo.InvestedAmount))
        {
            _productInfo.InvestedAmount = float.Parse(_invest.text);
            double tempI = (double)Math.Round(_productInfo.InvestedAmount, 2);
            _productInfo.InvestedAmount = (float)tempI;

            ProductInvest = (float)tempI;

            currencyHandler.ModifyCurrency(-_productInfo.InvestedAmount);
        }
        else
        {
            _productInfo.InvestedAmount = 0.0f;
            ProductInvest = 0.0f;
        }

        _list.Products.Add(obj);
        obj.transform.parent = _productsParent;

        obj.transform.position = new Vector3(_productsParent.position.x, _productsParent.position.y, _productsParent.position.z);
        obj.transform.eulerAngles = new Vector3(_productsParent.eulerAngles.x, _productsParent.eulerAngles.y, _productsParent.eulerAngles.z);
        obj.transform.localScale = new Vector3(1, 1, 1);

        _display = obj.GetComponentInChildren<RectTransform>();
        _display.localPosition = new Vector3(0, 250 - 440 * (_list.Products.Count - 1), 0);

        _container.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 960 + (_list.Products.Count - 1) * 440);

        for (int i = 0; i < _list.Products.Count; i++)
        {
            _list.Products[i].GetComponentInChildren<RectTransform>().localPosition = new Vector3(0, 250 - 440 * i + (_list.Products.Count - 1) * 220, 0);
        }

        _addButton.localPosition = new Vector3(-600, _list.Products[_list.Products.Count - 1].GetComponentInChildren<RectTransform>().localPosition.y - 300, 0);

        obj.SetActive(false);
        _nextPanel.SetActive(true);
        _createObjectUI.SetActive(false);
    }
}