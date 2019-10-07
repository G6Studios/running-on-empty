using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float boltTimer; // Timer for spawning new energy bolts
    private float boltSpawnTime; // What the timer must reach before a new bolt spawns

    [SerializeField]
    private GameObject boltPrefab; // Lightning bolt prefab

    [SerializeField]
    public CharacterController2D player; // Player in scene (set in editor)

    public float gameTimer; // Timer for game
    public float startTime = 450f;
    public float maxTime = 540f; // As high as the timer should go

    public bool gracePeriod; // Prevents the game from starting until the player has turned off their alarm clock

    public bool exit; // Toggles if the player can exit the level or not

    public bool fellAsleep;

    public Animator introText; // Animator for intro text
    public bool introTextFaded = false; // Had intro text faded

    public Animator tutorialText; // Animator for tutorial text

    // Start is called before the first frame update
    void Awake()
    {
        boltSpawnTime = 3.0f; // A new bolt spawns every 3 seconds
        gameTimer = startTime;
        exit = false;
        fellAsleep = false;
        gracePeriod = true;
        introText.Play("IntroTextFadeIn");
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBolts(); // Function for spawning bolts for player

        ClickBolts(); // Function for clicking on lightning bolts

        if(gracePeriod == false)
        {
            Mathf.Clamp(gameTimer += Time.deltaTime, startTime, maxTime); // Incrementing time with deltatime
            if(introTextFaded == false)
            {
                introText.Play("IntroTextFadeOut");
                introTextFaded = true;
                tutorialText.SetTrigger("Tutorial");
            }
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            GivePlayerEnergy(50f);
        }
        
        if(gameTimer > maxTime)
        {
            TimeUp();
        }

        if(fellAsleep == true)
        {
            FellAsleep();
        }

        if(exit == true)
        {
            Victory();
        }
    }


    private void SpawnBolts()
    {
        if(Time.timeScale > 0) // If the game is not paused
        {
            if(gracePeriod == false)
            {
                boltTimer += Time.unscaledDeltaTime; // Increment timer

                if (boltTimer > boltSpawnTime) // If timer is valid
                {
                    Vector3 randomPos = new Vector3(Random.Range(-7.7f, 7.7f), Random.Range(-3.5f, 3.5f)); // Create new random spawn position

                    Instantiate(boltPrefab, randomPos, Quaternion.identity); // Spawn a bolt at the randomized position

                    boltTimer = 0.0f; // Reset timer
                }
            }
            
        }

    }

    private void ClickBolts()
    {
        if(Time.timeScale > 0f) // If the game is not paused
        {
            if (Input.GetMouseButtonDown(0)) // On left mouse click
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Getting mouse position in world
                RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, new Vector2(0, 0), 0.01f); // Raycasting through all layers

                for (int i = 0; i < hits.Length; i++) // For everything hit by the ray
                {
                    if (hits[i].collider.tag == "Lightning") // We only want lightning bolts
                    {
                        var temp = hits[i].collider.gameObject; // Temp variable to reduce typing
                        temp.GetComponent<AudioSource>().Play(); // Play lightning pickup sound
                        temp.GetComponent<PolygonCollider2D>().enabled = false; // Disable collider on bolt
                        temp.GetComponent<SpriteRenderer>().enabled = false; // Disable sprite renderer on bolt
                        GivePlayerEnergy(5.0f); // Give player energy
                        Destroy(temp, 1.0f); // Destroy bolt after 1 second
                    }
                }
            }
        }
    }

    public void GivePlayerEnergy(float energy)
    {
        player.energy = Mathf.Clamp(player.energy + energy, 0.0f, 100f); // Prevents the player's energy from going over 100 when getting energy

    }

    private void TimeUp() // When the player runs out of time
    {
        SceneManager.LoadScene("Game Over(Late)");
    }

    private void FellAsleep()
    {
        SceneManager.LoadScene("Game Over(Sleep)");
    }

    private void Victory() // When the player wins
    {
        SceneManager.LoadScene("Victory");
    }
}
