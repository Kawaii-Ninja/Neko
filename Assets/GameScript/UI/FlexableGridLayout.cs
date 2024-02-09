using System;
using UnityEngine;
using UnityEngine.UI;

public class FlexableGridLayout : LayoutGroup
{
    public int rows;
    public int columns;
    public Vector2 cellSize;
    public Vector2 spacing;
    public override void CalculateLayoutInputHorizontal()
    {
        base.CalculateLayoutInputHorizontal();

        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = parentWidth / columns - spacing.x / columns * 2;
        float cellHeight = parentHeight / rows - spacing.y / rows * 2;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        for (int i = 0; i < rectChildren.Count; i++)
        {
            int rowsCount = i / columns;
            int columnCount = i % columns;

            var item = rectChildren[i];

            var xPos = cellSize.x * columnCount;
            var yPos = cellSize.y * rowsCount;

            SetChildAlongAxis(item, 0, xPos, cellSize.x);
            SetChildAlongAxis(item, 1, yPos, cellSize.y);
        }
    }

    public override void CalculateLayoutInputVertical()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutHorizontal()
    {
        throw new System.NotImplementedException();
    }

    public override void SetLayoutVertical()
    {
        throw new System.NotImplementedException();
    }
}
