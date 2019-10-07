using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shave : Objective
{
    bool shaved = false;
    AudioSource razor;

    // Start is called before the first frame update
    void Start()
    {
        razor = GetComponent<AudioSource>();
    }

    public override bool IsCompleted()
    {
        return (shaved == true);
    }

    public override void OnCompleted()
    {
        razor.Play();
        GameObject.Find("GameManager").GetComponent<GameManager>().GivePlayerEnergy(5.0f);
        // Give player energy or something
    }

    public override void DrawUI()
    {
        getTextElement().GetComponent<TextMeshProUGUI>().text = "Shaved: " + shaved;
    }

    public void Shaved()
    {
        shaved = true;
    }
}
