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

    [SerializeField] private SalesCalculator _salesCalculator = new SalesCalculator();

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


    public void CalculateQuality(Product product)
    {


        //for more random values
        //float x1 = Random.Range(0.01f, 26f); // has the least priority
        //float x2 = Random.Range(26f, 51f);   //has medium priority
        //float x3 = Random.Range(51f, 76f);   //has high priority
        //float x4 = Random.Range(76f, 101f);  // most important priority
        
        


        float[] attributesArr = new float[7] { product.GamePlay, product.Graphics, product.Dialogue, product.GameDesign, product.Ai, product.Audio, product.WorldDesign };

        float[] goodAdventureAttributes = new float[7] { 25f, 30f, 60f, 80f, 40f, 10f, 40f }; // most important is the Dialog and the GameDesign

        float[] goodFPSAttributes = new float[7] { 80f, 60f, 10f, 40f, 30f, 70f, 30f };

        float[] goodHorrorAttributes = new float[7] { 40f, 50f, 70f, 75f, 10f, 75f, 50f };

        float[] goodPlatformerAttributes = new float[7] { 50f, 60f, 40f, 50f, 65f, 50f, 70f };

        float[] goodRPGAttributes = new float[7] { 80f, 60f, 90f, 80f, 60f, 50f, 70f };

        float[] goodSimulationAttributes = new float[7] { 60f, 50f, 70f, 80f, 99f, 60f, 50f };

        float[] goodSportsAttributes = new float[7] { 90f, 70f, 50f, 70f, 60f, 50f, 30f };


        //float[][] jaggedArray = new float[][] { goodAdventureAttributes, goodFPSAttributes, goodHorrorAttributes, goodPlatformerAttributes, goodRPGAttributes, goodSimulationAttributes, goodSportsAttributes };

        //jaggedArray[0] = new float[7] { 25f, 30f, 60f, 80f, 40f, 10f, 40f };
        //jaggedArray[1] = new float[7] { 80f, 60f, 10f, 40f, 30f, 70f, 30f };
        //jaggedArray[2] = new float[7] { 40f, 50f, 70f, 75f, 10f, 75f, 50f };
        //jaggedArray[3] = new float[7] { 50f, 60f, 40f, 50f, 65f, 50f, 70f };
        //jaggedArray[4] = new float[7] { 80f, 60f, 90f, 80f, 60f, 50f, 70f };
        //jaggedArray[5] = new float[7] { 60f, 50f, 70f, 80f, 99f, 60f, 50f };
        //jaggedArray[6] = new float[7] { 90f, 70f, 50f, 70f, 60f, 50f, 30f };

        float qualityFromAttributes = 1;

        switch (product.Genre)
        {

            case Product.EGenre.Adventure:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodAdventureAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.FPS:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodFPSAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.Horror:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodHorrorAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.Platformer:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodPlatformerAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.RPG:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodRPGAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.Simulation:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodSimulationAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;

            case Product.EGenre.Sports:
                for (int i = 0; i < attributesArr.Length; i++)
                {
                    if (attributesArr[i] < goodSportsAttributes[i])
                    {
                        qualityFromAttributes -= 0.14f;
                    }

                }

                UnityEngine.Debug.Log("Quality value:" + qualityFromAttributes);

                product.QualityOfTheProduct = qualityFromAttributes;
                _salesCalculator.Quality = qualityFromAttributes;
                break;
            default:
                break;
        } 
    }

    //private void CalculateQualityFuntion()
    //{

    //    for (int i = 0; i < jaggedArray.Length - 1; i++)
    //    {
    //        if (attributesArr[i] <= jaggedArray[i][i])
    //        {
    //            qualityFromAttributes -= 0.14f;
    //        }

    //    }
    //}
}
