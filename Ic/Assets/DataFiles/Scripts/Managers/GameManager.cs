using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]

    public PrefabInstantiator prefabInstantiator;
    public ColorManager colorManager;
    public HighlightManager highlightManager;
    
    [Header("Object Controllers")]
    public Move move;
    public Rotate rotate;

    [Header("Formas")]
    [SerializeField] public GameObject selectedObject;
    [HideInInspector] public Form selectedObjectForm;
    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;
    public List<Form> createdForms = new List<Form>();
    public List<InteractionBlock> createdBlocks = new List<InteractionBlock>();

    [Header("Tipos de Rela��es")]
    public int tipoInteracao = 0; //Com o que interage
    public int tipoConecao = 0;
    public bool blockInteraction = false;
    public bool moveCamera = false;
    


    [Header("Camera")]
    [SerializeField] public GameObject cameraObject;

    


    //[SerializeField] private bool hasSelectedObject = false;
    

    private void Start()
    {
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        colorManager = GetComponent<ColorManager>();
        highlightManager = GetComponent<HighlightManager>();
        move = GetComponent<Move>();
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
        move.SetRestraintPoint( point );
    }
    public void RestrainMaxDistance( Vector3 dis )
    {
        move.SetMaxDistance( dis );
    }

    public void RestrainMinDistance( Vector3 dis )
    {
        move.SetMinDistance( dis );
    }



    public void Restart()
    {
        selectedObject = null;
        selectedObjectForm = null;

        foreach(InteractionBlock interactionBlock in createdBlocks )
        {
            interactionBlock.DeletedBlock();
        }

        createdForms.Clear();
        createdBlocks.Clear();
        number = 0;
        numberCube = 0;
        numberSphere = 0;

        tipoInteracao = 0;
        blockInteraction = false;
        tipoConecao = 0;

    }

    public void DeleteGameObect(Form form )
    {
        InteractionBlock parent = form.gameObject.GetComponentInParent<InteractionBlock>();
        bool onlyFormInBlock = form.GetComponentInParent<InteractionBlock>().DeleteForm( form );
        if ( onlyFormInBlock )
            createdBlocks.Remove( parent );
        createdForms.Remove( form );

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