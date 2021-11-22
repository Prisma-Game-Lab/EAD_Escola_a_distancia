using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    void Start () 
    {
        anim = GetComponent <Animator> ();
    }
    void Update () 
    {
        if (PlayerMovement.instance.IsMoving()) 
        {
            anim.Play("Walking");
        }
        else
        {
            anim.CrossFade("Idle", 0.5f);
        }
        
        
    }
}
