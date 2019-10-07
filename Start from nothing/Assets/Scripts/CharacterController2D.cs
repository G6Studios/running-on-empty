using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum charState
{
    Awake, Asleep
};

public class CharacterController2D : MonoBehaviour
{
    public float speed; // Player speed
    public float energy; // Player energy
    public float maxEnergy = 100f; // Maximum energy the player can have at any time
    public GameObject inventory;

    private float energyTimer; // Timer for draining player's energy
    private float energyDrainTime; // How long before the player's energy is drained once
    private GameObject inventoryUI;

    [SerializeField]
    private GameObject sleeping; // ZZZs for when player is sleeping

    public charState playerState; // State for player being awake or asleep

    GameManager gameManager;


    private Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerState = charState.Asleep;
        energy = 0.0f; // Player starts with 0 energy
        energyDrainTime = 0.3f; // Energy drains every x seconds
        playerPos = GetComponent<Transform>();
        inventory = null;
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
        inventoryUI.SetActive(false);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void FixedUpdate()
    {

        playerMovement();
    }

    private void Update()
    {
        CheckPlayerState();
        DrainEnergy();
    }

    private void CheckPlayerState()
    {
        if (energy <= 0f) // If the player has no energy and the grace period has expired
        {
            if (gameManager.gracePeriod == false)
            {
                gameManager.fellAsleep = true;
            }

            playerState = charState.Asleep; // They fall asleep
            sleeping.SetActive(true);
        }

        else
        {
            playerState = charState.Awake;
            sleeping.SetActive(false);
        }
    }

    private void playerMovement()
    {
        if(playerState.Equals(charState.Awake))
        {
            float horizontalMovement = Input.GetAxisRaw("Horizontal");


            Vector3 position = new Vector3(horizontalMovement, 0, 0);
            Vector3 movement = position.normalized * speed * Time.fixedDeltaTime;
            transform.Translate(movement);
            DrainEnergy();
        }
        
    }

    private void DrainEnergy()
    {
        if(Time.timeScale > 0f) // If the game is not paused
        {
            energyTimer += Time.unscaledDeltaTime; // Increment energytimer

            // If player's energy is above 0 and timer is above value
            if (energy > 0f && energyTimer > energyDrainTime)
            {
                energy -= 0.3f; // Reduce player's energy by time value
                energyTimer = 0f; // Reset timer value to 0
            }
        }
    }

    public void removeFromInv()
    {

        if (inventory != null)
        {
            //use object
            inventory = null;
            inventoryUI.SetActive(false);
        }

    }
}
