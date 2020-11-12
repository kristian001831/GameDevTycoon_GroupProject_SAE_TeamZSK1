using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPlayTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeDisplay;

    private string _seconds;
    private string _minutes;
    private string _hours;

    void FixedUpdate()
    {
        _seconds = ((int)(Time.time % 60)).ToString("D2");
        _minutes = ((int)(Time.time / 60)).ToString("D2");
        _timeDisplay.text = _minutes+":"+_seconds;
    }
}
