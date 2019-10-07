using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBolt : MonoBehaviour
{
    AudioSource audioSource; // Audio source for object
    PolygonCollider2D polyCollider; // Polygon collider for object
    SpriteRenderer spriteRenderer; // Spriterenderer for object

    GameManager gameManager;

    private void Start()
    {
        // Assigning components from gameobject
        audioSource = GetComponent<AudioSource>();
        polyCollider = GetComponent<PolygonCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


}
