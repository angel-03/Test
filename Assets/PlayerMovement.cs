using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public GameObject gameObject;
    private float direction;
    public float jumpForce;
    public Rigidbody2D body;
    public Animator animator;
    private bool isRight;
    private bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        isGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(direction));
         if(isRight && direction > 0f)
        {
            transform.localScale = new Vector3(1,1,1);
            isRight = false;
        }
        else if(!isRight && direction < 0f)
        {
            transform.localScale = new Vector3(-1,1,1);
            isRight = true;
        }
        /*if(Input.GetKeyDown(KeyCode.A))
        {
            body.velocity = new Vector2(-4,0) *speed*Time.deltaTime;
            gameObject.transform.localScale = new Vector3(-1, transform.localScale.y);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            body.velocity = new Vector2(4,0)*speed*Time.deltaTime;
            gameObject.transform.localScale = new Vector2(1, transform.localScale.y);
        }*/
    }

    void FixedUpdate() 
    {
        direction = Input.GetAxisRaw("Horizontal");
        gameObject.transform.Translate(new Vector3(direction,0,0) * speed * Time.deltaTime);
        //animator.SetBool("isJump",false);
        if (Input.GetButtonDown("Jump")&& Mathf.Abs(body.velocity.y) < 0.01f)
        {
            isGround = false;
            animator.SetBool("isJump",true);
            body.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "gameOver")    
        {
            Debug.Log("GameOver!!!!");
            SceneManager.LoadScene(0);
        }
        if(other.gameObject.tag == "Platform")
        {
            isGround = true;
            animator.SetBool("isJump",false);
        }
    }
}
