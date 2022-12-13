using System.Collections;
using Lean.Touch;
using System.Collections.Generic;
using UnityEngine;

public class MoveMultipleObjects : MonoBehaviour
{
    private TouchSelectionManager touchSelectionManager;
    // Start is called before the first frame update
    void Start()
    {
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
        touchSelectionManager.selectionChangeMultiple += ChangeRequiredSelectable;
    }

    void ChangeRequiredSelectable(bool selectMultipleObjects, List<GameObject> selectedObjects, GameObject target)
    {
        if (selectMultipleObjects)
        {
            LeanSelectableByFinger selectable = target.GetComponent<LeanSelectableByFinger>();
            target.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;

            foreach (GameObject gm in selectedObjects)
            {
                if (gm != target)
                {
                    gm.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;

                }
            }
        }
        else
        {
            foreach (GameObject gm in selectedObjects)
            {
                LeanSelectableByFinger selectable = gm.GetComponent<LeanSelectableByFinger>();
                gm.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;
            }
        }
        
    }


}
