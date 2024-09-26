using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlling : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.3f; 
    private Rigidbody2D rb;
    private Vector2 targetVelocity;
    private Vector2 velocitySmoothing;
    private Vector3 lastTouchPosition; 
    private bool isFirstTouch = true;  

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButton(0)) 
        {
            Vector3 touchPos = Input.mousePosition; 
            Vector3 worldTouchPos = Camera.main.ScreenToWorldPoint(touchPos); 
            worldTouchPos.z = 0; 

            if (isFirstTouch || worldTouchPos != lastTouchPosition)
            {
                isFirstTouch = false; 
                lastTouchPosition = worldTouchPos; 
                if (worldTouchPos.x > transform.position.x) 
                {
                    targetVelocity = new Vector2(moveSpeed, rb.velocity.y); 
                }
                else if (worldTouchPos.x < transform.position.x)
                {
                    targetVelocity = new Vector2(-moveSpeed, rb.velocity.y); 
                }
            }
        }
        else
        {
            targetVelocity = new Vector2(0, rb.velocity.y);
            isFirstTouch = true;
        }

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmoothing, smoothTime);
    }
}
