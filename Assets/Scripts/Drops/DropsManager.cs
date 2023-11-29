using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DropsManager : MonoBehaviour
{
    public enum DropTypes { Ammo, Health, Score }

    public DropTypes dropType;

    public float respawnCooldown = 5;

    private bool respawning = false;
    
    private float time;

    private Renderer[] renderers;

    private void Start()
    {
        renderers = gameObject.GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Banana Man") // for player
        {
            Player player = other.GetComponent<Player>();
            
            if (!respawning)
            {
                switch (dropType)
                {
                    case DropTypes.Ammo:
                        if (player.currentLasterTime < player.maxLaserTime) // don't pick up ammo if already full
                        {
                            if (player.currentLasterTime < 50)
                            {
                                player.currentLasterTime += 50;
                            }
                            else
                            {
                                player.currentLasterTime = 100;
                            }

                            StartRespawning();
                        }
                        break;

                    case DropTypes.Health:
                        if (player.health < 100)
                        {

                            if (player.health < 50)
                            {
                                player.health += 50;
                            }
                            else
                            {
                                player.health = 100;
                            }
                            
                            StartRespawning();
                        }
                        break;

                    case DropTypes.Score:
                        player.score += 50;
                        StartRespawning();
                        break;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (respawning)
        {
            time += Time.deltaTime;
            if (time >= respawnCooldown)
            {
                respawning = false;
                foreach (var renderer in renderers)
                {
                    renderer.enabled = true;
                }
            }
        }
    }

    private void StartRespawning()
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = false;
        }
        respawning = true;
        time = 0;
    }
}
