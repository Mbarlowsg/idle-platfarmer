using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private Rigidbody2D myBody;
    private SpriteRenderer sr;

    // private Animator anim;
    // private string WALK_ANIMATION = "Walk";
    // private string _walkDirection = "right";
    // public string WalkDirection
    // {
    //     get { return _walkDirection; }
    //     set { _walkDirection = value; }
    // }

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMoveKeyboard();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
