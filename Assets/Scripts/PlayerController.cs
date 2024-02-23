using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private const string IS_RUNNING = "isRunning";
    private const string IS_JUMPING = "isJumping";
    [SerializeField] private float speed = 10f; 
    [SerializeField] private Animator animator;
    [SerializeField] private float height;
    public Rigidbody2D rb2D;

    public void Start ()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private float direction;
    
    private float up_down;
    private bool isFacingRight = true;
    
    public void Update() 
    {
        Movement();
    }
     
    private void Movement(){
        direction = Input.GetAxisRaw("Horizontal");

        up_down = Input.GetAxisRaw("Vertical");
        
        rb2D.velocity = new Vector2(speed*direction, rb2D.velocity.y);


        if ((isFacingRight && direction < 0) || (!isFacingRight && direction > 0))
        {
            isFacingRight = !isFacingRight;
            Flip();
        }
        animator.SetBool(IS_RUNNING, direction != 0);

        if(Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            rb2D.velocity = Vector2.up * height;
            animator.SetBool(IS_JUMPING, true);
        }
        
    }
    private void Flip() 
    {
        transform.Rotate(0f, 180f, 0f);
    }
    
    public void onLand()
    {
        animator.SetBool(IS_JUMPING, false);
    }
    



}
