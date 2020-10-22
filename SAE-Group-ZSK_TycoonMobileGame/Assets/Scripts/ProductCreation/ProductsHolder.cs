using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductsHolder : MonoBehaviour
{


    private List<GameObject> _products = new List<GameObject>();

    public List<GameObject> Products { get => _products; private set => _products = value; }
    

    public void AddProduct(GameObject go)
    {
        Products.Add(go);
    }
  
}
