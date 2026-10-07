using UnityEngine;

public class UiManager : MonoBehaviour
{
    public Canvas winCanvas;

    private void Start()
    {
        winCanvas.enabled = false;
    }
}
