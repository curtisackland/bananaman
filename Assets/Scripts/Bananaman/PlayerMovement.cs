using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    public Animator playerAnimator;
    public PauseMenuController pauseMenuController;
    
    public float walkingSpeed;
    public float runningSpeed;
    public float SmoothTime = 0.3f;
    private float angularVelocity;
    private float verticalVelocity = 0;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, camera.eulerAngles.y, ref angularVelocity,
            SmoothTime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        int animationDirection = 0;
        if (!dir.Equals(Vector3.zero))
        {
            animationDirection = (int)Math.Floor(4 * (Math.Atan2(h, v) + Math.PI) / (Math.PI));
        }

        playerAnimator.SetInteger("direction", animationDirection);
        
        if (Input.GetKey(KeyCode.LeftShift) && (3 <= animationDirection && animationDirection <= 5))
        {
            playerAnimator.SetBool("isSprinting", true);
            dir = transform.rotation * dir;
            dir *= runningSpeed;
        }
        else
        {
            playerAnimator.SetBool("isSprinting", false);
            dir = transform.rotation * dir;
            dir *= walkingSpeed;
        }

        

        // Gravity
        if (!pauseMenuController.isPaused){
            if (!controller.isGrounded)
            {
                verticalVelocity -= 9.8f;
            }
            else
            {
                verticalVelocity = -9.8f;
            }
        }

        dir.y = verticalVelocity;

        controller.Move(dir * Time.deltaTime);
    }
}
