using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public RectTransform slider;
    public Collider2D hitBox;
    public RectTransform backgroundBar;
    public float sliderSpeed;
    public bool? success = null; //nullable bool
   

    private Collider2D sliderHitBox;
    private bool forward = true;


    // Start is called before the first frame update
    void Start()
    {
        sliderHitBox = GetComponent<Collider2D>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(1, 0, 0);
        if (slider.position.x >= backgroundBar.sizeDelta.x)
            forward = false;
        else if(slider.position.x <= backgroundBar.position.x - backgroundBar.sizeDelta.x/2)
            forward = true;

        if(forward)
            slider.position += move * sliderSpeed * Time.fixedDeltaTime;
        else
            slider.position -= move * sliderSpeed * Time.fixedDeltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (sliderHitBox.IsTouching(hitBox))
            {
                Debug.Log("Successfully hit the hit box");
                success = true;
            }
            else
            {
                Debug.Log("Failed to hit hit box");
                success = false;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
    }

}
