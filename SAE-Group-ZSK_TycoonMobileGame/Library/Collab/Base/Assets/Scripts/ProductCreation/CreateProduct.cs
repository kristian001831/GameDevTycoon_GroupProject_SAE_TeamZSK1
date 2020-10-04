using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Security.Cryptography;
using System.Collections.Specialized;

public class CreateProduct : MonoBehaviour
{
    [SerializeField] private GameObject _createObjectUI;
    [SerializeField] private RectTransform _addButton;
    [SerializeField] private ProductsHolder _list;
    [SerializeField] private GameObject _productPrefab;

    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMPro.TMP_Dropdown _genre;
    [SerializeField] private TMP_InputField _price;
    [SerializeField] private TMP_InputField _invest;

    private Product _productInfo;
    private RectTransform _display;

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
        }
        else
        {
            _productInfo.Price = 0.0f;
        }

        if (float.TryParse(_invest.text, out _productInfo.InvestedAmount))
        {
            _productInfo.InvestedAmount = float.Parse(_invest.text);
            double tempI = (double)Math.Round(_productInfo.InvestedAmount, 2);
            _productInfo.InvestedAmount = (float)tempI;
        }
        else
        {
            _productInfo.InvestedAmount = 0.0f;
        }

        _list.Products.Add(obj);
        obj.transform.parent = _list.gameObject.transform;

        obj.transform.position = new Vector3(_list.gameObject.transform.position.x, _list.gameObject.transform.position.y, _list.gameObject.transform.position.z);
        obj.transform.eulerAngles = new Vector3(_list.gameObject.transform.eulerAngles.x, _list.gameObject.transform.eulerAngles.y, _list.gameObject.transform.eulerAngles.z);
        obj.transform.localScale = new Vector3(1, 1, 1);

        _display = obj.GetComponentInChildren<RectTransform>();
        _display.localPosition = new Vector3(0, 250 - 440 * (_list.Products.Count - 1), _display.localPosition.z);

        _addButton.localPosition = new Vector3(-600, 380 - 440 * _list.Products.Count, _addButton.localPosition.z);

        _createObjectUI.SetActive(false);
    }
}
