using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    List<GameObject> _enemies = new List<GameObject>();
    public List<GameObject> Enemies => _enemies;
    void Awake()
    {
        var allWalls = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < allWalls.Length; i++)
        {
            _enemies.Add(allWalls[i]);
        }
    }
}
