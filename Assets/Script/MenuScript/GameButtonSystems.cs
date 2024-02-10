using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtonSystems : MonoBehaviour
{
    public void FreeGameMap()
    {
        SceneManager.LoadScene(1);
    }
    public void BeatEdit()
    {
        SceneManager.LoadScene(2);
    }
}
