using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Interactables
{
    Bread, Toaster, CoffeeMug, CoffeeMaker, Alarm, Razor, Toothbrush
};
public class InteractableObject : MonoBehaviour
{
    public bool pickup = false;
    public Interactables type;

    private GameObject player;
    private Sprite objectSprite;
    private GameObject inventoryUI;

    bool canPickUp;

    private void Awake()
    {
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
    }


    void pickUp()
    {
        if(pickup)
        {
            if(player.GetComponent<CharacterController2D>().inventory == null) //Cant pickup new item if inventory already full
            {
                player.GetComponent<CharacterController2D>().inventory = gameObject;
                Debug.Log(inventoryUI);
                inventoryUI.SetActive(true);
                GameObject.FindGameObjectWithTag("InventoryPicture").GetComponent<SpriteRenderer>().sprite = objectSprite;
                //GetComponentin<SpriteRenderer>().sprite = objectSprite;
                //disable sprite rendering of object here
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            canPickUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            canPickUp = false;
        }
    }


    private void Update()
    {
        if(canPickUp)
        {
            if (pickup)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    pickUp();
                }
            }
        }
    }


}
