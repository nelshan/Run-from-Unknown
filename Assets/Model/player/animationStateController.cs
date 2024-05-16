using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int iswalkinghash;
    int isrunninghash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        iswalkinghash = Animator.StringToHash("walk");
        isrunninghash = Animator.StringToHash("run");
    }

    // Update is called once per frame
    void Update()
    {   
        bool isrunning = animator.GetBool(isrunninghash);
        bool iswalking = animator.GetBool(iswalkinghash);
        bool forwardPressed = Input.GetKey(KeyCode.W);
        bool runpressed = Input.GetKey(KeyCode.LeftShift);
        
        //if player not running and is walking and pressed left shift
        if (!isrunning && forwardPressed && runpressed)
        {
           
            //then set the run boolean to true
            animator.SetBool(isrunninghash, true);
            
        }
        //if player was running but released the left shift key
        else if (isrunning && !runpressed)
        {
            //then set the run boolean to false
            animator.SetBool(isrunninghash, false);
        }
        
        //if player press w key but not running
        if (!iswalking && forwardPressed && !runpressed)
        {
            //then set the walk boolean to true
            animator.SetBool(iswalkinghash, true);
        }
        //if player stops walking
        else if (iswalking && !forwardPressed)
        {
            //then set the walk boolean to false
            animator.SetBool(iswalkinghash, false);
        }

        /**
        //if player is running and stops running or stops either walking or pressing the LeftShift key
        if(isrunning && (!forwardPressed || !runpressed))
        {
            //then set the run boolean to false
            animator.SetBool(isrunninghash, false);
        }

        //if player is not running and is walking and pressed LeftShift
        if(!isrunning && forwardPressed && runpressed)
        {
            //then set the run boolean to true
            animator.SetBool(isrunninghash, true);
        }
        **/
    }
}
