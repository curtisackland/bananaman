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
    
    public float walkingSpeed;
    public float runningSpeed;
    public float SmoothTime = 0.3f;
    private float velocity;
    
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0, v).normalized;
        
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, camera.eulerAngles.y, ref velocity, SmoothTime);
        
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        int animationDirection = 0;
        if (!dir.Equals(Vector3.zero))
        {
            animationDirection = (int)Math.Floor(4 * (Math.Atan2(h, v) + Math.PI) / (Math.PI));
        }
        playerAnimator.SetInteger("direction", animationDirection);
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerAnimator.SetBool("isSprinting", true);
            controller.Move(transform.rotation * dir * (runningSpeed * Time.deltaTime));
        }
        else
        {
            playerAnimator.SetBool("isSprinting", false);
            controller.Move(transform.rotation * dir * (walkingSpeed * Time.deltaTime));
        }
        
    }
}
