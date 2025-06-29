using UnityEngine;
using UnityEngine.UI;

public class SliderSynchronizer : MonoBehaviour
{
    [SerializeField] 
    private bool isMusicSlider;

    private void Start()
    {
        var slider = GetComponent<Slider>();

        if (slider == null)
            return;
        
        if (isMusicSlider)
        {
            MusicManager.Instance.RegisterSlider(slider);
        }
        else
        {
            SoundEffectManager.Instance.RegisterSlider(slider);
        }
    }
}