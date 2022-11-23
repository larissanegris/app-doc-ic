using System;
using UnityEngine;
using Lean.Touch;


public class TouchSelectionManager : SelectionManager
{
    public event Action<GameObject> selectionChange;
    public event Action<GameObject> selectionSphereChange;
    public Action<LeanFinger> FingerUp;
    public Action<LeanFinger> FingerDown;

    private void OnEnable()
    {
        LeanTouch.OnFingerDown += RaycastSelection;
        LeanTouch.OnFingerUp += DeselectControlSphere;
        LeanTouch.OnFingerUp += LiftFinger;
        LeanTouch.OnFingerDown += FingerPress;
        FindObjectOfType<InstantiationManager>().Instantiation += ChangeSelectedObject;
    }

    private void RaycastSelection(LeanFinger finger)
    {
        Debug.Log("Touch Selection Finger Down");
        if (_selection != null)
        {
            _selection = null;
        }

        Ray ray = finger.GetRay();
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layerMask))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {

                if (selection.gameObject != gameManager.GetSelectedObject())
                {
                    if (selectionChange != null)
                    {
                        selectionChange(selection.gameObject);
                    }
                    //gameManager.ChangeSelectedObject( selection.gameObject );
                }

                _selection = selection;

            }
            if (selection.CompareTag("ControlSphere"))
            {
                Debug.Log("touch selection - ControlSphere" + hit.transform.name);
                if (selection.gameObject != gameManager.GetSelectedObject())
                {
                    if (selectionChange != null)
                    {
                        selectionSphereChange(selection.gameObject);
                    }
                    //gameManager.ChangeSelectedObject( selection.gameObject );
                }

                _selection = selection;

            }
        }
    }

    void ChangeSelectedObject(GameObject go)
    {
        selectionChange(go);
    }
    void DeselectControlSphere(LeanFinger finger)
    {
        selectionSphereChange(null);
    }

    void FingerPress(LeanFinger finger)
    {
        FingerDown(finger);
    }

    void LiftFinger(LeanFinger finger)
    {
        FingerUp(finger);
    }

}
