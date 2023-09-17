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
    [SerializeField]
    GameObject target;


    [Header("Formas")]
    public bool selectMultipleObjects;
    [SerializeField] public List<GameObject> selectedObjects;

    public event Action<bool, List<GameObject>, GameObject> selectionChangeMultiple;
    public event Action<GameObject> selectionSphereChange;


    private void Start()
    {
        gameManager = GetComponent<GameManager>();
        LeanTouch.OnFingerDown += TouchToObject;
        LeanTouch.OnFingerUp += DeselectControlSphere;
        LeanTouch.OnFingerUp += LiftFinger;
        FindObjectOfType<InstantiationManager>().Instantiation += UpdateSelection;
        FindObjectOfType<DoubleTapHandler>().DoubleTap += DoubleTapToDeselect;
        selectedObjects = new List<GameObject>();
        target = null;
        selectMultipleObjects = false;
    }

    private void TouchToObject(LeanFinger finger)
    {
        target = null;
        int typeOfObject = RaycastSelection(finger, out target);
        if (typeOfObject == -1 || target == null)
            return;
        if (typeOfObject == 1)
        {
            UpdateSelection(target);
        }
        else if(typeOfObject == 2)
        {
            selectionSphereChange(target);
        }
    }

    private void DoubleTapToDeselect(LeanFinger finger)
    {
        int typeOfObject = RaycastSelection(finger, out target);
        if (typeOfObject == 1)
        {
            UpdateSelection(target);
            if (selectMultipleObjects)
            {
                RemoveSelectedObject(target);
                if (selectedObjects.Count == 1)
                    selectMultipleObjects = false;
                selectionChangeMultiple(selectMultipleObjects, selectedObjects, selectedObjects[0]);
                return;
            }
        }
    }

    private int RaycastSelection(LeanFinger finger, out GameObject target)
    {
        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, formLayerMask))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag) || selection.CompareTag(selectedTag))
            {
                target = selection.gameObject;
                //UpdateSelection(selection.gameObject);
                return 1;
            }

        }
        if (Physics.Raycast(ray, out hit, controlSphereLayerMask))
        {
            var selection = hit.transform;
            if (selection.CompareTag("ControlSphere"))
            {
                target = selection.gameObject;
                return 2;
            }
        }
        target = null;
        return -1;
    }

    void UpdateSelection(GameObject target)
    {   
        if (!selectMultipleObjects)
        {
            ChangeSelectedObject(target);
        }

        if (!selectedObjects.Contains(target))
        {
            AddSelectedObject(target);
        }
        //selectionChangeMultiple(selectMultipleObjects, selectedObjects, target);
    }

    public void ChangeSelectedObject(GameObject newSelectedObject)
    {
        target = newSelectedObject;
        if (selectedObjects.Count == 0)
        {
            selectedObjects.Add(target);
            selectedObjects[0].tag = "Selected";
            selectionChangeMultiple(selectMultipleObjects, selectedObjects, newSelectedObject);
            return;
        }
        //Debug.Log("ChangeSelectedObject from " + selectedObjects[0].name);
        Debug.Log(" to " + newSelectedObject.name);

        if (selectedObjects[0] == null)
            Debug.LogError("Selected Objects size" + selectedObjects[0]);
        selectedObjects[0].tag = "Selectable";
        selectedObjects[0] = newSelectedObject;
        selectedObjects[0].tag = "Selected";
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, newSelectedObject);

    }

    public void ChangeSelectedObjectToNone()
    {
        selectedObjects.Clear();
        //Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, null);
    }

    void AddSelectedObject(GameObject newSelectedObject)
    {
        selectedObjects.Add(newSelectedObject);
        newSelectedObject.tag = "Selected";
        newSelectedObject.GetComponent<Form>().SetToSelected();
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, newSelectedObject);
    }

    bool RemoveSelectedObject(GameObject unselectedObject)
    {
        if(gameManager.createdForms.Count < 2)
        {
            Debug.LogError("Nao é possivel, so ha um objeto");
            Debug.Log(selectedObjects.Count);
            return false;
        }
        //deseleciona forma
        selectedObjects.Remove(unselectedObject);
        unselectedObject.tag = "Selectable";
        unselectedObject.GetComponent<Form>().SetToUnselected();
        return true;
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

    void LiftFinger(LeanFinger finger)
    {
        if (finger != null)
            return;
        //FingerUp(finger);
    }

    public bool isPossibleToDelete()
    {
        return (!selectMultipleObjects && gameManager.number > 1);
    }

    public bool removeSelection(GameObject gm)
    {
        if (!RemoveSelectedObject(gm))
            return false;

        UpdateSelection(gameManager.createdForms[0].gameObject);
        return true;
    }
}
