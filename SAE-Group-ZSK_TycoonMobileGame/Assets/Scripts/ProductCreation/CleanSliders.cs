using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleanSliders : MonoBehaviour
{
    [SerializeField] private Slider[] _sliders;

    [SerializeField] float maxResources;


    private void Start()
    {
        foreach (var slider in _sliders)
        {
            slider.onValueChanged.AddListener(UpdateSliders);
        }
    }

    private void UpdateSliders(float arg0)
    {
        float sum = 0;

        foreach (var slider in _sliders)
        {
            sum += slider.value;
        }

        if(sum > maxResources)
        {
            float multiplyer = maxResources / sum;

            foreach (var slider in _sliders)
            {
                slider.SetValueWithoutNotify(slider.value * multiplyer);

                var image = slider.transform.GetChild(0).GetComponent<Image>();
                image.color = slider.value < 33 ? Color.red : slider.value < 66 ? Color.yellow : Color.green;
            }
        }
    }

    void OnDisable()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].value = 0;
        }
    }
}
