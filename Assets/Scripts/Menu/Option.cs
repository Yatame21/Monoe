using UnityEngine;
using UnityEngine.UI;

    public class Option : MonoBehaviour
    {
        [SerializeField] private GameObject optionsMenu; 
        [SerializeField] private Button optionsButton; 
        [SerializeField] private Button backButton; 

        private void Start()
        {
            optionsMenu.SetActive(false);
            optionsButton.onClick.AddListener(OpenOptionsMenu);
            backButton.onClick.AddListener(CloseOptionsMenu);
        }

        private void OpenOptionsMenu()
        {
            optionsMenu.SetActive(true);
        }

        private void CloseOptionsMenu()
        {
            optionsMenu.SetActive(false); 
        }
    }




