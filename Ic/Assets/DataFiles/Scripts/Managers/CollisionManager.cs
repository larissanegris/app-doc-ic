using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] public List<List<int>> adjacencyMatrix = new List<List<int>>() { new List<int>() {  }  };
    GameManager gameManager;

    private void Awake()
    {
        FindObjectOfType<InstantiationManager>().Instantiation += AddNewEntry;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        Debug.Log(adjacencyMatrix[0].Count);
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
        if( gameManager.number == 0 )
        {
            adjacencyMatrix[0].Add( 0 );
        }
        else
        {
            List<int> list = new List<int>() {0};
            for(int i = 0; i < adjacencyMatrix.Count ; i++ )
            {
                list.Add( 0 );
                adjacencyMatrix[i].Add( 0 );
            }
        }
    }
}
