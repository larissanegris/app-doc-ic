using UnityEngine;
using Vuforia;
using System;

public class InstantiationManager : MonoBehaviour
{
    [Header("Managers")]
    public GameManager gameManager;
    public SelectionManager selectionManager;

    [Header("Prefabs")]
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cubeVolumePrefab;
    public GameObject sphereVolumePrefab;

    [Header("Materials")]
    [SerializeField]
    private Material transparentCube;
    [SerializeField]
    private Material transparentSphere;


    private Form forma;
    private GameObject parent;

    public event Action<GameObject> Instantiation;

    private void Awake()
    {
         parent = GameObject.Find("Parent");
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

            if (gameManager.displayVolume && cubeVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(cubeVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Cube" + gameManager.numberCube + " Volume";                interactionVolume.GetComponent<MeshRenderer>().material = transparentCube;
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

            return myModelObject;
        }
        return null;
    }

    public GameObject Spawn(FormType type, bool isTransparent)
    {
        
        GameObject modelObject;

        if(type == FormType.Cube )
        {
            modelObject = SpawnCube( parent.gameObject );

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentCube;
            }
        }
        else
        {
            modelObject = SpawnSphere( parent.gameObject );

            if ( isTransparent )
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentSphere;
            }
        }

        //Debug.Log( "Model: " + modelObject.name );

        //modelObject.transform.localScale = new Vector3( 1f, 1f, 1f );
        //modelObject.transform.position = modelObject.transform.position + new Vector3( 0, 0, 0 );
        modelObject.SetActive( true );

        if (Instantiation != null )
        {
            Instantiation( modelObject );
        }
        
        //selectionManager.ChangeSelectedObject( modelObject );

        return modelObject;
        
    }    
}