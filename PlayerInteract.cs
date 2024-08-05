using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f; // Distance within which the player can interact
    public Transform hand; // Player's hand transform
    public KeyCode interactKey = KeyCode.E; // Interaction key, editable from the editor

    private Pickup pickedObject = null; // Currently picked object

    void Update()
    {
        if (Input.GetKeyDown(interactKey)) // Interact key
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (pickedObject == null)
                {
                    Pickup pickup = hit.collider.GetComponent<Pickup>();
                    if (pickup != null)
                    {
                        pickup.PickUp(hand);
                        pickedObject = pickup;
                        return;
                    }
                }
                else
                {
                    pickedObject.Drop();
                    pickedObject = null;
                }
            }
        }
    }
}
