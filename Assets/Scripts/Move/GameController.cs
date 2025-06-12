using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider ProgressSlider;
    void Start()
    {
        progressAmount = 0;
        ProgressSlider.value = 0;
        Gem.OnGemCollect += IncreaseProgressAmount;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        ProgressSlider.value = progressAmount;
        if (progressAmount >= 100)
        {
            Debug.Log("level comp");
        }
    }
}
