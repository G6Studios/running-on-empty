using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public Objective[] objectives; // List of objectives

    private void Awake()
    {
        objectives = GameObject.FindObjectsOfType<Objective>(); // Get objectives active in scene
    }

    // Debug drawing
    private void OnGUI()
    {
        foreach(var objective in objectives)
        {
            objective.DrawUI();
        }
    }

    private void Update()
    {
        foreach(var objective in objectives) // For all active objectives
        {
            if(objective.IsCompleted() && objective.isActiveAndEnabled) // If objective has been completed
            {
                objective.OnCompleted(); // Give objective rewards
                objective.enabled = false;
            }
        }
    }

}
