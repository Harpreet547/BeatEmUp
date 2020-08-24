using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRed : MonoBehaviour
{
    public GameObject container;
    
    public float verticalSpeed;
    public float horizontalSpeed;
    private float movementSpeedPercent;

    public float maxY;
    public float minY;

    public float dodgeStrength;
    public float dodgeCooldown;
    public float dodgeDuration;
    private bool isDodging;

    private Rigidbody2D playerRigidbody;
    private Animator animator;

    private bool isFacingRight;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        isFacingRight = true;
        movementSpeedPercent = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        dodge();
    }

    private void FixedUpdate()
    {
    }

    private void move()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        if (!isDodging)
        {
            playerRigidbody.velocity = new Vector2(
                horizontalAxis * horizontalSpeed * movementSpeedPercent,
                verticalAxis * verticalSpeed * movementSpeedPercent
            );

            if (playerRigidbody.velocity.x > 0)
            {
                isFacingRight = true;
            }
            else if (playerRigidbody.velocity.x < 0)
            {
                isFacingRight = false;
            }
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

    public void setMovementSpeedPercent(float speedPercent)
    {
        movementSpeedPercent = speedPercent;
    }
    private void dodge()
    {
        if(Input.GetButtonDown("Dodge"))
        {
            StartCoroutine(dodgeRoutine());
        }
    }

    IEnumerator dodgeRoutine()
    {
        if(!isDodging)
        {
            isDodging = true;

            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            if (horizontalAxis != 0 || verticalAxis != 0)
            {
                playerRigidbody.velocity = new Vector2(
                        horizontalAxis * dodgeStrength,
                        verticalAxis * dodgeStrength
                    );
            }
            else if (horizontalAxis == 0 && verticalAxis == 0)
            {
                playerRigidbody.velocity = new Vector2(
                        (isFacingRight ? -1 : 1) * dodgeStrength,
                        0
                    );
            }

            yield return new WaitForSeconds(dodgeDuration);

            playerRigidbody.velocity = Vector2.zero;

            yield return new WaitForSeconds(dodgeCooldown);

            isDodging = false;
        }
    }
}
