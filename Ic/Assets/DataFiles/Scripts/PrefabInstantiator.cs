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
            myModelObject = Instantiate(cubePrefab, imageTarget.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Cube" + gameManager.numberCube;

            Debug.Log("Criando " + myModelObject.name);

            forma = myModelObject.GetComponent<Form>();
            forma.type = Type.Cube;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);

            gameManager.number++;
            gameManager.numberCube++;

            gameManager.ChangeSelectedObject(myModelObject);

            return myModelObject;
        }
        return null;
    }

    public GameObject SpawnSphere()
    {
        if (spherePrefab != null)
        {

            myModelObject = Instantiate(spherePrefab, imageTarget.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Sphere" + gameManager.numberSphere;
            Debug.Log(myModelObject.transform.position);

            Debug.Log("Criando " + myModelObject.name);

            forma = myModelObject.GetComponent<Form>();
            forma.type = Type.Sphere;
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