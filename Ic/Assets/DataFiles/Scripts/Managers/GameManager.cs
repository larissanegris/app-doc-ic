using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Managers")]

    public InstantiationManager instantiationManager;
    public ColorManager colorManager;
    public HighlightManager highlightManager;
    public CollisionManager collisionManager;

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
    [SerializeField] public bool displayVolume = false;

    [Header("Tipos de Relações")]
    public int tipoInteracao = 0; //Com o que interage
    public int tipoConecao = 0;
    public bool blockInteraction = false;
    public bool moveCamera = false;
    
    [Header("Camera")]
    [SerializeField] public GameObject cameraObject;


    //[SerializeField] private bool hasSelectedObject = false;
    

    private void Awake()
    {
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        colorManager = GetComponent<ColorManager>();
        highlightManager = GetComponent<HighlightManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        instantiationManager.Instantiation += AddNewObject;
        collisionManager = GetComponent<CollisionManager>();
        move = GetComponent<Move>();
    }

    public void ChangeSelectedObject(GameObject newSelectedGameObject)
    {
        Debug.Log( "Trocando Selecionado" );
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
        //Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
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

    public void AddNewObject(GameObject gm )
    {
        Debug.Log("Adicionando");
        number++;
        Form form = gm.GetComponent<Form>();
        createdForms.Add( form );
        if(form.GetFormType() == FormType.Cube)
            numberCube++;
        else
            numberSphere++;
        ChangeSelectedObject(gm);
        colorManager.ChangeColor( -1, gm );
    }


    public void Restart()
    {
        selectedObject = null;
        selectedObjectForm = null;

        createdForms.Clear();
        number = 0;
        numberCube = 0;
        numberSphere = 0;

        tipoInteracao = 0;
        blockInteraction = false;
        tipoConecao = 0;

    }

    public void DeleteGameObect(Form form )
    {
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
