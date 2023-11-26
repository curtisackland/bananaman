using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform camera;
    public Animator playerAnimator;

    public CinemachineFreeLook freeLook;
    
    public float speed;
    public float SmoothTime = 0.3f;
    private float velocity;

    void Start()
    {
        
    }
    
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
        
        
        controller.Move(transform.rotation * dir * (speed * Time.deltaTime));
        
    }
}
