using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateTrigger : MonoBehaviour
{
    public UiManager uiManager;
    public LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelManager.LoadLevelAdditive(2);
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            
        }
    }

}
