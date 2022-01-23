using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeCell : MonoBehaviour
{
    // After creating a grid, we need to make the Top, Bottom, Left, Right walls a cell, so if we have 4x4, we will have 16 cells.
    // Check to see if a cell and a wall has been visited.
    public bool visited = false;
    // Using these gameobjects and making them = to the walls we create in the generator
    public GameObject topWall, bottomWall, leftWall, rightWall;
}
