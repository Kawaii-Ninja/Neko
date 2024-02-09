using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    UniversalPlayerData upd;

    private void Start()
    {
        upd = GameObject.FindAnyObjectByType<UniversalPlayerData>();
    }
    
}
