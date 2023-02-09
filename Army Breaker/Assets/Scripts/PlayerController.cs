using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 7f;
    public LayerMask layerMask;
    public float checkLength;

    private bool isWalking;

private void Update() {
    Vector2 inputVector = gameInput.GetMovementVectorNormalized();

    Vector3 moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
    bool canMove = !Physics2D.Raycast(transform.position, moveDir, checkLength, layerMask);
    if (canMove)
    {
        transform.position += moveDir * moveSpeed * Time.deltaTime;
        Debug.DrawRay(transform.position, moveDir * checkLength, Color.red, 1f);
    }
    else
    {
        Debug.Log("Raycast hit an object!");
        Debug.DrawRay(transform.position, moveDir * checkLength, Color.red, 1f);
    }

    isWalking = moveDir != Vector3.zero;

}



    public bool IsWalking()
    {
        return isWalking;
    }
}
