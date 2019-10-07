using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SleepScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI sleepText; // Text element on victory screen
    string[] sleepMessage; // Pool of random victory messages

    // Start is called before the first frame update
    void Start()
    {
        // Defining victory messages
        sleepMessage = new string[4];
        sleepMessage[0] = "ZZZzzz...";
        sleepMessage[1] = "Just five more minutes...";
        sleepMessage[2] = "Too tired.";
        sleepMessage[3] = "Good night...";

        sleepText.text = sleepMessage[Random.Range(0, 4)]; // Selecting random victory message
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
