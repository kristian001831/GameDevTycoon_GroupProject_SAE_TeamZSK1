using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabs : MonoBehaviour
{
    [SerializeField] GameObject open;
    [SerializeField] GameObject[] close;

    public void OpenPanel()
    {
        for (int i = 0; i < close.Length; i++)
        {
            if (close[i].active)
            {
                close[i].SetActive(false);
            }
        }

        open.SetActive(!open.active);
    }
}
