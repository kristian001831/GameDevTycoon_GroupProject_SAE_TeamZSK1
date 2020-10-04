using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    [SerializeField] GameObject _panel;

    public void Open()
    {
        if (!_panel.activeSelf)
        {
            _panel.SetActive(true);
        }
    }

    public void Close()
    {
        if (_panel.activeSelf)
        {
            _panel.SetActive(false);
        }
    }
}
