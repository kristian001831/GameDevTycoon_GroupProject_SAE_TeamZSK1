using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaySetup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name;
    [SerializeField] TextMeshProUGUI _genre;
    [SerializeField] TextMeshProUGUI _price;

    private Product _productInfo;

    void Awake()
    {
        _productInfo = GetComponent<Product>();
    }

    void Start()
    {
        _name.SetText(_productInfo.Name);
        _genre.SetText(_productInfo.Genre.ToString());
        _price.SetText(_productInfo.Price.ToString());
    }
}
