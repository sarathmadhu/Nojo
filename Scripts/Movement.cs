using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [System.Serializable]
    public enum  Path { farLeft,Left,Mid,Right,farRight}

    public Path cSide =Path.Mid;

    public Swipe swipeController;

    public SpawnManager spawn_Manager;
   
    public float newPos;
    private float far_Value = 6f;
    private float absolute_Value = 2.5f;
    private float x;
    private float Forward_Speed = 50f;


    private int state;
    private bool isGrounded=true;

    public Animator animator;

    public CharacterController main_Controller;




    public void Start()
    {

        
        main_Controller = GetComponent<CharacterController>();
        
        newPos = 0f;
    }
    private void Update()
    {
        
        

        if (swipeController.SwipeLeft)
        {
            if (cSide == Path.Mid)
            {
                newPos = -absolute_Value;
                cSide = Path.Left;

            }
            else if (cSide == Path.Left)
            {
                newPos = -far_Value;
                cSide = Path.farLeft;
            }
            else if (cSide == Path.farRight)
            {
                newPos = absolute_Value;
                cSide = Path.Right;
            }

            else if (cSide == Path.Right)
            {
                newPos = 0f;
                cSide = Path.Mid;
            }
            state = 1;
            AnimationControl(state);
            
        }
        if (swipeController.SwipeRight)
        {
            if (cSide == Path.Mid  )
            {
                newPos = absolute_Value;
                cSide = Path.Right;

            }
            else if(cSide == Path.Right)
            {
                newPos = far_Value;
                cSide = Path.farRight;
            }
            else if (cSide == Path.farLeft)
            {
                newPos = -absolute_Value;
                cSide = Path.Left;
            }
            else if (cSide == Path.Left)
            {
                newPos = 0f;
                cSide = Path.Mid;
            }
            state = -1;
            AnimationControl(state);


        }
        if(swipeController.SwipeDown)
        {
            state = 0;
            AnimationControl(state);
        }
        x = Mathf.Lerp(x,newPos,Time.deltaTime*10f);
        Vector3 moveVec = new Vector3((x - transform.position.x), 0f, Forward_Speed * Time.deltaTime);

        main_Controller.Move(moveVec);





    }

    public void AnimationControl(int state)
    {
        if(isGrounded)
        {
            if(state==1)
            {
                animator.SetBool("RightTurn", true);
            }
            else if(state==0)
            {
                animator.SetBool("Slided", true);
            }
            else if(state==-1)
            {
                animator.SetBool("LeftTurn", true);
            }
            else
            {
                setallFalse();
            }
        }

    }

    private void setallFalse()
    {
        animator.SetBool("LeftTurn", false);
        animator.SetBool("RightTurn", false);
        animator.SetBool("Slided", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        spawn_Manager.enteredATrigger();
        
    }

}
