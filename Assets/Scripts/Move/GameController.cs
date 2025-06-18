using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Slider progressSlider;
    
    [SerializeField] 
    private GameObject portal; 
    
    [SerializeField] 
    private string nextLevelName;

    private int progressAmount;

    private void Start()
    {
        progressAmount = 0;
        if (progressSlider != null)
        {
            progressSlider.value = 0;
        }
        
        Gem.OnGemCollect += IncreaseProgressAmount;

        if (portal != null)
        {
            portal.SetActive(false);
        }
    }

    private void OnDestroy()
    {
        Gem.OnGemCollect -= IncreaseProgressAmount;
    }

    private void IncreaseProgressAmount(int amount)
    {
        progressAmount = Mathf.Clamp(progressAmount + amount, 0, 100);
        
        if (progressSlider != null)
        {
            progressSlider.value = progressAmount;
        }
        
        if (progressAmount >= 100)
        {
            portal.SetActive(true);
        }
    }
    
    public void LoadNextLevel()
    {
        if (!string.IsNullOrEmpty(nextLevelName))
        {
            SceneManager.LoadScene(nextLevelName);
        }
    }
}