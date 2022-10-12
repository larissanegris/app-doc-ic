using UnityEngine;
using Vuforia;
using System;

public class InstantiationManager : MonoBehaviour
{
    private GameManager gameManager;

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

    [SerializeField]
    private Form forma;
    [SerializeField]
    private GameObject parent;

    public event Action<GameObject> Instantiation;

    private void Awake()
    {
         //parent = GameObject.Find("Parent");
         gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public GameObject SpawnCube( GameObject parent )
    {
        if ( cubePrefab != null )
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.numberCube;

            forma = myModelObject.GetComponent<Form>();
            forma.CreateForm( gameManager.number, FormType.Cube );

            if (cubeVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(cubeVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Cube" + gameManager.numberCube + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentCube;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive( gameManager.displayVolume );
                forma.volume = interactionVolume;
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

            if ( sphereVolumePrefab != null )
            {
                GameObject interactionVolume = Instantiate(sphereVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Sphere" + gameManager.numberCube + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentSphere;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive( gameManager.displayVolume );
                forma.volume = interactionVolume;
            }

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


        modelObject.SetActive( true );

        if (Instantiation != null && modelObject != null)
        {
            Instantiation( modelObject );
        }
        
        //selectionManager.ChangeSelectedObject( modelObject );

        return modelObject;
        
    }    
}