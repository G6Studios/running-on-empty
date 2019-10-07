using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakeCoffee : Objective
{
    bool coffeeMade = false;
    AudioSource slurp;

    // Start is called before the first frame update
    void Start()
    {
        slurp = GetComponent<AudioSource>();
    }

    public override bool IsCompleted()
    {
        return (coffeeMade == true);
    }

    public override void OnCompleted()
    {
        slurp.Play();
        GameObject.Find("GameManager").GetComponent<GameManager>().GivePlayerEnergy(25.0f);
        // Give player energy or something
    }

    public override void DrawUI()
    {
        getTextElement().GetComponent<TextMeshProUGUI>().text = "Coffee made: " + coffeeMade;
    }

    public void CoffeeMade()
    {
        coffeeMade = true;
    }

}
