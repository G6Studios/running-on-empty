using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeBreakfast : Objective
{
    bool breakfastMade = false; // Boolean that changes when breakfast has been made
    AudioSource crunch;

    private void Start()
    {
        crunch = GetComponent<AudioSource>();
    }

    public override bool IsCompleted()
    {
        return (breakfastMade == true); // Objective is completed when boolean is true
    }

    public override void OnCompleted()
    {
        crunch.Play();
        GameObject.Find("GameManager").GetComponent<GameManager>().GivePlayerEnergy(15.0f);
        // Give the player energy or something
    }

    public override void DrawUI()
    {
        getTextElement().GetComponent<TextMeshProUGUI>().text = "Breakfast made: " + breakfastMade;
    }

    public void BreakfastMade() // Wrapper for breakfastmade boolean
    {
        breakfastMade = true;
    }

}
