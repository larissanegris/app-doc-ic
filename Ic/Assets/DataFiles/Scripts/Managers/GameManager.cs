using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public InstantiationManager instantiationManager;
    [HideInInspector] public ColorManager colorManager;
    [HideInInspector] public CollisionManager collisionManager;

    [HideInInspector] public Move move;
    [HideInInspector] public Rotate rotate;

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
    public bool moveCamera = false;
    

    [HideInInspector][SerializeField] public GameObject cameraObject;


    //[SerializeField] private bool hasSelectedObject = false;
    

    private void Awake()
    {
        colorManager = GetComponent<ColorManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        collisionManager = GetComponent<CollisionManager>();
        move = GetComponent<Move>();

        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        instantiationManager.Instantiation += AddNewObject;
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

            return;
        }

        //tem outras formas criadas

        //muda tag da antiga
        selectedObject.tag = "Selectable";

        //deseleciona forma antiga
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.SetToUnselected();

        //seleciona forma nova
        selectedObject = newSelectedGameObject;
        selectedObjectForm = selectedObject.GetComponent<Form>();
        selectedObjectForm.saveColor();
        selectedObjectForm.SetToSelected();

        //muda tag
        selectedObject.tag = "Selected";
        //Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
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
