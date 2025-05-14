using System.Collections.Generic;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class Gem : MonoBehaviour, IItem
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
