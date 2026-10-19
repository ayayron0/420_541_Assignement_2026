using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private bool isRunning;
    [SerializeField] private float minJumpForce = 5f;
    [SerializeField] private float maxJumpForce = 10f;
    private float chargedJumpForce;
    private bool jumpRequested;
    [SerializeField] private float groundDistance = 0.5f;
    [SerializeField] private LayerMask groundMask;
    private bool isGrounded;
    public bool IsGrounded => isGrounded;
    [SerializeField] private float maxChargeTime = 3f;
    private float chargeTime;
    private bool isCharging;
    [SerializeField] private float doubleJumpForce = 4f;
    private bool doubleJumpRequested;
    private bool hasDoubleJumped;
    private PlayerPowerUps powerUps;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        powerUps = GetComponent<PlayerPowerUps>();
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.Raycast(transform.position + transform.up * groundDistance / 2, -transform.up, groundDistance, groundMask);

        if (isGrounded){

            hasDoubleJumped = false;

        }

        isRunning = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetButtonDown("Jump") && isGrounded){
            chargeTime = 0f;
            isCharging = true;
        }

        if (isCharging == true){

            if (isGrounded == false){

                isCharging = false;

            }else{

                chargeTime += Time.deltaTime;
                chargeTime = Mathf.Clamp(chargeTime, 0f, maxChargeTime);

                if (Input.GetButtonUp("Jump") || chargeTime >= maxChargeTime){

                    float chargeRatio = chargeTime / maxChargeTime;

                    chargedJumpForce = minJumpForce + (maxJumpForce - minJumpForce) * chargeRatio;

                    jumpRequested = true;
                    isCharging = false;
                }
            }
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward.Normalize();
        cameraRight.Normalize();

        moveDirection = (cameraForward * moveZ + cameraRight * moveX).normalized;
    }

    void FixedUpdate()
    {
        float currentSpeed = moveSpeed;

        if (isRunning == true){
            currentSpeed *= 2f;
        }

        Vector3 targetVelocity = moveDirection * currentSpeed;

        rb.linearVelocity = new Vector3(targetVelocity.x, rb.linearVelocity.y, targetVelocity.z);

        if (jumpRequested == true){

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            rb.AddForce(Vector3.up * chargedJumpForce,ForceMode.VelocityChange);

            jumpRequested = false;

        }

        if (doubleJumpRequested == true){

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

            rb.AddForce(Vector3.up * doubleJumpForce, ForceMode.VelocityChange);

            doubleJumpRequested = false;
        }
    }

    public bool TryDoubleJump(){

        if (isGrounded == true || hasDoubleJumped == true || powerUps.JumpTimeLeft <= 0f){

            return false;
        }

        doubleJumpRequested = true;
        hasDoubleJumped = true;
        return true;
    }
}
