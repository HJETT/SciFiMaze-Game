using ControllerModule.Controllers;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;

    [SerializeField]
    private Controller controller;

    [SerializeField]
    private float walkSpeed = 10;

    

    private float currentSpeed = 10;

    #region Movement

    public void ProcessMovement(Vector3 direction, float elapsed)
    {
        // Check for validity
        if (this._characterController == null)
            return;

        if (controller.Eyes == null)
            return;

        // Modify the direction
        Vector3 movement = (controller.Eyes.forward * direction.y) + (controller.Eyes.right * direction.x);
        movement.y = 0;
        movement.Normalize();

        // If not moving, skip
        if (direction.magnitude <= 0f)
            return;

        this._characterController.Move(elapsed * this.currentSpeed * movement);
    }

    #endregion

    #region Gravity

    private Vector3 gravityVelocity;
    private bool isGrounded;

    public void ProcessGravity(float elapsed)
    {
        // Check for validity
        if (this._characterController == null)
            return;

        if (this.isGrounded && this.gravityVelocity.y <= 0)
        {
            this.gravityVelocity.y = 0;
            this.hasJumped = false;
        }

        this.gravityVelocity += Physics.gravity * elapsed;
        this._characterController.Move(this.gravityVelocity * elapsed);

        // Update state
        this.isGrounded = this._characterController.isGrounded;
    }

    #endregion

    #region Jump

    [Header("Jump")]
    [SerializeField, Min(0)]
    private float jumpForce;
    private bool hasJumped;
    private bool isPressingJump;

    public void ProcessJump()
    {
        if (this.isPressingJump)
        {
            this.ProcessJumpStart();
        }
    }

    public void ProcessJumpStart()
    {
        this.isPressingJump = true;

        // Check for validity
        if (!this.isGrounded)
            return;

        // Override gravity
        this.gravityVelocity.y = this.jumpForce;
        this.hasJumped = true;
    }

    public void ProcessJumpRelease()
    {
        this.isPressingJump = false;

        // Check for validity
        if (!this.hasJumped)
            return;

        if (this.gravityVelocity.y <= 0)
            return;

        // Release jump
        this.gravityVelocity.y = 0;
        this.ProcessGravity(0);
    }

    #endregion

    #region Sprint

    [Header("Sprint")]
    [SerializeField]
    private float sprintSpeed = 15;

    public void StartSprint()
    {
        this.currentSpeed = this.sprintSpeed;
    }

    public void EndSprint()
    {
        this.currentSpeed = this.walkSpeed;
    }

    #endregion
}