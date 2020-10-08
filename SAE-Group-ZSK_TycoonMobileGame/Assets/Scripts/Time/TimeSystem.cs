using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// Speed x1: 9sec = 1hour in game, Speed x2: 2sec = 1hour in game, speed x3: 1sec = 1hour in game
// Show Weekday, Days played, years played


public class TimeSystem : MonoBehaviour
{
    // Days, Years Played
    private const string playerPrefNameDaysPlayedTotal = "DaysPlayedTotal";
    [SerializeField] private TextMeshProUGUI daysPlayedTotalText;
    
    private const string playerPrefNameTimeCurrentDay = "TimeCurrentDay";
    [SerializeField] private TextMeshProUGUI timeCurrentDayText;
    
    [ReadOnlyInInspector.ReadOnly][SerializeField] private float daysPlayedTotal;

    [ReadOnlyInInspector.ReadOnly][SerializeField] private float timeCurrentDay;

    [ReadOnlyInInspector.ReadOnly][SerializeField] private int timeMultiplicator;
    [HideInInspector] public int TimeMultiplicator { get => timeMultiplicator; set => timeMultiplicator = value; }// Maybe delete later?

    [ReadOnlyInInspector.ReadOnly][SerializeField] private int currentTimeMultiplicator;


    void Start()
    {
        
        // SavedTimePlayed is the value where the saved value is from, TODO: change it from playerprefs to json or so
        if (PlayerPrefs.HasKey(playerPrefNameDaysPlayedTotal))
        {
            daysPlayedTotal = PlayerPrefs.GetFloat(playerPrefNameTimeCurrentDay);
            timeCurrentDay = PlayerPrefs.GetFloat(playerPrefNameTimeCurrentDay);
        }
        daysPlayedTotalText.SetText("{0} ", daysPlayedTotal);
        timeCurrentDayText.SetText("{0}");
    }

    void FixedUpdate()
    {
        TimePase(timeMultiplicator);
    }

    public void ChangeTimeMultiplicator(int timeMultiplicator)
    {
        
    }

    private void TimePase(int multiplicator) // x0(pause), x1, x2, x3
    {
        StartCoroutine(IOneMinute(multiplicator));
        
        
    }
    
    IEnumerator IOneMinute(int timeMultiplicator) 
    {
        yield return new WaitForSecondsRealtime(timeMultiplicator); //Wait 1 ingame min
        Debug.Log("1 in game min is over.");
    }
}
