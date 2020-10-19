using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charac_Behavior : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    public float max_jump = 2.0f;
    public bool IsGrounded = true;
    public bool IsRunning_f = false;
    public bool IsRunning_b = false;
    public bool IsJumping = false;
    public float speedinit;
    public Animator animator = new Animator();

    // Start is called before the first frame update
    void Start()
    {
        speedinit = speed;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float translation;
        if (Input.GetKey("q") && !(Input.GetKey("d")))
        {
            translation = -speed;
            transform.localScale = new Vector3(-5, 5, 1);
        }
        else if (Input.GetKey("d") && !(Input.GetKey("q")))
        {
            translation = speed;
            transform.localScale = new Vector3(5, 5, 1);
        }
        else
        {
            translation = 0;
        }

        transform.Translate(translation, 0, 0);
        if (translation != 0)
        {
            IsRunning_f = true;
            //IsRunning_b = false;
        }
        else
        {
            IsRunning_f = false;
            //IsRunning_b = false;
        }
        //if (Input.GetKey(KeyCode.D)) //Move to right
        //{
        //    transform.Translate(speed, 0, 0);
        //}

        //if (Input.GetKey(KeyCode.Q)) //Move to left
        //{
        //    transform.Translate(-speed, 0, 0);
        //}

        if (Input.GetKey(KeyCode.Space) && IsGrounded) //Jump
        {
            IsJumping = true;
            rb.velocity = new Vector2(0, max_jump);
        }

        if (!(IsGrounded))
        {
            //speed = speed * 0.99f;
            IsJumping = false;
        }
        else
        {
            //speed = speedinit;
            
        }

        animator.SetBool("IsRunning_f", IsRunning_f);
        //animator.SetBool("IsRunning_b", IsRunning_b);
        animator.SetBool("IsJumping", IsJumping);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    void Init_Ground_True()
    {
        IsGrounded = true;
    }

    void Init_Ground_False()
    {
        IsGrounded = false;
    }
}
