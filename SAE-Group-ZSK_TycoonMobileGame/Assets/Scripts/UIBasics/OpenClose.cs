using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private bool _hidePlayerStats;

    private GameObject _playerStats;

    void Awake()
    {
        _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
    }

    public void Open()
    {
        if (!_panel.activeSelf)
        {
            _panel.SetActive(true);
            if (_hidePlayerStats)
            {
                if (_playerStats == null)
                {
                    _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
                }
                _playerStats.SetActive(false);
            }
        }
    }

    public void Close()
    {
        if (_panel.activeSelf)
        {
            if (_hidePlayerStats)
            {
                if (_playerStats == null)
                {
                    _playerStats = GameObject.FindGameObjectWithTag("PlayerStats");
                }
                _playerStats.SetActive(true);
            }
            _panel.SetActive(false);
        }
    }
}