using UnityEngine;

public class ButtonInteraction : MonoBehaviour, IInteractionManager
{
    public GameObject door;
    public void Interact()
    {
        Destroy(door.gameObject);
    }
}

