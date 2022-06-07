using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] private List<List<int>> adjacencyMatrix = new List<List<int>>() { new List<int>() { 0 }  };
    GameManager gameManager;

    private void Awake()
    {
        FindObjectOfType<InstantiationManager>().Instantiation += AddNewEntry;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }

    private void Update()
    {
        
    }

    private void UpdateAdjacencyMatrix()
    {

    }

    private void AddNewEntry(GameObject gm )
    {
        Debug.Log( "AA" );
    }
}
