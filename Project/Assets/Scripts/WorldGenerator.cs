using CodeMonkey;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldGenerator : MonoBehaviour
{
    public Transform cameraTrans;
    public Tilemap backgroundTilemap;
    public Transform gridTrans;
    public int cellX;
    public int cellY;

    private List<Vector2> placedFields = new List<Vector2>();
    private int currentX;
    private int currentY;
    private Vector2 currentField;
    private Vector2 currentForField;
    private List<Vector2> newFields = new List<Vector2>();

    private void Update()
    {
        Calculate();
    }

    private void Generate(int x, int y)
    {
        Instantiate(backgroundTilemap, new Vector3(x, y), Quaternion.identity, gridTrans);
    }

    private void Calculate()
    {
        currentX = (int)(cameraTrans.position.x / cellX);
        currentY = (int)(cameraTrans.position.y / cellY);
        currentField = new Vector2(currentX, currentY);

        for (int x = -1; x < 1; x++)
        {
            for (int y = -1; y < 1; y++)
            {
                currentForField = new Vector2(currentField.x + x, currentField.y + y);
                newFields.Add(new Vector2(currentField.x + x, currentField.y + y));
                if (!placedFields.Contains(currentForField))
                {
                    placedFields.Add(currentForField);
                    Generate((int)(currentForField.x) * cellX, (int)(currentForField.y) * cellY);
                }
            }
        }

       



        
    }

}

