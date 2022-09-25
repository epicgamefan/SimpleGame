using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AvatarController : MonoBehaviour
{
    public InputAction playerControls;
    public float moveSpeed = 1f;
    Vector2 moveDirection = Vector2.zero;

    Animator animator;

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>();
        animator.SetBool("Walk", moveDirection != Vector2.zero);
        animator.SetFloat("DirectionX", moveDirection.x);
        animator.SetFloat("DirectionY", moveDirection.y);
    }

    private void FixedUpdate()
    {
        transform.position += (Vector3)(moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
