using System;
using UnityEngine;
using Lean.Touch;


public class TouchSelectionManager : SelectionManager
{
    public event Action<GameObject> selectionChange;

    private void OnEnable()
    {
        Lean.Touch.LeanTouch.OnFingerDown += RaycastSelection;
    }

    private void RaycastSelection(LeanFinger finger)
    {
        Debug.Log("Finger Down");
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
        }
    }

    void HandleFingerDown(LeanFinger l )
    {
        Debug.Log("Finger Down");
    }

    public void ChangeSelectedObject(GameObject gm)
    {
        selectionChange?.Invoke(gm);
    }
}
