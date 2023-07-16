using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IDataPeristence
{
    [HideInInspector] public InstantiationManager instantiationManager;
    [HideInInspector] public ColorManager colorManager;
    [HideInInspector] public CollisionManager collisionManager;
    [HideInInspector] public TouchSelectionManager touchSelectionManager;

    [HideInInspector] public Move move;
    [HideInInspector] public Rotate rotate;
    [HideInInspector] public ScaleObject scaleObject;

    [Header("Formas")]

    //public bool selectMultipleObjects;

    public int number;
    public int numberCube = 0;
    public int numberSphere = 0;
    public List<Form> createdForms = new List<Form>();
    [SerializeField] public bool displayVolume = false;

    [Header("Tipos de Relações")]
    public int interactionType = 0; //Com o que interage
    public int connectionType = 0;
    public bool moveCamera = false;

    [HideInInspector] [SerializeField] public GameObject cameraObject;

    public event Action<bool> VolumeToggle;
    public event Action<GameObject> selectionChange;

    private void Awake()
    {
        colorManager = GetComponent<ColorManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        collisionManager = GetComponent<CollisionManager>();
        touchSelectionManager = GetComponent<TouchSelectionManager>();

        move = GetComponent<Move>();
        rotate = GetComponent<Rotate>();
        scaleObject = GetComponent<ScaleObject>();

        //FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        instantiationManager.Instantiation += AddNewObject;
        //touchSelectionManager.selectionChangeMultiple += ChangeSelectMultiple;
        cameraObject = GameObject.Find("Camera");
    }

    public void LoadData(GameData data)
    {
        Debug.Log(data);
        for (int i = 0; i < data.createdForms.Count; i++)
            instantiationManager.Load(data.createdForms[i], false);

    }
    
    public void SaveData(ref GameData data)
    {
        data.numberCreatedObjects = this.number;
        data.createdForms = createdForms;
        for(int i = 0; i < number; i++)
            createdForms[i].SaveForm();
            
    }

    public void ChangeMoveCamera()
    {
        moveCamera = !moveCamera;
    }

    public int GetconnectionType()
    {
        return connectionType;
    }
    public void ChangeconnectionType()
    {
        if (connectionType == 3)
        {
            connectionType = 0;
        }
        else
        {
            connectionType++;
        }
    }

    public void ChangeinteractionType(int novaInteracao)
    {
        interactionType = novaInteracao;
        if (novaInteracao == 3)
        {
            moveCamera = true;
        }
        else
        {
            moveCamera = false;
        }
    }

    public void RestrainPoint(Vector3 point)
    {
        move.SetRestraintPoint(point);
    }
    public void RestrainMaxDistance(Vector3 dis)
    {
        move.SetMaxDistance(dis);
    }

    public void RestrainMinDistance(Vector3 dis)
    {
        move.SetMinDistance(dis);
    }

    public void AddNewObject(GameObject gm)
    {
        number++;
        Form form = gm.GetComponent<Form>();
        createdForms.Add(form);
        if (form.GetFormType() == FormType.Cube)
            numberCube++;
        else
            numberSphere++;
        //UpdateSelection(gm);
    }


    public void Restart()
    {
        createdForms.Clear();
        number = 0;
        numberCube = 0;
        numberSphere = 0;

        interactionType = 0;
        connectionType = 0;

    }

    public bool DeleteGameObect(Form form)
    {
        if (!touchSelectionManager.isPossibleToDelete())
        {
            Debug.LogError("Nao foi possivel deletar");
            return false;
        }
        
        if (!touchSelectionManager.removeSelection(form.gameObject))
            return false;

        //form.DeleteSelf();
        form.gameObject.SetActive(false);

        return true;
        
    }

    public void DeleteSelectedGameObect()
    {
        GameObject gm = touchSelectionManager.selectedObjects[0];
        Form form = gm.GetComponent<Form>();

        DeleteGameObect(form);
    }

    public void VolumeToggleEvent()
    {
        displayVolume = !displayVolume;
        VolumeToggle(displayVolume);
    }

    /*
    private void ChangeSelectMultiple(bool select, List<GameObject> selectedObjects, GameObject target)
    {
        selectMultipleObjects = select;
    }
    */
}
