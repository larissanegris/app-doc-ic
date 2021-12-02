using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class PrefabInstantiator : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject imageTarget;
    private GameObject myModelObject;

    public Form forma;

    

    public GameObject SpawnCube()
    {
        if (cubePrefab != null)
        {
            Debug.Log("Target found, adding content");
            
            myModelObject = Instantiate(cubePrefab, imageTarget.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Cube" + gameManager.numberCube;

            forma = myModelObject.GetComponent<Form>();
            forma.tipo = Type.Cube;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);

            gameManager.ChangeSelectedObject(myModelObject);

            gameManager.number++;
            gameManager.numberCube++;

            return myModelObject;
        }
        return null;
    }

    public GameObject SpawnSphere()
    {
        if (spherePrefab != null)
        {
            Debug.Log("Target found, adding content");

            myModelObject = Instantiate(spherePrefab, imageTarget.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Sphere" + gameManager.numberSphere;
            Debug.Log(myModelObject.transform.position);

            forma = myModelObject.GetComponent<Form>();
            forma.tipo = Type.Sphere;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);

            gameManager.ChangeSelectedObject(myModelObject);
            gameManager.number++;
            gameManager.numberSphere++;

            return myModelObject;
        }
        return null;
    }

    
}