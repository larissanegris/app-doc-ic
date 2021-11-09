using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class PrefabInstantiator : DefaultObserverEventHandler
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject imageTarget;


    public List<Form> formasCriadas = new List<Form>();
    public Form forma;

    public static int number = 0;
    public static int numberCube = 0;
    public static int numberSphere = 0;

    private GameObject mMyModelObject;

    public GameObject SpawnCube()
    {
        if (cubePrefab != null)
        {
            Debug.Log("Target found, adding content");
            
            mMyModelObject = Instantiate(cubePrefab, imageTarget.transform);
            mMyModelObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            mMyModelObject.transform.position = mMyModelObject.transform.position + new Vector3(numberCube, 0, 0);
            mMyModelObject.SetActive(true);
            //mMyModelObject.GetComponent<Renderer>().material.color = Color.blue;
            mMyModelObject.name = "Cube" + numberCube;
            Debug.Log(mMyModelObject.transform.position);

            forma = mMyModelObject.GetComponent<Form>();
            forma.tipo = 0;
            forma.id = number;
            formasCriadas.Add(forma);
            forma.SetForm(mMyModelObject);

            number++;
            numberCube++;

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
            mMyModelObject.transform.position = mMyModelObject.transform.position + new Vector3(0, 0, numberSphere);
            mMyModelObject.SetActive(true);
            mMyModelObject.name = "Sphere" + numberSphere;
            Debug.Log(mMyModelObject.transform.position);

            forma.tipo = 1;
            forma.id = number;
            formasCriadas.Add(forma);

            number++;
            numberSphere++;

            return mMyModelObject;
        }
        return null;
    }

    
}