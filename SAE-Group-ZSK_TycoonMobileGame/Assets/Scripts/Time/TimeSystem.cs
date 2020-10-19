using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

// Speed x1: 9sec = 1hour in game, Speed x2: 2sec = 1hour in game, speed x3: 1sec = 1hour in game
// Show Weekday, Days played, years played


public class TimeSystem : MonoBehaviour
{
    //TODO: when we add some effects popping up etc, we need to add Time.DeltaTime;
    
    // Days, Years Played
    private const string playerPrefNameDaysPlayedTotal = "DaysPlayedTotal";
    [SerializeField] private TextMeshProUGUI daysPlayedTotalText;
    
    private const string playerPrefNameTimeCurrentDay = "TimeCurrentDay";
    [SerializeField] private TextMeshProUGUI timeCurrentDayText;
    
    [ReadOnlyInInspector.ReadOnly][SerializeField] private float daysPlayedTotal;
    [ReadOnlyInInspector.ReadOnly][SerializeField] private float timeCurrentDay;
    
    [HideInInspector] public int TimeMultiplicator { get => timeMultiplicator; set => timeMultiplicator = value; }// Maybe delete later?

    [ReadOnlyInInspector.ReadOnly][SerializeField] private int timeMultiplicator;
    [SerializeField] private int currentTimeMultiplicator = 1;
    [ReadOnlyInInspector.ReadOnly][SerializeField] private bool coroutine = true; //can start coroutine?


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
        if(coroutine)
            TimePass(currentTimeMultiplicator);
        
        ShowTimeOnUI();
    }

    public void ChangeTimeMultiplicator(int voidTimeMultiplicator)
    {
        currentTimeMultiplicator = voidTimeMultiplicator;

        if (currentTimeMultiplicator == 0)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    private void TimePass(int multiplicator) // x0(pause), x1, x2, x3
    {
        StartCoroutine(OneMinuteRoutine(multiplicator));
    }

    void ShowTimeOnUI()
    {
        daysPlayedTotalText.SetText("{0} days played", daysPlayedTotal);
        timeCurrentDayText.SetText("{0}", timeCurrentDay);
    }
    
    IEnumerator OneMinuteRoutine(int _timeMultiplicator)
    {
        coroutine = false;
        float x = 0;// x seconds = 1 hour

        if (_timeMultiplicator == 0)
        {
            x = 0;
        }
        else if (_timeMultiplicator == 1)
        {
            x = 0.4f;
        }
        else if (_timeMultiplicator == 2)
        {
            x = 0.2f;
        }
        else if (_timeMultiplicator == 4)
        {
            x = 0.1f;
        }
            
        
        // Speed x1: 9sec = 1hour in game, Speed x2: 2sec = 1hour in game, speed x3: 1sec = 1hour in game
        yield return new WaitForSeconds(x); //Wait 1 ingame hour
        //Debug.Log("1 in game hour is over.");

        if (timeCurrentDay <= 23)
        {
            timeCurrentDay += 1;
        }
        else if (timeCurrentDay == 24)
        {
            daysPlayedTotal += 1;
            timeCurrentDay = 1;
        }

        coroutine = true;
    }
}
