using UnityEngine;
using Vuforia;
using System.Collections.Generic;

public class PrefabInstantiator : MonoBehaviour
{
    public GameManager gameManager;
    public SelectionManager selectionManager;

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
         selectionManager = gameManager.GetComponent<SelectionManager>();
    }

    public GameObject SpawnCube( GameObject parent )
    {
        if ( cubePrefab != null )
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.numberCube;

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm( gameManager.number, FormType.Cube );
            gameManager.createdForms.Add( forma );

            if (gameManager.displayVolume )
            {
                GameObject interactionVolume = Instantiate(cubePrefab, myModelObject.transform);
                interactionVolume.name = "Cube" + gameManager.numberCube + "Interaction Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentCube;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
            }
            

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
            forma.CreateForm(gameManager.number, FormType.Sphere);
            gameManager.createdForms.Add(forma);

            return myModelObject;
        }
        return null;
    }

    public GameObject Spawn(FormType type, bool isTransparent)
    {
        
        GameObject modelObject;

        if(type == FormType.Cube )
        {
            modelObject = SpawnCube( floor.gameObject );

            gameManager.numberCube++;

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentCube;
            }
        }
        else
        {
            modelObject = SpawnSphere( floor.gameObject );

            gameManager.numberSphere++;

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentSphere;
            }
        }
        gameManager.number++;
        Debug.Log( "Model: " + modelObject.name );
        
        selectionManager.ChangeSelectedObject(modelObject);


        modelObject.transform.localScale = new Vector3( 1f, 1f, 1f );
        modelObject.transform.position = modelObject.transform.position + new Vector3( 0, 4, 0 );
        modelObject.SetActive( true );

        return modelObject;
        
    }    
}