using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteFile : MonoBehaviour
{
    private GameManager gameManager;
    private CollisionManager collisionManager;
    
    public string path = "C:/Data/";
    public string fileName = "test.csv";
    public string text = "HelloWord";

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        collisionManager = GameObject.Find("GameManager").GetComponent<CollisionManager>();
    }

    public void WriteAdjacencyMatrixToFile()
    {
        WriteToFile(path, "adjacencyMatrix.csv", AdjacencyMatrixToStr());
        WriteToFile(path, "objectColor.txt", FormsToStr());
        Debug.Log("WritenToFile");
    }

    public void WriteToFile(string dir, string fileName, string data)
    {
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
        File.WriteAllText(path + fileName, data);
    }

    private string AdjacencyMatrixToStr()
    {
        string str = "name, ";

        for (int j = 0; j < collisionManager.distanceMatrix.Count; j++)
        {
            if (!gameManager.createdForms[j].isActiveAndEnabled)
                continue;
            str += gameManager.createdForms[j].name + ", ";
        }
        str += "\n";
        for (int i = 0; i < collisionManager.distanceMatrix.Count; i++)
        {
            if (!gameManager.createdForms[i].isActiveAndEnabled)
                continue;
            str += gameManager.createdForms[i].name + ", ";
            for (int j = 0; j < collisionManager.distanceMatrix.Count; j++)
            {
                if (!gameManager.createdForms[j].isActiveAndEnabled)
                    continue;
                str += string.Format("{0:N2}", collisionManager.distanceMatrix[i][j]).Replace(",", ".") + ", ";
            }
            str += "\n";
        }

        return str;
    }

    private string FormsToStr()
    {
        string str = "";

        for (int j = 0; j < gameManager.createdForms.Count; j++)
        {
            str += gameManager.createdForms[j].name + ", ";
            str += gameManager.createdForms[j].GetFormType() + ", ";
            str += gameManager.createdForms[j].pp;
            str += "\n";
        }
       

        return str;
    }
}
