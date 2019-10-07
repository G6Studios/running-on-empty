using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrushTeeth : Objective
{
    bool teethBrushed = false;
    AudioSource toothbrush;

    // Start is called before the first frame update
    void Start()
    {
        toothbrush = GetComponent<AudioSource>();
    }

    public override bool IsCompleted()
    {
        return (teethBrushed == true);
    }

    public override void OnCompleted()
    {
        toothbrush.Play();
        GameObject.Find("GameManager").GetComponent<GameManager>().GivePlayerEnergy(10.0f);
        // Give player energy or something
    }

    public override void DrawUI()
    {
        getTextElement().GetComponent<TextMeshProUGUI>().text = "Teeth brushed: " + teethBrushed;
    }

    public void TeethBrushed()
    {
        teethBrushed = true;
    }
}
