using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] 
    private GameObject deathPanel;
    
    [SerializeField] 
    private Button restartButton;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        restartButton.onClick.AddListener(RestartGame);
        deathPanel.SetActive(false);
    }

    public void PlayerDied()
    {
        Time.timeScale = 0f; 
        deathPanel.SetActive(true);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}