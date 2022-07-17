using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Singleton
    public static PlayerManager instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

}
