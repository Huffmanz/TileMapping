using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckerController : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (player != null)
            {
                player.SetGroundedTrue();
            }
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (player != null)
            {
                player.SetGroundedTrue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            if (player != null)
            {
                player.SetGroundedFalse();
            }
        }
    }
}
