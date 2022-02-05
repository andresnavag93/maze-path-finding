using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float speed = 1.0f;
    private bool walking = false;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    public Vector2 movement = Vector2.zero;

    #region Mono
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        walking = false;
        if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f ||
                Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5)
        {
            walking = true;

            movement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
            playerRigidbody.velocity = movement * speed;
        }

        if (!walking)
        {
            playerRigidbody.velocity = Vector2.zero;
        }
    }
    #endregion
}
