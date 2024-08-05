# Unity Pickup and Drop System

## Overview

This Unity script allows a player to interact with objects in the game world, specifically to pick up and drop items. It includes two primary scripts: `PlayerInteract` and `Pickup`.

## How to Use

### Setup the Player

1. Attach the `PlayerInteract` script to your player GameObject.
2. Assign the `hand` transform in the `PlayerInteract` script to the transform of the player's hand or where you want the object to be held.
3. Set the `interactDistance` to determine how far the player can interact with objects.

### Setup the Interactable Objects

1. Create objects in your scene that you want the player to be able to pick up.
2. Attach the `Pickup` script to these objects.
3. Configure the `Pickup` script parameters such as `fallSpeed`, `pickupSpeed`, `groundOffset`, `positionOffset`, and `rotationOffset`.
4. **Important:** Ensure that the pickable objects do not have a `Rigidbody` component attached, as this can interfere with the smooth movement and positioning of the objects when picked up or dropped.

### Interaction

- Press the interaction key (default is 'E') to pick up and drop objects within the specified distance.
## Position Offset and Rotation Offset

- **Position Offset:** Determines the offset of the object's position relative to the player's hand when the object is picked up. This helps in positioning the object properly in the player's hand.
- **Rotation Offset:** Determines the offset of the object's rotation relative to the player's hand when the object is picked up. This ensures the object is oriented correctly in the player's hand.

## Example

To see the system in action, follow these steps:

1. Add the `PlayerInteract` script to your player GameObject.
2. Add the `Pickup` script to any GameObject you want the player to be able to pick up.
3. Configure the parameters to fit your game's needs.
4. Ensure that the pickable objects do not have a `Rigidbody` component attached.
5. Play the scene and press the interaction key to pick up and drop objects.

## Conclusion

This system provides a simple yet effective way to allow players to interact with objects in the game world, enhancing gameplay by enabling the pickup and dropping of items with smooth transitions and configurable parameters.
## Contact

For any questions or feedback, feel free to reach out:

- **Email:** [s.abdurrehman.2007@gmail.com](mailto:s.abdurrehman.2007@gmail.com)
