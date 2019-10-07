using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // TextMeshPro library

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Slider energyMeter; // Player's energy bar

    [SerializeField]
    TextMeshProUGUI timerText;

    public GameObject objectiveList; // Reference to objective list
    public GameObject textPrefab; // Text prefab

    GameManager gameManager; // Game manager reference
    ObjectiveManager objectiveManager; // Objective manager reference

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        objectiveManager = GameObject.Find("ObjectiveManager").GetComponent<ObjectiveManager>();
        ListObjectives();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateEnergy(); // Update the player's energy bar
        FormatTime(); // Update and format the time remaining
    }

    private void UpdateEnergy()
    {
        energyMeter.value = gameManager.player.energy / gameManager.player.maxEnergy; // Divides players energy by max energy to get a value between 0 and 1 for slider
    }

    private void ListObjectives()
    {
        for(int i = 0; i < objectiveManager.objectives.Length; i++)
        {
            objectiveManager.objectives[i].setTextElement(Instantiate(textPrefab, objectiveList.transform));   
        }
    }

    private void FormatTime()
    {
        if(gameManager.gameTimer > gameManager.maxTime) // If time goes above 9 minutes
        {
            timerText.text = string.Format("{0:0}:{1:00am}", 9, 0);
        }
        else
        {
            int minutes = Mathf.FloorToInt(gameManager.gameTimer / 60f); // Minutes remaining
            int seconds = Mathf.FloorToInt(gameManager.gameTimer - minutes * 60); // Seconds remaining
            string niceTime = string.Format("{0:0}:{1:00am}", minutes, seconds); // Formatting timer
            timerText.text = niceTime; // Updating UI element
        }
        
    }
}
