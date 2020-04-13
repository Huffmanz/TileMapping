using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //STANDARD VARIABLES
    public float speed;

    //JUMP VARIABLES
    public float jumpForce;
    private bool _isGrounded;

    //COMPONENT VARIABLES
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    /// <summary>
    /// Allows the player to move left or right
    /// </summary>
    private void Movement()
    {
        float hor = Input.GetAxis("Horizontal") * speed;
        _rigidbody2D.velocity = new Vector3(hor, _rigidbody2D.velocity.y, 0f);

        CheckSpriteRendererFlipX(hor);
    }

    /// <summary>
    /// Checks if the player is going to look left or right
    /// </summary>
    /// <param name="horValue"></param>
    private void CheckSpriteRendererFlipX(float horValue)
    {
        if (horValue > 0)
        {
            _spriteRenderer.flipX = false;
        }

        if (horValue < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    /// <summary>
    /// Allows the player to jump
    /// </summary>
    private void Jump()
    {
        if (_isGrounded)
        {
            _rigidbody2D.AddForce(new Vector3(0f, jumpForce, 0), ForceMode2D.Impulse);
        }
    }

    public void SetGroundedTrue()
    {
        if (!_isGrounded)
        {
            _isGrounded = true;
        }
    }

    public void SetGroundedFalse()
    {
        if (_isGrounded)
        {
            _isGrounded = false;
        }
    }
}
