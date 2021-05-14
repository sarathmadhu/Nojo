using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    private bool tap, swipeUp, swipeDown, swipeLeft, swipeRight;
    public bool isDragging;
    private Vector2 startTouch, swipeDelta;


    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    



    public void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;

    }

    private void Update()
    {
        tap = swipeUp = swipeDown = swipeLeft = swipeRight = false;

        #region PC

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            startTouch = Input.mousePosition;
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
            isDragging = false;

        }

        #endregion

        #region Mobile

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDragging = true;
                tap = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended|| Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDragging = false;
                Reset();
            }
        }

        #endregion


        //Calculating Distance
        if(isDragging)
        {
            if(Input.touches.Length>0)
            {
                swipeDelta = Input.touches[0].position - startTouch;
            }
            else if(Input.GetMouseButtonDown(0))

            {
                swipeDelta = (Vector2)Input.mousePosition - startTouch;
            }
        }

        //calculating Direction
        if(swipeDelta.magnitude>75)
        {
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if(Mathf.Abs(x)>Mathf.Abs(y))
            {


                if(x>0f)
                {
                    //right
                    swipeRight = true;
                }
                else
                {
                    //left
                    swipeLeft = true;
                }
            }
            else if (Mathf.Abs(y) > Mathf.Abs(x))
            {


                if (y > 0f)
                {
                    //up
                    swipeUp = true;
                }
                else
                {
                    //Down
                    swipeDown = true;
                }
            }
            Reset();
        }

    }
}
