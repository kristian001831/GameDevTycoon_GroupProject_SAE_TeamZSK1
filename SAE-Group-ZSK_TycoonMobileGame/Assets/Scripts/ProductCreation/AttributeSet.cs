using System;
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

    public bool AttributesAreNowSet = false;
    public float qualityFromAttributes = 0;

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
       
        CalculateQuality(productInfo);

        AttributesAreNowSet = true;
    }


    public void CalculateQuality(Product product)
    {


        float[] playerAttributes = new float[7] { product.GamePlay, product.Graphics, product.Dialogue, product.GameDesign, product.Ai, product.Audio, product.WorldDesign };

        float[] goodAdventureAttributes = new float[7] { 25f, 30f, 60f, 80f, 40f, 10f, 40f };

        float[] goodFPSAttributes = new float[7] { 80f, 60f, 10f, 40f, 30f, 70f, 30f };

        float[] goodHorrorAttributes = new float[7] { 40f, 50f, 70f, 75f, 10f, 75f, 50f };

        float[] goodPlatformerAttributes = new float[7] { 50f, 60f, 40f, 50f, 65f, 50f, 70f };

        float[] goodRPGAttributes = new float[7] { 80f, 60f, 90f, 80f, 60f, 50f, 70f };

        float[] goodSimulationAttributes = new float[7] { 60f, 50f, 70f, 80f, 99f, 60f, 50f };

        float[] goodSportsAttributes = new float[7] { 90f, 70f, 50f, 70f, 60f, 50f, 30f };


        //  float[][] jaggedArray = new float[][] { goodAdventureAttributes, goodFPSAttributes, goodHorrorAttributes, goodPlatformerAttributes, goodRPGAttributes, goodSimulationAttributes, goodSportsAttributes };

        //jaggedArray[0] = new float[7] { 25f, 30f, 60f, 80f, 40f, 10f, 40f };
        //jaggedArray[1] = new float[7] { 80f, 60f, 10f, 40f, 30f, 70f, 30f };
        //jaggedArray[2] = new float[7] { 40f, 50f, 70f, 75f, 10f, 75f, 50f };
        //jaggedArray[3] = new float[7] { 50f, 60f, 40f, 50f, 65f, 50f, 70f };
        //jaggedArray[4] = new float[7] { 80f, 60f, 90f, 80f, 60f, 50f, 70f };
        //jaggedArray[5] = new float[7] { 60f, 50f, 70f, 80f, 99f, 60f, 50f };
        //jaggedArray[6] = new float[7] { 90f, 70f, 50f, 70f, 60f, 50f, 30f };

        qualityFromAttributes = 0;

        switch (product.Genre)
        {

            case Product.EGenre.Adventure:
                qualityFromAttributes = CalculateQualityFuntion(goodAdventureAttributes, playerAttributes);
                break;

            case Product.EGenre.FPS:
                qualityFromAttributes = CalculateQualityFuntion(goodFPSAttributes, playerAttributes);

                break;

            case Product.EGenre.Horror:
                qualityFromAttributes = CalculateQualityFuntion(goodHorrorAttributes, playerAttributes);

                break;

            case Product.EGenre.Platformer:
                qualityFromAttributes = CalculateQualityFuntion(goodPlatformerAttributes, playerAttributes);

                break;

            case Product.EGenre.RPG:
                qualityFromAttributes = CalculateQualityFuntion(goodRPGAttributes, playerAttributes);

                break;

            case Product.EGenre.Simulation:
                qualityFromAttributes = CalculateQualityFuntion(goodSimulationAttributes, playerAttributes);

                break;

            case Product.EGenre.Sports:
                qualityFromAttributes = CalculateQualityFuntion(goodSportsAttributes, playerAttributes);

                break;

            default:
                break;
        }


        product.QualityOfTheProduct = qualityFromAttributes;
    }

    private float CalculateQualityFuntion(float[] goodAttributes, float[] playerAttributes)
    {
        qualityFromAttributes = 1;

        for (int i = 0; i < playerAttributes.Length; i++)
        {
            if (playerAttributes[i] < goodAttributes[i])
            {
                qualityFromAttributes -= 0.14f;
            }
        }

        return qualityFromAttributes;

    }
}
