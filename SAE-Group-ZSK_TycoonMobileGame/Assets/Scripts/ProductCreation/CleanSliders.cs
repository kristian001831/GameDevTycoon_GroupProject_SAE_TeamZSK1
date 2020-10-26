using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanSliders : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;

    void OnDisable()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = 0;
        }
    }
}
