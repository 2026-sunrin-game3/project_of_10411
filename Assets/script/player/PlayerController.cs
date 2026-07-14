using UnityEngine;



[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerInput input;

    public PlayerAnimator animator;
    public PlayerMovement movement;
    void Start()
    {
        input = GetComponent<PlayerInput>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<PlayerAnimator>();
    }
    void Update()
    {
        movement.Move(input.axis);

        animator.SetMoving(input.HasAxis(), input.axis);
    }
}   