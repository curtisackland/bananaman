using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform targetLocation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Banana Man") // for player
        {
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            // Teleport the player to the specified destination
            other.gameObject.transform.position = targetLocation.position;
            other.gameObject.transform.Rotate(0, 180, 0);
            cc.enabled = true;
        }
    }
}
