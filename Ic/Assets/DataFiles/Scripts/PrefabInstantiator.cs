using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class PrefabInstantiator : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject imageTarget;
    private GameObject mMyModelObject;

    public Form forma;

    

    public GameObject SpawnCube()
    {
        if (cubePrefab != null)
        {
            Debug.Log("Target found, adding content");
            
            mMyModelObject = Instantiate(cubePrefab, imageTarget.transform);
            mMyModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            mMyModelObject.transform.position = mMyModelObject.transform.position + new Vector3(0, 4, 0);
            mMyModelObject.SetActive(true);
            mMyModelObject.name = "Cube" + gameManager.numberCube;

            forma = mMyModelObject.GetComponent<Form>();
            forma.tipo = Type.Cube;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);
            mMyModelObject.GetComponent<Interactions>().SetForm(mMyModelObject);

            gameManager.number++;
            gameManager.numberCube++;

            return mMyModelObject;
        }
        return null;
    }

    public GameObject SpawnSphere()
    {
        if (spherePrefab != null)
        {
            Debug.Log("Target found, adding content");

            mMyModelObject = Instantiate(spherePrefab, imageTarget.transform);
            mMyModelObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            //mMyModelObject.transform.position = mMyModelObject.transform.position + new Vector3(0, 0, gameManager.numberSphere);
            mMyModelObject.SetActive(true);
            mMyModelObject.name = "Sphere" + gameManager.numberSphere;
            Debug.Log(mMyModelObject.transform.position);
            
            forma = mMyModelObject.GetComponent<Form>();
            forma.tipo = Type.Sphere;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);

            gameManager.number++;
            gameManager.numberSphere++;

            return mMyModelObject;
        }
        return null;
    }

    
}