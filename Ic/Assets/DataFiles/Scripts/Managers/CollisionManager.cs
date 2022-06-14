using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField] public List<List<Interaction>> adjacencyMatrix = new List<List<Interaction>>() {  };
    GameManager gameManager;
    GameObject selectedObject;

    private void Awake()
    {
        FindObjectOfType<InstantiationManager>().Instantiation += AddNewEntry;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        
    }

    private void Update()
    {
        
    }

    public void UpdateAdjacencyMatrix(Form form, Interaction interactionType)
    {
        selectedObject = gameManager.GetSelectedObject();
        Form selectedForm = selectedObject.GetComponent<Form>();
        adjacencyMatrix[selectedForm.GetId()][form.GetId()] = interactionType;
        adjacencyMatrix[form.GetId()][selectedForm.GetId()] = interactionType;

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
