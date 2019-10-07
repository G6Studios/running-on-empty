using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI winText; // Text element on victory screen
    string[] victoryMessage; // Pool of random victory messages

    // Start is called before the first frame update
    void Start()
    {
        // Defining victory messages
        victoryMessage = new string[3];
        victoryMessage[0] = "Just in time...";
        victoryMessage[1] = "Another day, another dime.";
        victoryMessage[2] = "Made it!";

        winText.text = victoryMessage[Random.Range(0, 3)]; // Selecting random victory message
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
