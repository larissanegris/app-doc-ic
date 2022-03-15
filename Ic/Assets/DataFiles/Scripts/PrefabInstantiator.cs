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
            

            //Criar pai
            GameObject newParent = Instantiate(interactionBlock, floor.transform);
            newParent.transform.SetParent(floor.transform, true);
            
            myModelObject = Instantiate(cubePrefab, newParent.transform);
            myModelObject.transform.localScale = new Vector3(1f, 1f, 1f);
            myModelObject.transform.position = myModelObject.transform.position + new Vector3(0, 4, 0);
            myModelObject.SetActive(true);
            myModelObject.name = "Cube" + gameManager.GetNumberCube();

            myModelObject.transform.SetParent(newParent.transform, true);

            Debug.Log("Criando " + myModelObject.name);

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm(gameManager.GetNumber(), Type.Cube);
            gameManager.createdForms.Add(forma);

            newParent.name = "InteractionBlock" + forma.GetId();
            newParent.GetComponent<InteractionBlock>().AddInteraction(myModelObject);


            gameManager.IncreaseNumber();
            gameManager.IncreaseNumberCube();
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
            myModelObject.name = "Sphere" + gameManager.GetNumberSphere();
            Debug.Log(myModelObject.transform.position);

            Debug.Log("Criando " + myModelObject.name);

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm(gameManager.GetNumber(), Type.Sphere);
            gameManager.createdForms.Add(forma);

            gameManager.IncreaseNumber();
            gameManager.IncreaseNumberSphere();
            gameManager.ChangeSelectedObject(myModelObject);

            //Criar pai
            GameObject newParent = new GameObject("InteractionBlock" + gameManager.GetNumber());
            newParent.transform.parent = floor.transform;
            myModelObject.transform.parent = newParent.transform;
            newParent.AddComponent<InteractionBlock>();

            


            return myModelObject;
        }
        return null;
    }

    
}