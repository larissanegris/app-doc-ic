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

    public event Action<bool, List<GameObject>, GameObject> selectionChangeMultiple;
    public event Action<GameObject> selectionSphereChange;

    public Action<LeanFinger> FingerUp;
    public Action<LeanFinger> FingerDown;


    private void OnEnable()
    {
        LeanTouch.OnFingerDown += TouchToObject;
        LeanTouch.OnFingerUp += DeselectControlSphere;
        LeanTouch.OnFingerUp += LiftFinger;
        LeanTouch.OnFingerDown += FingerPress;
        FindObjectOfType<InstantiationManager>().Instantiation += UpdateSelection;
        FindObjectOfType<DoubleTapHandler>().DoubleTap += DoubleTapToDeselect;
    }

    private void TouchToObject(LeanFinger finger)
    {
        int typeOfObject = RaycastSelection(finger, out GameObject target);
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
        int typeOfObject = RaycastSelection(finger, out GameObject target);
        if (typeOfObject == 1)
        {
            UpdateSelection(target);
            if (selectMultipleObjects)
            {
                RemoveSelectedObject(target);
                return;
            }
        }
    }

    private int RaycastSelection(LeanFinger finger, out GameObject target)
    {
        Debug.Log("Touch Selection Finger Down");

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
                Debug.Log("touch selection - ControlSphere" + hit.transform.name);
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
            return;
        }

        //Debug.Log(target.name + " - " + selectedObjects.Contains(target));
        if (!selectedObjects.Contains(target))
        {
            AddSelectedObject(target);
            return;
        }
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, target);
    }

    public void ChangeSelectedObject(GameObject newSelectedObject)
    {
        if (selectedObjects.Count == 0)
        {
            selectedObjects.Add(newSelectedObject);
            selectedObjects[0].tag = "Selected";
            return;
        }

        selectedObjects[0].tag = "Selectable";
        selectedObjects[0] = newSelectedObject;
        selectedObjects[0].tag = "Selected";
        //Debug.Log("<color=orange>Selecionado: " + selectedObject.name + "</color>");
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, newSelectedObject);
    }

    void AddSelectedObject(GameObject newSelectedObject)
    {
        selectedObjects.Add(newSelectedObject);
        newSelectedObject.tag = "Selected";
        newSelectedObject.GetComponent<Form>().SetToSelected();
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, newSelectedObject);
    }

    void RemoveSelectedObject(GameObject unselectedObject)
    {
        if(selectedObjects.Count < 2)
        {
            Debug.Log("Nao é possivel, so ha um objeto");
            return;
        }
        //deseleciona forma
        selectedObjects.Remove(unselectedObject);
        unselectedObject.tag = "Selectable";
        unselectedObject.GetComponent<Form>().SetToUnselected();
        if (selectedObjects.Count == 1)
            selectMultipleObjects = false;
        selectionChangeMultiple(selectMultipleObjects, selectedObjects, selectedObjects[0]);
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
