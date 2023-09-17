using UnityEngine;
using System.Collections.Generic;
using System;

public class InstantiationManager : MonoBehaviour
{
    private GameManager gameManager;
    private TouchSelectionManager touchSelectionManager;

    [Header("Prefabs")]
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject cubeVolumePrefab;
    public GameObject sphereVolumePrefab;
    public Vector3 offset;

    [Header("Materials")]
    [SerializeField]
    private Material transparentCube;
    [SerializeField]
    private Material transparentSphere;

    [SerializeField]
    private GameObject parent;

    public event Action<GameObject> Instantiation;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
    }

    public GameObject Spawn(FormType type, bool isTransparent)
    {

        GameObject modelObject;

        if (type == FormType.Cube)
            modelObject = SpawnCube(parent.gameObject, isTransparent);
        else
            modelObject = SpawnSphere(parent.gameObject, isTransparent);

        modelObject.SetActive(true);

        if (Instantiation != null && modelObject != null)
            Instantiation(modelObject);

        //selectionManager.ChangeSelectedObject( modelObject );
        gameManager.colorManager.ChangeColor(-1, modelObject);
        return modelObject;

    }

    public GameObject Load(Form form, bool isTransparent)
    {

        GameObject modelObject;

        if (form.GetFormType() == FormType.Cube)
        {
            modelObject = LoadCube(parent.gameObject, form);

            if (isTransparent)
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentCube;
            }
            gameManager.colorManager.ChangeColor((int)form.pp, modelObject);
        }
        else
        {
            modelObject = SpawnSphere(parent.gameObject, isTransparent);

            if (isTransparent)
            {
                modelObject.GetComponent<MeshRenderer>().material = transparentSphere;
            }
            gameManager.colorManager.ChangeColor((int)form.pp - 4, modelObject);
        }

        modelObject.SetActive(true);

        if (Instantiation != null && modelObject != null)
        {
            Instantiation(modelObject);
        }

        Debug.Log("Loaded Cube");
        return modelObject;

    }

    public GameObject SpawnCube( GameObject parent, bool isTransparent)
    {
        if ( cubePrefab != null )
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.numberCube;
            myModelObject.transform.position = myModelObject.transform.position + offset;

            if (isTransparent)
                myModelObject.GetComponent<MeshRenderer>().material = transparentCube;

            Form forma = myModelObject.GetComponent<Form>();
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

    public GameObject SpawnSphere(GameObject parent, bool isTransparent)
    {
        if (spherePrefab != null)
        {
            GameObject myModelObject = Instantiate(spherePrefab, parent.transform);
            myModelObject.name = "Sphere" + gameManager.numberSphere;
            myModelObject.transform.position = myModelObject.transform.position + offset;

            if (isTransparent)
                myModelObject.GetComponent<MeshRenderer>().material = transparentSphere;

            Form forma = myModelObject.GetComponent<Form>();
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

    public GameObject LoadCube(GameObject parent, Form loaded)
    {
        if (cubePrefab != null)
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + loaded.GetId();

            Form form = myModelObject.GetComponent<Form>();
            form.LoadForm(loaded);

            if (cubeVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(cubeVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Cube" + gameManager.numberCube + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentCube;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive(gameManager.displayVolume);
                form.volume = interactionVolume;
            }

            return myModelObject;
        }
        return null;
    }

    public GameObject LoadSphere(GameObject parent, Form loaded)
    {
        if (cubePrefab != null)
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Sphere" + loaded.GetId();

            Form form = myModelObject.GetComponent<Form>();
            form.LoadForm(loaded);

            if (sphereVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(sphereVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Sphere" + gameManager.numberCube + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentSphere;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive(gameManager.displayVolume);
                form.volume = interactionVolume;
            }

            return myModelObject;
        }
        return null;
    }

    public GameObject Copy(GameObject go)
    {
        if (go == null)
            return null;
        GameObject modelObject;
        if (go.GetComponent<Form>().GetFormType() == FormType.Cube)
            modelObject = CopyCube(go, parent, go.GetComponent<Form>().transparent);
        else
            modelObject = CopySphere(go, parent, go.GetComponent<Form>().transparent);

        modelObject.SetActive(true);

        go.GetComponent<Form>().SetToUnselected();
        modelObject.GetComponent<Form>().SetToSelected();

        if (Instantiation != null && modelObject != null)
            Instantiation(modelObject);

        return modelObject;
    }

    public GameObject CopyCube(GameObject go, GameObject parent, bool isTransparent)
    {
        if (cubePrefab != null)
        {
            GameObject myModelObject = Instantiate(cubePrefab, parent.transform);
            myModelObject.name = "Cube" + gameManager.numberCube;
            myModelObject.transform.position = go.transform.position + offset;
            myModelObject.transform.rotation = go.transform.rotation;
            myModelObject.transform.localScale = go.transform.localScale;


            if (isTransparent)
                myModelObject.GetComponent<MeshRenderer>().material = transparentCube;

            Form forma = myModelObject.GetComponent<Form>();
            forma.CreateForm(gameManager.number, FormType.Cube);

            if (cubeVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(cubeVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Cube" + gameManager.numberCube + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentCube;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive(gameManager.displayVolume);
                forma.volume = interactionVolume;
            }

            gameManager.colorManager.ChangeColor(go.GetComponent<Form>().cor, myModelObject);
            return myModelObject;
        }
        return null;
    }

    public GameObject CopySphere(GameObject go, GameObject parent, bool isTransparent)
    {
        if (spherePrefab != null)
        {
            GameObject myModelObject = Instantiate(go, parent.transform);
            myModelObject.name = "Sphere" + gameManager.numberSphere;
            myModelObject.transform.position = go.transform.position + offset;
            myModelObject.transform.rotation = go.transform.rotation;
            myModelObject.transform.localScale = go.transform.localScale;

            if (isTransparent)
                myModelObject.GetComponent<MeshRenderer>().material = transparentSphere;

            Form forma = myModelObject.GetComponent<Form>();
            forma.CreateForm(gameManager.number, FormType.Sphere);

            if (cubeVolumePrefab != null)
            {
                GameObject interactionVolume = Instantiate(sphereVolumePrefab, myModelObject.transform);
                interactionVolume.name = "Sphere" + gameManager.numberSphere + " Volume";
                interactionVolume.GetComponent<MeshRenderer>().material = transparentSphere;
                interactionVolume.transform.localScale = 1.5f * Vector3.one;
                interactionVolume.SetActive(gameManager.displayVolume);
                forma.volume = interactionVolume;
            }


            return myModelObject;
        }
        return null;
    }
}