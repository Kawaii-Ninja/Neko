using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class DirectoryManager : MonoBehaviour
{
    [SerializeField] string[] paths;

    private void Awake()
    {
        foreach (string path in paths)
        {
            string currentPath = Path.Combine(Application.persistentDataPath + $"/{path}");
            if (!Directory.Exists(currentPath))
            {
                Directory.CreateDirectory(currentPath);
            }
            else
            {
                // Debug.Log($"Path alredy Exiest {currentPath}");

            }
        }
    }

}
