using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animController : MonoBehaviour {

    public MC_Controller mcc;
    public Animator animator;

    public int state = 1;

	// Use this for initialization
	void Start () {

        mcc = GetComponent<MC_Controller>();
        animator = GetComponent<Animator>();

        //anim.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case 1://idle
                animator.SetBool("IsRun",false);
                break;
            case 2://跑动
                animator.SetBool("IsRun", true);
                break;
        }

	}
    
    
}


