using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    // Create a wall and floor prefab to use for the grid
    [SerializeField]
    GameObject wall, floor;
    // Since its a grid, we need rows and coloumns to specify the parameters
    [SerializeField]
    int rows = 4, columns = 4;
    // Creating a Maze Cell grid thats an array so we can create a path for us to go through
    MazeCell[,] grid;
    // Keeping track of what row and coloumn we are on.
    private int currentRow = 0, currentColumn = 0;

    bool finishScanning;
    private void Awake()
    {
        // Inititalizing the grid to the rows and the coloumns we've generated
        grid = new MazeCell[rows,columns];
    }
    void Start()
    {
        InstantiateGrid();
        HuntAndKill();
    }

 
    void InstantiateGrid()
    {
        // Using the scale of the floor or wall to perfectly place every wall and floor
        float size = floor.transform.localScale.x;
        // Looping through the maze with 2 for loops to go through the rows and coloumns
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Initializing the grid to the 2 for loops we created to add the objects in the grid
                grid[i, j] = new MazeCell();
                // For each floor or wall, since we have to place them perfectly, we use j and i and we multiply it by the size to get a perfectly placed maze 
                GameObject floorObj = Instantiate(floor, new Vector3(transform.position.x + j * size, transform.position.y, transform.position.z - i * size), Quaternion.identity);
                floorObj.name = "Floor_" + (i + 1) + "_" + (j + 1);
                floorObj.transform.parent = this.transform;

                GameObject topWall = Instantiate(wall, new Vector3(transform.position.x + j * size, transform.position.y + 5, transform.position.z - i * size + 4.5f), Quaternion.identity);
                topWall.name = "TopWall_" + (i + 1) + "_" + (j + 1);
                topWall.transform.parent = this.transform;
                // Initializing every wall, for example below the topWall, to the grids(Maze Cells) top wall 
                grid[i, j].topWall = topWall;

                GameObject bottomWall = Instantiate(wall, new Vector3(transform.position.x + j * size, transform.position.y + 5, transform.position.z - i * size - 4.5f), Quaternion.identity);
                bottomWall.name = "BottomWall_" + (i + 1) + "_" + (j + 1);
                bottomWall.transform.parent = this.transform;
                grid[i, j].bottomWall = bottomWall;

                GameObject leftWall = Instantiate(wall, new Vector3(transform.position.x + j * size - 4.5f, transform.position.y + 5, transform.position.z - i * size), Quaternion.Euler(0f, 90f, 0f));
                leftWall.name = "LeftWall_" + (i + 1) + "_" + (j + 1);
                leftWall.transform.parent = this.transform;
                grid[i, j].leftWall = leftWall;

                GameObject rightWall = Instantiate(wall, new Vector3(transform.position.x + j * size + 4.5f, transform.position.y + 5, transform.position.z - i * size), Quaternion.Euler(0f, 90f, 0f));
                rightWall.name = "RightWall_" + (i + 1) + "_" + (j + 1);
                rightWall.transform.parent = this.transform;
                grid[i, j].rightWall = rightWall;

                if(i == 0 && j == 0)
                {
                    Destroy(leftWall);
                }
                if(i == rows - 1 && j == columns - 1)
                {
                    Destroy(rightWall);
                }
            }
        }
    }
   

    // This functions checks to see if all of the bounadaries have passed, and if the cell is unvisisted
    //  that means we haven't visited that cell, so we can return true;
    bool CellUnvisitedBoundary(int row, int column)
    {
        if(row >= 0 && row < rows && column >= 0 && column < columns && !grid[row, column].visited)
        {
            return true;
        }
        return false;
    }
    // Using this checks every wall, top bottom left and right, and sees if theyre unvisited.
    // If it is unvisited, then we are able to go to that wall and destroy it.
    bool CheckingUnvisistedNeighbours()
    {
        // check for top
        if (CellUnvisitedBoundary(currentRow - 1, currentColumn))
        {
            return true;
        }
        // check for bottom
        if (CellUnvisitedBoundary(currentRow + 1, currentColumn))
        {
            return true;
        }
        // check for left
        if (CellUnvisitedBoundary(currentRow, currentColumn - 1))
        {
            return true;
        }
        // check for right
        if (CellUnvisitedBoundary(currentRow, currentColumn + 1))
        {
            return true;
        }

        return false;
    }

    private bool CheckVisitedNeighbours(int row, int column)
    {
        if (row > 0 && grid[row - 1, column].visited)
        {
            return true;
        }
        // check for bottom
        if (row < rows - 1 && grid[row + 1, column].visited)
        {
            return true;
        }
        // check for left
        if (column > 0 && grid[row, column - 1].visited)
        {
            return true;
        }
        // check for right
        if (column < columns && grid[row, column + 1].visited)
        {
            return true;
        }

        return false;
    }

    private void HuntAndKill()
    {
        // Starting location at (0, 0), row (0), coloumn (0), and since we are at this location, we check it off as visited
        grid[currentRow, currentColumn].visited = true;

        while (!finishScanning)
        {
            CreatePath();
            HuntPath();
        }     
    }

    private void CreatePath()
    {
        /* For the logic of the directions, we have to think of it like this -> if we have 4 rows and 4 coloumns:
            1,1 1,2 1,3 1,4
            2,1 2,2 2,3 2,4
            3,1 3,2 3,3 3,4
            4,1 4,2 4,3 4,4
            if the direction is 0, and we are at 2,1 that means we go up. To go up we have to check that the row is greater than 0
            and we have to check the the currentRow - 1 which is 1,1 is not visited, then we can visit it. Same logic applies for the rest
         */
        while (CheckingUnvisistedNeighbours())
        {
            // We get a random direction to start paving through from 0, 0
            int direction = UnityEngine.Random.Range(0, 4);

            // 0 is Top, so we are checking the top wall
            if (direction == 0)
            {
                Debug.Log("Check Top");
                if (CellUnvisitedBoundary(currentRow - 1, currentColumn))
                {
                    if (grid[currentRow, currentColumn].topWall)
                    {
                        Destroy(grid[currentRow, currentColumn].topWall);
                    }
                    currentRow--;
                    grid[currentRow, currentColumn].visited = true;

                    if (grid[currentRow, currentColumn].bottomWall)
                    {
                        Destroy(grid[currentRow, currentColumn].bottomWall);
                    }
                }
                // 1 is bottom wall
            }
            else if (direction == 1)
            {
                Debug.Log("Check Bottom");

                if (CellUnvisitedBoundary(currentRow + 1, currentColumn))
                {
                    if (grid[currentRow, currentColumn].bottomWall)
                    {
                        Destroy(grid[currentRow, currentColumn].bottomWall);
                    }
                    currentRow++;
                    grid[currentRow, currentColumn].visited = true;

                    if (grid[currentRow, currentColumn].topWall)
                    {
                        Destroy(grid[currentRow, currentColumn].topWall);
                    }
                }
            }
            // 2 is left wall
            else if (direction == 2)
            {
                Debug.Log("Check Left");

                if (CellUnvisitedBoundary(currentRow, currentColumn - 1))
                {
                    if (grid[currentRow, currentColumn].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }
                    currentColumn--;
                    grid[currentRow, currentColumn].visited = true;

                    if (grid[currentRow, currentColumn].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }
                }
            }
            // 3 is right wall
            else if (direction == 3)
            {
                Debug.Log("Check Right");

                if (CellUnvisitedBoundary(currentRow, currentColumn + 1))
                {
                    if (grid[currentRow, currentColumn].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }
                    currentColumn++;
                    grid[currentRow, currentColumn].visited = true;

                    if (grid[currentRow, currentColumn].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }
                }
            }
        }
    }
    private void HuntPath()
    {
        finishScanning = true;

        for (int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                if(!grid[i, j].visited && CheckVisitedNeighbours(i, j))
                {
                    finishScanning = false;
                    currentRow = i;
                    currentColumn = j;
                    grid[currentRow, currentColumn].visited = true;
                    DestroyAdjacentWalls();
                    return;
                }
            }
        }
    }
    void DestroyAdjacentWalls()
    {
        bool destroyed = false;
        while (!destroyed)
        {
            int direction = UnityEngine.Random.Range(0, 4);
            if (direction == 0)
            {
                    Debug.Log("Check Top");
                    if (currentRow > 0 && grid[currentRow - 1, currentColumn].visited)
                    {
                        if (grid[currentRow, currentColumn].topWall)
                        {
                            Destroy(grid[currentRow, currentColumn].topWall);
                        }
                        Debug.Log("Destroyed bottom wall." + (currentRow - 1) + " " + currentColumn);
                        if (grid[currentRow - 1, currentColumn].bottomWall)
                        {
                            Destroy(grid[currentRow - 1, currentColumn].bottomWall);
                        }
                    destroyed = true;
                    }
                }
                // 1 is bottom wall
            else if (direction == 1)
            {
                if (currentRow < rows - 1 && grid[currentRow + 1, currentColumn].visited)
                {
                    if (grid[currentRow, currentColumn].bottomWall)
                    {
                        Destroy(grid[currentRow, currentColumn].bottomWall);
                    }
                    Debug.Log("Destroyed top wall." + (currentRow + 1) + " " + currentColumn);
                    if (grid[currentRow + 1, currentColumn].topWall)
                    {
                        Destroy(grid[currentRow + 1, currentColumn].topWall);
                    }
                    destroyed = true;
                }   
            }
            // 2 is left wall
            else if (direction == 2)
            {
                if (currentColumn > 0 && grid[currentRow, currentColumn - 1].visited)
                {
                    if (grid[currentRow, currentColumn].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn].leftWall);
                    }
                    Debug.Log("Destroyed right wall." + currentRow + " " + (currentColumn - 1));
                    if (grid[currentRow, currentColumn - 1].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn - 1].rightWall);
                    }
                    destroyed = true;
                }
            }
            // 3 is right wall
            else if (direction == 3)
            {
                if (currentColumn < columns - 1 && grid[currentRow, currentColumn + 1].visited)
                {
                    if (grid[currentRow, currentColumn].rightWall)
                    {
                        Destroy(grid[currentRow, currentColumn].rightWall);
                    }
                    Debug.Log("Destroyed right wall." + currentRow + " " + (currentColumn + 1));
                    if (grid[currentRow, currentColumn + 1].leftWall)
                    {
                        Destroy(grid[currentRow, currentColumn + 1].leftWall);
                    }
                    destroyed = true;
                }
            }
        }
    }       
}
