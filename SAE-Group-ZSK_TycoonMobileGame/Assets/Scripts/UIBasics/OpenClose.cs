using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _playerStats;
    [SerializeField] private bool _hidePlayerStats;

    public void Open()
    {
        if (!_panel.activeSelf)
        {
            _panel.SetActive(true);
            if (_hidePlayerStats)
            {
                _playerStats.SetActive(false);
            }
        }
    }

    public void Close()
    {
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
            if (_hidePlayerStats)
            {
                _playerStats.SetActive(true);
            }
        }
    }
}