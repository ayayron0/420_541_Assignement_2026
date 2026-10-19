using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    private CharacterMovement movement;
    [SerializeField] private AudioClip doubleJumpSound;
    [SerializeField] private GameObject doubleJumpEffect;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<CharacterMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 characterSpeed = rb.linearVelocity;
        characterSpeed.y = 0f;

        animator.SetFloat("CharacterSpeed", characterSpeed.magnitude);
        animator.SetBool("IsGrounded", movement.IsGrounded);

        if (movement.IsGrounded == true){

            animator.ResetTrigger("doDoubleJump");

        }else{

            if (Input.GetButtonDown("Jump") && movement.TryDoubleJump()){

                animator.SetTrigger("doDoubleJump");
                audioSource.PlayOneShot(doubleJumpSound);
                Instantiate(doubleJumpEffect, transform.position + Vector3.up, Quaternion.identity);

            }
        }
    }
}
