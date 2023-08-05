using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    private Rigidbody2D rig;

    private float _direction;

    private bool _isJumping;

    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;


    public float isDirection
    {
        get { return _direction;}
        set {_direction = value;}

    }

    public bool isJumping
    {
        get { return _isJumping; }
        set { _isJumping = value; }

    }


    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
          
    }

    
    void Update()
    {
        OnInput();
        OnJump();   
    }
    void FixedUpdate()
    {
        OnMove();
    }

    #region MOVEMENT
    void OnInput()
    {
        _direction = Input.GetAxisRaw("Horizontal");
    }

    void OnTurn(float angle)
    {
        transform.eulerAngles = new Vector2(0, angle);
    }

    void OnMove()
    {
        rig.velocity = new Vector2(_direction * MoveSpeed * Time.fixedDeltaTime, rig.velocity.y);

        if (_direction > 0)
        {
            OnTurn(0);
        }
        if(_direction < 0)
        {
            OnTurn(180);
        }
        
 
    }

    void OnJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!_isJumping)
            {
                rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
                _isJumping = true;
            }
        }
    }

    #endregion

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            _isJumping = false;
        }
    }
}
