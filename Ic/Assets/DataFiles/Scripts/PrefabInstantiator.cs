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

    [SerializeField]
    private Material transparentCube;
    [SerializeField]
    private Material transparentSphere;

    public Form forma;
    public GameObject floor;

    private void Awake()
    {
        floor = GameObject.Find("Floor");
    }

    public GameObject SpawnCube(GameObject parent)
    {
        if (cubePrefab != null)
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.GetNumberCube();
            
            return myModelObject;
        }
        return null;
    }

    public GameObject SpawnSphere( GameObject parent )
    {
        if (spherePrefab != null)
        {
            GameObject myModelObject = Instantiate(spherePrefab, parent.transform);
            myModelObject.name = "Sphere" + gameManager.GetNumberSphere();
            

            return myModelObject;
        }
        return null;
    }

    public GameObject Spawn( Type tipo, bool isTransparent )
    {
        //Criar pai
        GameObject newParent = Instantiate(interactionBlock, floor.transform);
        newParent.transform.SetParent( floor.transform, true );
        GameObject myModelObject;

        if (tipo == Type.Cube )
        {
            myModelObject = SpawnCube(newParent);
            if ( isTransparent )
            {
                myModelObject.GetComponent<MeshRenderer>().material = transparentCube;
            }
        }
        else
        {
            myModelObject = SpawnSphere(newParent);
            if ( isTransparent )
            {
                myModelObject.GetComponent<MeshRenderer>().material = transparentSphere;
            }
        }

        myModelObject.transform.SetParent( newParent.transform, true );

        myModelObject.transform.localScale = new Vector3( 1f, 1f, 1f );
        myModelObject.transform.localPosition = new Vector3( 0, 0, 0f );
        myModelObject.SetActive( true );


        forma = myModelObject.GetComponent<Form>();
        forma.CreateForm( gameManager.GetNumber(), Type.Cube );
        gameManager.createdForms.Add( forma );

        newParent.name = "InteractionBlock" + forma.GetId();
        newParent.GetComponent<InteractionBlock>().AddInteraction( myModelObject );


        gameManager.IncreaseNumber();
        gameManager.IncreaseNumberCube();
        gameManager.ChangeSelectedObject( myModelObject );

        return myModelObject;
    }
    
}