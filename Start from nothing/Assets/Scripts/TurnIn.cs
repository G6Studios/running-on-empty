using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIn : MonoBehaviour
{
    private bool pickup;
    private Interactables objectType;
    Collider2D player; // To hold player collider between functions
    // Start is called before the first frame update
    void Start()
    {
        pickup = GetComponent<InteractableObject>().pickup;
        objectType = GetComponent<InteractableObject>().type;
    }

    bool canTurnIn;

    // Update is called once per frame
    void Update()
    {
        if(canTurnIn)
        {
            TurnInItem(player);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            canTurnIn = true;
            player = collision;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            canTurnIn = false;
            player = collision;
        }
    }

    private void TurnInItem(Collider2D col)
    {
        if (!pickup)
        {
            if (col.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (col.gameObject.GetComponent<CharacterController2D>().inventory == null)
                    {
                        if (objectType == Interactables.Alarm)
                        {
                            Debug.Log("Completed Alarm objective");
                            GetComponent<AlarmClock>().TurnOffAlarm();
                            return;
                            // complete alarm objective here
                        }

                        else if(objectType == Interactables.Razor)
                        {
                            Debug.Log("Completed shaving objective");
                            GetComponent<Shave>().Shaved();
                            return;
                        }

                        else if(objectType == Interactables.Toothbrush)
                        {
                            Debug.Log("Completed brush teeth objective");
                            GetComponent<BrushTeeth>().TeethBrushed();
                            return;
                        }

                        else
                        {
                            Debug.Log("No item in inventory");
                            return;
                        }
                    }
                    switch (objectType)
                    {
                        case Interactables.Toaster:
                            if (col.gameObject.GetComponent<CharacterController2D>().inventory.GetComponent<InteractableObject>().type ==
                            Interactables.Bread)
                            {
                                Debug.Log("Completed Toaster Objective");
                                col.gameObject.GetComponent<CharacterController2D>().removeFromInv();
                                GetComponent<MakeBreakfast>().BreakfastMade();
                                //complete toaster objective here
                            }
                            else
                                Debug.Log("Missing item required/incorrect item used");
                            break;
                        case Interactables.CoffeeMaker:
                            if (col.gameObject.GetComponent<CharacterController2D>().inventory.GetComponent<InteractableObject>().type ==
                            Interactables.CoffeeMug)
                            {
                                Debug.Log("Completed Coffee Objective");
                                col.gameObject.GetComponent<CharacterController2D>().removeFromInv();
                                GetComponent<MakeCoffee>().CoffeeMade();
                                //complete coffeemaker objective here
                            }
                            else
                                Debug.Log("Missing item required/incorrect item used");
                            break;
                        default:
                            Debug.Log("Not holding an object");
                            break;
                    }

                }
            }
        }
    }


}
