using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    private float direction;

    private float isJumping;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;


    
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();    
    }

    
    void Update()
    {
        OnInput();
    }
    void FixedUpdate()
    {
        OnMove();
    }

    #region MOVEMENT
    void OnInput()
    {
        direction = Input.GetAxisRaw("Horizontal");
    }

    void OnTurn()
    {
        if (direction > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
            anim.SetInteger("transition", 1);
        }

        if (direction < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
            anim.SetInteger("transition", 1);
        }

        if (direction == 0)
        {
            anim.SetInteger("transition", 0);
        }
    }

    void OnMove()
    {
        rig.velocity = new Vector2(direction * MoveSpeed * Time.fixedDeltaTime, rig.velocity.y);
        
 
    }

    void OnJump()
    {

    }

    #endregion
}
