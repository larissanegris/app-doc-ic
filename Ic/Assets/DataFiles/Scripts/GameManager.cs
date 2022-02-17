using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabInstantiator prefabInstantiator;
    public ColorManager colorManager;
    public HighlightManager highlightManager;
    public InteractionManager interactionManager;
    public GameObject selectedObject;
    public Form selectedObjectForm;

    public Rigidbody rigidbodiComponent;
    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;
    public List<Form> createdForms = new List<Form>();

    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;
    public bool hasSelectedObject = false;

    public int tipoInteracao;
    public bool blockInteraction = false;

    private void Start()
    {
        colorManager = GetComponent<ColorManager>();
        highlightManager = GetComponent<HighlightManager>();
        interactionManager = GetComponent<InteractionManager>();
    }

    public void ChangeSelectedObject(GameObject newSelectedGameObject)
    {
        //se for o unico objeto, nao precisa modificar o antigo selecionado
        if(number == 1)
        {
            //seleciona novo objeto
            selectedObject = newSelectedGameObject;
            selectedObjectForm = selectedObject.GetComponent<Form>();
            selectedObject.GetComponent<Form>().SetToSelected();

            //muda tag
            selectedObject.tag = "Selected";

            //colorManager.DarkerColor(selectedObject);
            highlightManager.HighlightObject(selectedObject);

            //adiciona rigidbody
            selectedObject.AddComponent(typeof(Rigidbody));
            rigidbodiComponent = selectedObject.GetComponent<Rigidbody>();
            rigidbodiComponent.useGravity = false;
            
            //verifica se é cubo ou esfera
            if(selectedObjectForm.type == Type.Cube)
            {
                boxCollider = selectedObject.GetComponent<BoxCollider>();
                boxCollider.isTrigger = false;
            }
            else if(selectedObjectForm.type == Type.Sphere)
            {
                sphereCollider = selectedObject.GetComponent<SphereCollider>();
                sphereCollider.isTrigger = false;
            }

            hasSelectedObject = true;
            

            return;
        }

        //tem outras formas criadas

        //muda tag da antiga
        selectedObject.tag = "Selectable";

        //deseleciona forma antiga
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.SetToUnselected();
        Destroy(selectedObject.GetComponent<Rigidbody>());

        //colorManager.ChangeColor(selectedObjectForm.cor, selectedObject);
        highlightManager.UnhighlightObject(selectedObject);


        //verifica o tipo
        if (selectedObjectForm.type == Type.Cube)
        {
            boxCollider = selectedObject.GetComponent<BoxCollider>();
            boxCollider.isTrigger = true;
        }
        else if (selectedObjectForm.type == Type.Sphere)
        {
            sphereCollider = selectedObject.GetComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
        }

        //seleciona forma nova
        selectedObject = newSelectedGameObject;
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.saveColor();
        selectedObjectForm.SetToSelected();

        //colorManager.DarkerColor(selectedObject);
        highlightManager.HighlightObject(selectedObject);

        selectedObject.AddComponent(typeof(Rigidbody));
        rigidbodiComponent = selectedObject.GetComponent<Rigidbody>();
        rigidbodiComponent.useGravity = false;

        //muda tag
        selectedObject.tag = "Selected";

        //verifica se é cubo ou esfera
        if (selectedObjectForm.type == Type.Cube)
        {
            boxCollider = selectedObject.GetComponent<BoxCollider>();
            boxCollider.isTrigger = false;
        }
        else if (selectedObjectForm.type == Type.Sphere)
        {
            sphereCollider = selectedObject.GetComponent<SphereCollider>();
            sphereCollider.isTrigger = false;
        }
    }

    public void changeBlockInteraction()
    {
        blockInteraction = !blockInteraction;
    }
}
