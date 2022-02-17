using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class PrefabInstantiator : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject interactionBlock;
    public GameObject imageTarget;
    private GameObject myModelObject;

    public Form forma;
    public GameObject floor;

    private void Awake()
    {
        floor = GameObject.Find("Floor");
    }

    public GameObject SpawnCube()
    {
        if (cubePrefab != null)
        {
            myModelObject = Instantiate(cubePrefab, floor.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Cube" + gameManager.numberCube;

            Debug.Log("Criando " + myModelObject.name);

            forma = myModelObject.GetComponent<Form>();
            forma.type = Type.Cube;
            forma.id = gameManager.number;
            gameManager.createdForms.Add(forma);

            //Criar pai
            GameObject newParent = Instantiate(interactionBlock, floor.transform);
            newParent.transform.SetParent(floor.transform, true);
            myModelObject.transform.SetParent(newParent.transform, true);
            newParent.GetComponent<InteractionBlock>().AddInteraction(forma);
            newParent.name = "InsteractionBlock" + forma.id;

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

            //Criar pai
            GameObject newParent = new GameObject("InteractionBlock" + gameManager.number);
            newParent.transform.parent = floor.transform;
            myModelObject.transform.parent = newParent.transform;
            newParent.AddComponent<InteractionBlock>();

            gameManager.number++;
            gameManager.numberSphere++;
            gameManager.ChangeSelectedObject(myModelObject);


            return myModelObject;
        }
        return null;
    }

    
}