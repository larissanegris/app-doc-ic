using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] public List<List<Interaction>> adjacencyMatrix = new List<List<Interaction>>() {  };
    GameManager gameManager;
    TouchSelectionManager touchSelectionManager;
    GameObject selectedObject;

    private void Awake()
    {
        FindObjectOfType<InstantiationManager>().Instantiation += AddNewEntry;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        
    }

    public void UpdateAdjacencyMatrixEntry(Form form1, Form form2, Interaction interactionType)
    {
        adjacencyMatrix[form1.GetId()][form2.GetId()] = interactionType;
        adjacencyMatrix[form2.GetId()][form1.GetId()] = interactionType;
        //printAdjacencyMatrix();
    }

    private void AddNewEntry(GameObject gm )
    {
        List<Interaction> list = new List<Interaction>() { Interaction.None };
        for(int i = 0; i < adjacencyMatrix.Count ; i++ )
        {
            list.Add( Interaction.None );
            adjacencyMatrix[i].Add( Interaction.None );
        }
        adjacencyMatrix.Add( list );

        //printAdjacencyMatrix();
    }

    private void printAdjacencyMatrix()
    {
        Debug.Log( "AdjacencyMatrix" );
        string s = "";

        for ( int i = 0; i < adjacencyMatrix.Count; i++ )
        {
            s = "";
            for ( int j = 0; j < adjacencyMatrix[0].Count; j++ )
            {
               s += adjacencyMatrix[i][j].ToString() + " ";
            }
            Debug.Log( "Linha " + i + ": " + s );
        }
    }

}
