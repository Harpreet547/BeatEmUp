using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRed : MonoBehaviour
{
    public GameObject container;
    
    public float verticalSpeed;
    public float horizontalSpeed;

    public float maxY;
    public float minY;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        playerRigidbody.velocity = new Vector2(
                horizontalAxis * horizontalSpeed,
                verticalAxis * verticalSpeed
            );

        if(playerRigidbody.velocity.x > 0)
        {
            isFacingRight = true;
        } else if(playerRigidbody.velocity.x < 0)
        {
            isFacingRight = false;
        }

        animator.SetBool("isWalking", playerRigidbody.velocity != Vector2.zero);

        container.transform.localScale = new Vector3(isFacingRight ? transform.localScale.x : -transform.localScale.x, transform.localScale.y, transform.localScale.z);

        if(transform.position.y > maxY)
        {
            transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        } else if(transform.position.y < minY)
        {
            transform.position = new Vector3(transform.position.x, minY, transform.position.z);
        }
    }
}
