using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    [SerializeField] Vector2Int endPos;
    [SerializeField] GameObject player;
    [SerializeField] GameObject destinationObj;
    [SerializeField] Transform mazeGridParent;
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] PathFinding pathFinding;
    MazeCell[,] mazeCells;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        mazeGenerator.Generate();
        InitialSetup();
    }

    void InitialSetup()
    {
        GetAllNode();
        Vector2Int randomEndPos = new Vector2Int(4, 4);
        pathFinding.SetEndPosition(randomEndPos);
        destinationObj.transform.position = mazeCells[randomEndPos.x, randomEndPos.y].gameObject.transform.position;
        player.transform.position = mazeCells[0, 0].gameObject.transform.position;
        player.SetActive(true);
    }

    public void GetAllNode()
    {
        Vector2Int mazeSize = pathFinding.MazeSize;
        MazeCell[] allMazeCells = mazeGridParent.gameObject.GetComponentsInChildren<MazeCell>();
        mazeCells = new MazeCell[mazeSize.x, mazeSize.y];

        for (int i = 0; i < allMazeCells.Length; i++)
        {
            MazeCell mazeCell = allMazeCells[i];
            mazeCells[mazeCell.position.x, mazeCell.position.y] = mazeCell;
        }
    }

    public void ActivatePathFinding()
    {
        List<Vector2Int> path = pathFinding.FindPath(mazeCells);
        int length = path.Count;
        Vector2[] pathInWorldPos = new Vector2[length];

        for (int i = 0; i < length; i++)
        {
            pathInWorldPos[length - i - 1] = mazeCells[path[i].x, path[i].y].transform.position;
        }
    }

}