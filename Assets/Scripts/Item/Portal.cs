using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] 
    private GameController gameController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameController.LoadNextLevel();
        }
    }
}