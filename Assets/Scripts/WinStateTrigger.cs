using UnityEngine;

public class WinStateTrigger : MonoBehaviour
{
    public UiManager uiManager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiManager.winCanvas.enabled = true;
        }
    }

}
