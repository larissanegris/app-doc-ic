using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    public List<List<Interaction>> adjacencyMatrix = new List<List<Interaction>>() {  };
    [SerializeField]
    public List<List<float>> distanceMatrix = new List<List<float>>() { };
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
        if(!form1.gameObject.active || !form2.gameObject.active)
        {
            adjacencyMatrix[form1.GetId()][form2.GetId()] = Interaction.Deleted;
            adjacencyMatrix[form2.GetId()][form1.GetId()] = Interaction.Deleted;
            UpdateDistanceMatrixEntry(form1, form2, false);
            return;
        }
        adjacencyMatrix[form1.GetId()][form2.GetId()] = interactionType;
        adjacencyMatrix[form2.GetId()][form1.GetId()] = interactionType;
        UpdateDistanceMatrixEntry(form1, form2, true);
        //printAdjacencyMatrix();
    }

    public void UpdateDistanceMatrixEntry(Form form1, Form form2, bool isActive)
    {
        if (!isActive)
        {
            distanceMatrix[form1.GetId()][form2.GetId()] = -1;
            distanceMatrix[form2.GetId()][form1.GetId()] = -1;
            return;
        }
        float aux = Vector3.Distance(form1.gameObject.transform.position, form2.transform.position);
        distanceMatrix[form1.GetId()][form2.GetId()] = aux;
        distanceMatrix[form2.GetId()][form1.GetId()] = aux;
        //printAdjacencyMatrix();
    }

    private void AddNewEntry(GameObject gm )
    {
        List<Interaction> listAdj = new List<Interaction>() { Interaction.None };
        List<float> listDist = new List<float>() { 0 };

        for (int i = 0; i < adjacencyMatrix.Count ; i++ )
        {
            listAdj.Add( Interaction.None );
            listDist.Add(0);

            adjacencyMatrix[i].Add( Interaction.None );
            distanceMatrix[i].Add(0);
        }
        adjacencyMatrix.Add( listAdj );
        distanceMatrix.Add(listDist);

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
