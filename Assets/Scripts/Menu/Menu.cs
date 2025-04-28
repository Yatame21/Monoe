using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
// скрипт находится в MenuButton если что 
// the script is in MenuButton  if anything -_-