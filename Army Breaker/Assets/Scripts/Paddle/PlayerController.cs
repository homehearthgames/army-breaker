using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 7f;
    public LayerMask layerMask;
    public float checkLength = 1f;
    [SerializeField] Animator playerAnimator;
    [SerializeField] Animator swordAnimator;
    [SerializeField] private PolygonCollider2D swordCollider;
    [SerializeField] private GameObject sword;
    [SerializeField] SpriteRenderer playerSprite;

    BallController ballController;

    private bool isWalking;

    private void Awake()
    {
        gameInput = GameInput.Instance;
    }
    private void Start() {
        ballController = FindObjectOfType<BallController>();
    }

    private void Update()
    {
        Swing();

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Vector2 swordDirection = mousePosition - (Vector2)sword.transform.position;
        Vector2 ballDirection = (Vector2)ballController.transform.position - (Vector2)sword.transform.position;
        FlipPlayer(ballDirection);
        float angle = Mathf.Atan2(ballDirection.y, ballDirection.x) * Mathf.Rad2Deg;
        sword.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle -90f));

        if (gameInput != null)
        {
            Vector2 inputVector = gameInput.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
            Vector3 targetMovePosition = transform.position + moveDir * moveSpeed * Time.deltaTime;
            RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, moveDir, moveSpeed * Time.deltaTime, ~LayerMask.GetMask("Sword"));

            if (raycastHit.collider == null)
            {
                transform.position = targetMovePosition;
            } else
            {
                Debug.Log(raycastHit.collider.name);
                Vector3 testMoveDir = new Vector3(moveDir.x, 0f).normalized;
                targetMovePosition = transform.position + testMoveDir * moveSpeed * Time.deltaTime;
                
                raycastHit = Physics2D.Raycast(transform.position, testMoveDir, moveSpeed * Time.deltaTime, ~LayerMask.GetMask("Sword"));
                if (raycastHit.collider == null)
                {
                    moveDir = testMoveDir;
                    transform.position = targetMovePosition;
                } else
                {
                    testMoveDir = new Vector3(0f, moveDir.y).normalized;
                    targetMovePosition = transform.position + testMoveDir * moveSpeed * Time.deltaTime;
                    raycastHit = Physics2D.Raycast(transform.position, testMoveDir, moveSpeed * Time.deltaTime, ~LayerMask.GetMask("Sword"));
                    if (raycastHit.collider == null)
                    {
                        moveDir = testMoveDir;
                        transform.position = targetMovePosition;
                    }
                }
            }

            // bool canMove = !Physics2D.Raycast(transform.position, moveDir, checkLength, layerMask);
            // transform.position += moveDir * moveSpeed * Time.deltaTime;
            // if (canMove)
            // {   
            //     isWalking = true;
            //     Debug.DrawRay(transform.position, moveDir * checkLength, Color.red, 1f);
            // }
            // else
            // {
            //     isWalking = false;
            //     Debug.Log("Raycast hit an object!");
            //     Debug.DrawRay(transform.position, moveDir * checkLength, Color.red, 1f);
            // }

            isWalking = moveDir != Vector3.zero;

            if (isWalking)
            {
                playerAnimator.SetBool("isRunning", true);
            }
            else
            {
                playerAnimator.SetBool("isRunning", false);
            }
        }
    }

    public void FlipPlayer(Vector2 mousePosition)
    {
                
        // flip the player gameobject on the x-axis based on the position of the mouse cursor
        Vector3 playerLocalScale = transform.localScale;
        if (mousePosition.x < transform.position.x)
        {
            playerLocalScale.x = -Mathf.Abs(playerLocalScale.x);
        }
        else
        {
            playerLocalScale.x = Mathf.Abs(playerLocalScale.x);
        }
        transform.localScale = playerLocalScale;
    }
    public bool IsWalking()
    {
        return isWalking;
    }

    public void Swing()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            swordCollider.enabled = true;
            swordAnimator.SetBool("Attack", true);
        }
        else
        {
            swordCollider.enabled = false;
            
            swordAnimator.SetBool("Attack", false);
        }
    }

}
