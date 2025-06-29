using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectLibrary : MonoBehaviour
{
   [SerializeField]
   private SoundEffectGroup[] soundEffectGroup;

   private Dictionary<string, List<AudioClip>> soundDictionary;

   public void Awake()
   {
      InitializeDictionary();
   }

   private void InitializeDictionary()
   {
      soundDictionary = new Dictionary<string, List<AudioClip>>();
      foreach (SoundEffectGroup soundEffctGroups in soundEffectGroup)
      {
         soundDictionary[soundEffctGroups.name] = soundEffctGroups.audioClips;
      }
   }

   public AudioClip GetRandomClip(string name)
   {
      if (soundDictionary.ContainsKey(name))
      {
         List<AudioClip> audioClips = soundDictionary[name];
         if (audioClips.Count > 0)
         {
            return audioClips[UnityEngine.Random.Range(0, audioClips.Count)];
         }
      }
      return null;
   }
}

[System.Serializable]
public struct SoundEffectGroup
{
   public string name;
   public List<AudioClip> audioClips;
}
