using System;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;


public class TouchSelectionManager : MonoBehaviour
{
    protected string selectableTag = "Selectable";
    protected string selectedTag = "Selected";
    protected int formLayerMask = 3 << 6;
    protected int controlSphereLayerMask = 1 << 7;

    protected GameManager gameManager;
    protected Transform _selection;


    [Header("Formas")]
    public bool selectMultipleObjects;
    [SerializeField] public List<GameObject> selectedObjects = new List<GameObject>();

    public event Action<bool, List<GameObject>> selectionChange;
    public event Action<bool, List<GameObject>, GameObject> selectionChangeMultiple;
    public event Action<GameObject> selectionSphereChange;

    public Action<LeanFinger> FingerUp;
    public Action<LeanFinger> FingerDown;


    private void OnEnable()
    {
        LeanTouch.OnFingerDown += RaycastSelection;
        LeanTouch.OnFingerUp += DeselectControlSphere;
        LeanTouch.OnFingerUp += LiftFinger;
        LeanTouch.OnFingerDown += FingerPress;
        FindObjectOfType<InstantiationManager>().Instantiation += UpdateSelection;
    }

    private void RaycastSelection(LeanFinger finger)
    {
        Debug.Log("Touch Selection Finger Down");
        _selection = null;

        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, formLayerMask))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag) || selection.CompareTag(selectedTag))
            {
                UpdateSelection(selection.gameObject);
            }
            _selection = selection;

        }
        if (Physics.Raycast(ray, out hit, controlSphereLayerMask))
        {
            var selection = hit.transform;
            if (selection.CompareTag("ControlSphere"))
            {
                Debug.Log("touch selection - ControlSphere" + hit.transform.name);
                selectionSphereChange(selection.gameObject);
            }
        }


    }

    void UpdateSelection(GameObject target)
    {
        if (!selectMultipleObjects)
        {
            ChangeSelectedObject(target);
        }
        else
        {
            Debug.Log(target.name + " - " + selectedObjects.Contains(target));
            if (!selectedObjects.Contains(target))
            {
                AddSelectedObject(target);
            }
            else
            {
                //RemoveSelectedObject(target);
            }
            selectionChangeMultiple(selectMultipleObjects, selectedObjects, target);
        }
        selectionChange(selectMultipleObjects, selectedObjects);
    }

    public void ChangeSelectedObject(GameObject newSelectedObject)
    {
        //se for o unico objeto, nao precisa modificar o antigo selecionado
        if (selectedObjects.Count == 0)
        {
            //seleciona novo objeto
            selectedObjects.Add(newSelectedObject);

            //muda tag
            selectedObjects[0].tag = "Selected";

            return;
        }

        //tem outras formas criadas

        //muda tag da antiga
        selectedObjects[0].tag = "Selectable";

        //deseleciona forma antiga

        //seleciona forma nova
        selectedObjects[0] = newSelectedObject;

        //muda tag
        selectedObjects[0].tag = "Selected";
        //Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
    }

    void AddSelectedObject(GameObject newSelectedObject)
    {
        selectedObjects.Add(newSelectedObject);
        newSelectedObject.tag = "Selected";
        newSelectedObject.GetComponent<Form>().SetToSelected();
    }

    void RemoveSelectedObject(GameObject unselectedObject)
    {
        //deseleciona forma
        selectedObjects.Remove(unselectedObject);
        unselectedObject.tag = "Selectable";
        unselectedObject.GetComponent<Form>().SetToUnselected();
    }



    public void ChangeFormMultipleToSingle()
    {
        for (int i = selectedObjects.Count - 1; i > 0; i--)
        {
            RemoveSelectedObject(selectedObjects[i]);
        }
    }

    public void ChangeSelectMultiple()
    {
        if (selectMultipleObjects)
        {
            ChangeFormMultipleToSingle();
        }
        selectMultipleObjects = !selectMultipleObjects;
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, selectedObjects[0]);
    }


    void DeselectControlSphere(LeanFinger finger)
    {
        if (finger != null)
            selectionSphereChange(null);
    }

    void FingerPress(LeanFinger finger)
    {
        if (finger != null) ;
        FingerDown(finger);
    }

    void LiftFinger(LeanFinger finger)
    {
        if (finger != null) ;
        //FingerUp(finger);
    }

}
