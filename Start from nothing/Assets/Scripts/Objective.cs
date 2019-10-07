using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Objective : MonoBehaviour
{
    GameObject textElement;
    public void setTextElement(GameObject text) // Setting which text element will represent the text element
    {
        textElement = text;
    }

    public GameObject getTextElement() // Getting the text element that represents it
    {
        return textElement;
    }

    public abstract bool IsCompleted(); // Condition(s) for completing the objective
    public abstract void OnCompleted(); // What happens when an objective is completed
    public abstract void DrawUI(); // Drawing function

}
