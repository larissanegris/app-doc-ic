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
         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public GameObject SpawnCube( GameObject parent )
    {
        if ( cubePrefab != null )
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.numberSphere;

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm( gameManager.number, FormType.Cube );
            gameManager.createdForms.Add( forma );

            return myModelObject;
        }
        return null;
    }

    public GameObject SpawnSphere(GameObject parent)
    {
        if (spherePrefab != null)
        {
            GameObject myModelObject = Instantiate(spherePrefab, parent.transform);
            myModelObject.name = "Sphere" + gameManager.numberSphere;

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm(gameManager.number++, FormType.Sphere);
            gameManager.createdForms.Add(forma);

            return myModelObject;
        }
        return null;
    }

    public GameObject Spawn(FormType type, bool isTransparent)
    {
        //Criar pai
        GameObject newParent = Instantiate(interactionBlock, floor.transform);
        newParent.transform.SetParent( floor.transform, true );
        
        GameObject modelObject;

        if(type == FormType.Cube )
        {
            modelObject = SpawnCube( newParent );

            gameManager.numberCube++;

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentCube;
            }
        }
        else
        {
            modelObject = SpawnSphere( newParent );

            gameManager.numberSphere++;

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentSphere;
            }
        }
        gameManager.number++;
        Debug.Log( "Model: " + modelObject.name );
        gameManager.ChangeSelectedObject( modelObject );
        gameManager.createdBlocks.Add( newParent.GetComponent<InteractionBlock>() );


        modelObject.transform.SetParent( newParent.transform, true );


        modelObject.transform.localScale = new Vector3( 1f, 1f, 1f );
        modelObject.transform.position = modelObject.transform.position + new Vector3( 0, 4, 0 );
        modelObject.SetActive( true );

        newParent.name = "InteractionBlock" + forma.GetId();
        newParent.GetComponent<InteractionBlock>().AddInteraction( modelObject );


        return modelObject;
        
    }

    
}