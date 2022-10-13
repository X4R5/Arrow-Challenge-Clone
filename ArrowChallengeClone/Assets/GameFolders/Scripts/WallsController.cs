using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsController : MonoBehaviour
{
    List<GameObject> _walls = new List<GameObject>();
    public List<GameObject> Walls => _walls;
    void Awake()
    {
        var allWalls = GameObject.FindGameObjectsWithTag("Wall");
        for (int i = 0; i < allWalls.Length; i++)
        {
            _walls.Add(allWalls[i]);
        }
    }
}
