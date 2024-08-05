using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform playerHand; // The player's hand transform
    public float fallSpeed = 8f; // Speed of the fall
    public float pickupSpeed = 6f; // Speed of the pickup
    public float groundOffset = 0.1f; // Offset to prevent clipping
    public Vector3 positionOffset; // Position offset when picked up
    public Vector3 rotationOffset; // Rotation offset when picked up

    private bool isPickedUp = false; // State of the object
    private bool isFalling = false; // State of falling
    private bool isMovingToHand = false; // State of moving to hand
    private Vector3 targetFallPosition; // Target position for falling
    private Vector3 targetPickupPosition; // Target position for picking up
    
    void Update()
    {
        if (isPickedUp)
        {
            // Directly follow the player's hand position and rotation with offset
            transform.position = playerHand.position + playerHand.rotation * positionOffset;
            transform.rotation = playerHand.rotation * Quaternion.Euler(rotationOffset);
        }
        else if (isFalling)
        {
            // Interpolate the object position to the ground
            transform.position = Vector3.Lerp(transform.position, targetFallPosition, Time.deltaTime * fallSpeed);

            // Check if the object has reached the target position
            if (Vector3.Distance(transform.position, targetFallPosition) < 0.1f)
            {
                isFalling = false; // Stop falling
                GetComponent<Collider>().enabled = true; // Enable collider
            }
        }
        else if (isMovingToHand)
        {
            // Interpolate the object position to the player's hand
            transform.position = Vector3.Lerp(transform.position, targetPickupPosition, Time.deltaTime * pickupSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, playerHand.rotation * Quaternion.Euler(rotationOffset), Time.deltaTime * pickupSpeed);

            // Check if the object has reached the player's hand
            if (Vector3.Distance(transform.position, targetPickupPosition) < 0.1f)
            {
                isMovingToHand = false; // Stop moving to hand
                isPickedUp = true; // Set as picked up
            }
        }
    }

    public void PickUp(Transform hand)
    {
        playerHand = hand;
        targetPickupPosition = playerHand.position + playerHand.rotation * positionOffset; // Set the target position for picking up
        isMovingToHand = true;
        isPickedUp = false; // Ensure it's not considered picked up immediately
        GetComponent<Collider>().enabled = false; // Disable collider to prevent interaction with other objects
    }

    public void Drop()
    {
        isPickedUp = false;
        isMovingToHand = false; // Stop any pickup movement
        // Shoot a ray downward to find the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity))
        {
            targetFallPosition = hit.point + Vector3.up * groundOffset; // Set the target fall position to the hit point with offset
            isFalling = true;
        }
        else
        {
            // If no ground is found, just enable the collider
            GetComponent<Collider>().enabled = true;
        }
    }

    public bool IsPickedUp()
    {
        return isPickedUp;
    }
}