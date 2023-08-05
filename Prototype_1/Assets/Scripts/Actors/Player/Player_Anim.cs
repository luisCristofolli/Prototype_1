using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Anim : MonoBehaviour
{
    private Animator anim;
    private Player_Controll playerControll;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        playerControll = GetComponent<Player_Controll>();   
    }

   
    void Update()
    {
        OnMove();
        OnJump();
    }

    #region MOVEMENT
    public void OnMove()
    {
        if (playerControll.isDirection > 0)
        {
            anim.SetInteger("transition", 1);
        }

        if(playerControll.isDirection < 0)
        {
            anim.SetInteger("transition", 1);
        }

        if(playerControll.isDirection == 0)
        {
            anim.SetInteger("transition", 0);
        }
    }


    public void OnJump()
    {
        if (playerControll.isJumping == true)
        {
            anim.SetInteger("transition", 2);
        }
    }
    #endregion
}
