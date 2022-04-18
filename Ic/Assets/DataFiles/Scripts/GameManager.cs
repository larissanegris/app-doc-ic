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
    [SerializeField] public GameObject cameraObject;

    public List<Form> createdForms = new List<Form>();
    public List<InteractionBlock> createdBlocks = new List<InteractionBlock>();

    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;
    //[SerializeField] private bool hasSelectedObject = false;

    public int tipoInteracao = 0; //Com o que interage
    public bool blockInteraction = false;
    public bool moveCamera = false;
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

    public void ChangeBlockInteraction()
    {
        blockInteraction = !blockInteraction;
    }

    public void ChangeMoveCamera()
    {
        moveCamera = !moveCamera;
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
    public void ChangeTipoConecao(  )
    {
        if(tipoConecao == 3 )
        {
            tipoConecao = 0;
        }
        else
        {
            tipoConecao++;
        }
    }

    public void ChangeTipoInteracao(int novaInteracao )
    {
        tipoInteracao = novaInteracao;
        if(novaInteracao == 3 )
        {
            moveCamera = true;
        }
        else
        {
            moveCamera = false;
        }
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

        if(selectedObjectForm == form )
        {
            selectedObject = null;
            selectedObjectForm = null;
        }

        number -= 1;
        if(form.GetFormType() == FormType.Cube )
        {
            numberCube -= 1;
        }
        else if(form.GetFormType()== FormType.Sphere )
        {
            numberSphere -= 1;
        }

    }
}
