using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabInstantiator prefabInstantiator;
    public ColorManager colorManager;
    public GameObject selectedObject;

    public List<Form> createdForms = new List<Form>();

    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;

    public int tipoInteracao;

    private void Start()
    {
        colorManager = this.gameObject.GetComponent<ColorManager>();
        //selectedObject = null;
    }

    public void Update()
    {
        
    }
    public void ChangeSelectedObject(GameObject newSelectedGameObject)
    {
        if(number == 0)
        {
            selectedObject = newSelectedGameObject;
            selectedObject.GetComponent<Form>().SetToSelected();
            colorManager.DarkerColor(selectedObject);
            return;
        }
        selectedObject.GetComponent<Form>().SetToUnselected();
        colorManager.ChangeColor(selectedObject.GetComponent<Form>().cor, selectedObject);
        
        selectedObject = newSelectedGameObject;
        selectedObject.GetComponent<Form>().SetToSelected();
        colorManager.DarkerColor(selectedObject);
    }
}
