//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Class MazeGenerator
/// </summary>
public class MazeGenerator : MonoBehaviour
{
    [SerializeField] float offsetX, offsetY;
    [SerializeField] Vector2Int mazeSize;
    [SerializeField] MazeCell mazeCell;
    [SerializeField] MazePassage mazePassage;
    [SerializeField] MazeWall mazeWall;

    MazeCell[,] mazeCells;
    public MazeCell[,] MazeCells { get { return mazeCells; } }

    public void Generate()
    {
        //Clear all mazeCells
        ResetMaze();
        //Create new mazeCells
        mazeCells = new MazeCell[mazeSize.x, mazeSize.y];
        List<MazeCell> activeCells = new List<MazeCell>();
        //Make new Generation Step
        DoFirstGenerationStep(activeCells);

    }

    private void ResetMaze()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    private MazeCell CreateCell(Vector2Int pos)
    {
        MazeCell newMazeCell = Instantiate(mazeCell);
        mazeCells[pos.x, pos.y] = newMazeCell;
        newMazeCell.position = pos;
        newMazeCell.name = "Maze Cell " + pos.x + ", " + pos.y;
        newMazeCell.transform.parent = transform;
        newMazeCell.transform.localPosition = new Vector3(pos.x - mazeSize.x * offsetX + offsetX, pos.y - mazeSize.y * offsetY + offsetY, 0f);

        return newMazeCell;
    }

    public Vector2Int RandomCoordinates
    {
        get
        {
            return new Vector2Int(Random.Range(0, mazeSize.x), Random.Range(0, mazeSize.y));
        }
    }

    private void DoFirstGenerationStep(List<MazeCell> activeCells)
    {
        activeCells.Add(CreateCell(RandomCoordinates));
    }
}
