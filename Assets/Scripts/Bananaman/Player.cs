using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLaserTime = 100;
    public int currentLasterTime = 100;
    public float maxLaserCooldown = 2;
    public float currentLaserCooldown = 0;
    public float health = 100;
    public float score = 0;
    public float laserDamage = 1;
    
    public Camera mainCamera;
    public GameObject eyes;
    public GameObject laser;
    private AudioSource laserAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
        laserAudio = laser.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bool showLaser = false;
        if (Input.GetMouseButton(0))
        {
            showLaser = true;
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, 1000, ~LayerMask.GetMask("Player")))
            {
                //Debug.DrawRay(mainCamera.transform.position, mainCamera.transform.forward * 100, Color.red);
                //Debug.DrawLine(mainCamera.transform.position, hit.transform.position, Color.green);
                //Debug.DrawRay(hit.point, Vector3.up, Color.blue);
                // Move laser
                if (hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    hit.collider.gameObject.GetComponent<EnemyController>().doDamage(laserDamage);
                }
            }
            else
            {
                
            }
            
            laser.transform.position = (eyes.transform.position + hit.point) / 2; // Set position of laser
            
            laser.transform.rotation = Quaternion.RotateTowards(laser.transform.rotation, Quaternion.LookRotation(hit.point - eyes.transform.position), 180);
            laser.transform.Rotate(90, 0, 0);

            laser.transform.localScale = new Vector3(0.1f, ((eyes.transform.position - hit.point) / 2).magnitude, 0.1f);

            laserAudio.pitch = Mathf.Min(Mathf.Max(1.05f - ((eyes.transform.position - hit.point).magnitude/50), 0.95f), 1.05f);
        }

        laser.SetActive(showLaser);
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            health -= 1 * Time.deltaTime;
        }
    }
}
