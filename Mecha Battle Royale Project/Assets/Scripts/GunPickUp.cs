using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public KeyCode pickupKey = KeyCode.E; // Key to press for pickup
    public float pickupRange = 2f; // Distance within which the player can pick up the gun
    public Transform gunHolder;
    private GameObject currentGun; // Reference to the currently picked up gun

    void Update()
    {
        // Create layer mask to ignore Pickupable layer
        // int layerMask = ~(1 << LayerMask.NameToLayer("Pickables"));

        Debug.DrawRay(transform.position, transform.forward * pickupRange, Color.red);

        if (Input.GetKeyDown(pickupKey))
        {
            // Raycast to check if there's a gun within pickup range
            RaycastHit hit;
            // Raycast(starting point, direction, place to store information, raycast range)
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
            {
                // Check if the object hit is a gun
                if (hit.collider.CompareTag("Gun"))
                {
                    // Pick up the gun
                    GameObject gunObject = hit.collider.gameObject;
                    PickUpGun(gunObject);
                }
            }
        }
    }

    void PickUpGun(GameObject gun)
    {
        // Disable the gun's collider and set it as a child of the player
        gun.GetComponent<Collider>().enabled = false;
        gun.transform.SetParent(gunHolder, false);

        // Set the gun's position and rotation to match the gun holder
        gun.transform.localPosition = Vector3.zero;
        gun.transform.localRotation = Quaternion.identity;

        // Store reference to the picked up gun
        currentGun = gun;
    }
}
