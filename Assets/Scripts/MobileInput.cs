using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    private const float DEADZONE = 50.0f;
    public static MobileInput Instance { set; get; }

    private bool tap, swipeLeft, swipeRight;
    private Vector2 swipeDelta, startTouch;

    public bool Tap { get { return tap; } }
    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        // Reseting all the booleans
        tap = swipeLeft = swipeRight = false;

        // Checking for Input

        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            startTouch = swipeDelta = Vector2.zero;
        }
        #endregion

        #region Mobile Inputs
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                startTouch = swipeDelta = Vector2.zero;
            }
        }
        #endregion

        // Calculate distance
        swipeDelta = Vector2.zero;
        if (startTouch != Vector2.zero)
        {
            // Check with mobile
            if (Input.touches.Length != 0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            // Check with standalone
            else if (Input.GetMouseButton(0))
            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        // Check if we're beyond the deadzone
        if (swipeDelta.magnitude > DEADZONE)
        {
            // This is a confirmed swipe
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                // Left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }

            startTouch = swipeDelta = Vector2.zero;
        }
    }
}
