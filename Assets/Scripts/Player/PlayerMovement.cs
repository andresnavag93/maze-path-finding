using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public bool isOnUiButtonPress = false;
    private Rigidbody2D playerRigidbody;
    public float speed = 1.0f;
    private bool walking = false;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    public Vector2 movement = Vector2.zero;

    [SerializeField] MazeCell curCell;
    public MazeCell CurrentCell { 
        get 
        { 
            return curCell; 
        } 
    }

    #region Mono
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isOnUiButtonPress)
        {
            walking = false;
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f ||
                    Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5)
            {
                walking = true;

                movement = new Vector2(Input.GetAxisRaw(horizontal), Input.GetAxisRaw(vertical));
                movement = movement * speed;
            }
            if (!walking)
            {
                movement = Vector2.zero;
            }
        }
    }

    private void FixedUpdate()
    {
        playerRigidbody.velocity = movement;
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.tag == "Destination")
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       }
        if (collision.CompareTag("Maze Cell"))
        {
            SetCell(collision.GetComponent<MazeCell>());
        }
    }

    public void MoveForward ()
    {
        walking = true;
    }

    public void SetCell(MazeCell nextCell)
    {
        curCell = nextCell;
    }
}
