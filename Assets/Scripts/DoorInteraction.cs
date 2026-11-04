using UnityEngine;

public class DoorInteraction : MonoBehaviour, IInteractionManager
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
