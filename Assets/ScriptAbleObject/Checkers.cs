using UnityEngine;

[CreateAssetMenu(fileName = "Checkers", menuName = "Neko/Checkers", order = 1)]
public class Checkers : ScriptableObject
{
    [Header("Physics")]
    [Range(0, 5000)]
    [Tooltip("Set the power to move downwards")]
    public float velocity;

    [Header("Data")]
    public int _Id;
    public GameObject[] _checkerSprit;
    public string[] _checkerName;
    public int point;
    public float _spawnRate;
    public CheckersTypes _checkersType = CheckersTypes.None;
    public CheckerSize _checkerSize = CheckerSize.None;


}

