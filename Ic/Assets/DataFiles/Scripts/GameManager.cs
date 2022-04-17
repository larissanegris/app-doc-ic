using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabInstantiator prefabInstantiator;
    public ColorManager colorManager;
    public HighlightManager highlightManager;

    [SerializeField] private GameObject selectedObject;
    [SerializeField] private Form selectedObjectForm;

    public List<Form> createdForms = new List<Form>();
    public List<InteractionBlock> createdBlocks = new List<InteractionBlock>();

    [SerializeField] private int number = 0;
    [SerializeField] private int numberCube = 0;
    [SerializeField] private int numberSphere = 0;
    //[SerializeField] private bool hasSelectedObject = false;

    public int tipoInteracao = 0;
    public bool blockInteraction = false;
    public int tipoConecao = 0;

    private void Start()
    {
        colorManager = GetComponent<ColorManager>();
        highlightManager = GetComponent<HighlightManager>();
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

            //hasSelectedObject = true;
            
            return;
        }

        //tem outras formas criadas

        //muda tag da antiga
        selectedObject.tag = "Selectable";

        //deseleciona forma antiga
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.SetToUnselected();

        //colorManager.ChangeColor(selectedObjectForm.cor, selectedObject);
        highlightManager.UnhighlightObject(selectedObject);


        //seleciona forma nova
        selectedObject = newSelectedGameObject;
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.saveColor();
        selectedObjectForm.SetToSelected();

        //colorManager.DarkerColor(selectedObject);
        highlightManager.HighlightObject(selectedObject);

        //muda tag
        selectedObject.tag = "Selected";
        Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
    }

    public void changeBlockInteraction()
    {
        blockInteraction = !blockInteraction;
    }

    public int GetNumber()
    {
        return number;
    }
    public void IncreaseNumber()
    {
        number++;
    }
    public void DecreaseNumber()
    {
        number--;
    }

    public int GetNumberCube()
    {
        return numberCube;
    }
    public void IncreaseNumberCube()
    {
        numberCube++;
    }
    public void DecreaseNumberCube()
    {
        numberCube--;
    }

    public int GetNumberSphere()
    {
        return numberSphere;
    }
    public void IncreaseNumberSphere()
    {
        numberSphere++;
    }
    public void DecreaseNumberSphere()
    {
        numberSphere--;
    }
    public GameObject GetSelectedObject()
    {
        return selectedObject;
    }
    public Form GetSelectedObjectForm()
    {
        return selectedObjectForm;
    }

    public int GetTipoConecao()
    {
        return tipoConecao;
    }
    public void SetTipoConecao( int value )
    {
        tipoConecao = value;
    }

    public void RestrainPoint( Vector3 point )
    {
        selectedObject.GetComponent<MoveObject>().SetRestraintPoint( point );
    }
    public void RestrainMaxDistance( Vector3 dis )
    {
        selectedObject.GetComponent<MoveObject>().SetMaxDistance( dis );
    }

    public void RestrainMinDistance( Vector3 dis )
    {
        selectedObject.GetComponent<MoveObject>().SetMinDistance( dis );
    }

    /*
    public void FaceToFace()
    {
        MoveObject mv = mover.GetComponent<MoveObject>();
        Vector3 pointOnFace = mv.clo
        if ( mv != null )
        {
            mv.MoveToPosition(pointOnFace + dst);
        }
    }*/

    public void Restart()
    {
        selectedObject = null;
        selectedObjectForm = null;

        foreach(InteractionBlock interactionBlock in createdBlocks )
        {
            interactionBlock.DeletedBlock();
        }

        number = 0;
        numberCube = 0;
        numberSphere = 0;

        tipoInteracao = 0;
        blockInteraction = false;
        tipoConecao = 0;

    }

    public void DeleteGameObect(Form form )
    {
        form.GetComponentInParent<InteractionBlock>().DeleteForm( form );
    }
}
