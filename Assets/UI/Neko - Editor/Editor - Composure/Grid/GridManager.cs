using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Grid components")]
    [Tooltip("Grid Image")]
    public Texture2D gridImgae;

    [Tooltip("Grid container that store's grid image")]
    public GameObject gridContainer;

    [Header("Grid cell Width and height")]
    private int gridHeight, gridWidth;

    [Header("Grid")]
    private GameObject[,] grid;


    private void Update()
    {
        CalculateGridCellSize(NekoMap.size);
    }

    private void CalculateGridCellSize(float size)
    {
        float minValue = 1;
        float maxValue = 10;

    }
}
