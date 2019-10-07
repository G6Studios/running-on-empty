using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AlarmClock : Objective
{
    bool turnOffAlarm = false;
    AudioSource beep;

    // Start is called before the first frame update
    void Start()
    {
        beep = GetComponent<AudioSource>();
        beep.Play();
    }

    public override bool IsCompleted()
    {
        return (turnOffAlarm == true);
    }

    public override void OnCompleted()
    {
        beep.Stop();
        GameObject.Find("GameManager").GetComponent<GameManager>().GivePlayerEnergy(25.0f);
        GameObject.Find("GameManager").GetComponent<GameManager>().gracePeriod = false;
    }

    public override void DrawUI()
    {
        getTextElement().GetComponent<TextMeshProUGUI>().text = "Alarm silenced: " + turnOffAlarm;
    }

    public void TurnOffAlarm()
    {
        turnOffAlarm = true;
    }


}
