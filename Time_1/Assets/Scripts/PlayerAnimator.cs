using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator anim;
    public CharacterState _state;

    public enum CharacterState 
     {
         idle,
         walking    
     }

    void Start () 
    {
        anim = GetComponent <Animator> ();
    }

     void Update() 
     { 
        anim.SetFloat("Speed", PlayerMovement.instance.CurrentSpeed());
        CheckKey();
     }

     void CheckKey()
     {
         if(PlayerMovement.instance.IsMoving()) {
             _state = CharacterState.walking;
         } else {
             _state = CharacterState.idle;
         }
         PlayAnimation();
     }

     void PlayAnimation() 
     {
         switch(_state)
         {
            case CharacterState.walking:
                    anim.Play("Walking");
                    break;

            case CharacterState.idle:
                    anim.Play("Idle");
                    break;
         }            
     }
}
