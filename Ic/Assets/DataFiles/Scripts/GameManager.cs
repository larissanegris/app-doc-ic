using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabInstantiator prefabInstantiator;
    public ColorManager colorManager;
    public GameObject selectedObject;
    public Form selectedObjectForm;

    public Rigidbody rigidbodiComponent;
    public BoxCollider boxCollider;
    public List<Form> createdForms = new List<Form>();

    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;

    public int tipoInteracao;

    private void Start()
    {
        colorManager = this.gameObject.GetComponent<ColorManager>();
    }

    public void ChangeSelectedObject(GameObject newSelectedGameObject)
    {
        if(number == 0)
        {
            selectedObject = newSelectedGameObject;
            selectedObject.GetComponent<Form>().SetToSelected();
            colorManager.DarkerColor(selectedObject);

            selectedObject.AddComponent(typeof(Rigidbody));
            rigidbodiComponent = selectedObject.GetComponent<Rigidbody>();
            rigidbodiComponent.useGravity = false;
            boxCollider = selectedObject.GetComponent<BoxCollider>();
            boxCollider.isTrigger = false;

            return;
        }
        selectedObject.GetComponent<Form>().SetToUnselected();
        colorManager.ChangeColor(selectedObject.GetComponent<Form>().cor, selectedObject);
        Destroy(selectedObject.GetComponent<Rigidbody>());
        boxCollider = selectedObject.GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;


        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObject = newSelectedGameObject;
        selectedObjectForm.saveColor();
        selectedObjectForm.SetToSelected();
        colorManager.DarkerColor(selectedObject);

        selectedObject.AddComponent(typeof(Rigidbody));
        rigidbodiComponent = selectedObject.GetComponent<Rigidbody>();
        rigidbodiComponent.useGravity = false;
        boxCollider = selectedObject.GetComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
}
