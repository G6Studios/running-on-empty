using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LateScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI lateText; // Text element on victory screen
    string[] lateMessage; // Pool of random victory messages

    // Start is called before the first frame update
    void Start()
    {
        // Defining victory messages
        lateMessage = new string[5];
        lateMessage[0] = "Almost made it..";
        lateMessage[1] = "Boss isn't gonna be happy.";
        lateMessage[2] = "A shame close doesn't count.";
        lateMessage[3] = "It won't happen again, I swear!";
        lateMessage[4] = "You're fired!";

        lateText.text = lateMessage[Random.Range(0, 5)]; // Selecting random victory message
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
