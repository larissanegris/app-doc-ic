using System.Collections;
using Lean.Touch;
using System.Collections.Generic;
using UnityEngine;

public class MoveMultipleObjects : MonoBehaviour
{
    private GameManager gameManager;
    private TouchSelectionManager touchSelectionManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
        touchSelectionManager.selectionChangeMultiple += ChangeRequiredSelectable;
    }

    void ChangeRequiredSelectable(bool selectMultipleObjects, List<GameObject> selectedObjects, GameObject target)
    {
        if (selectMultipleObjects)
            ChangeRequiredSelectableToTarget(selectedObjects, target);
        else
            ChangeRequiredSeçectableToSelf();
    }

    private void ChangeRequiredSeçectableToSelf()
    {
        foreach (Form f in gameManager.createdForms)
        {
            GameObject gm = f.gameObject;
            LeanSelectableByFinger selectable = gm.GetComponent<LeanSelectableByFinger>();
            gm.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;
        }
    }

    static void ChangeRequiredSelectableToTarget(List<GameObject> selectedObjects, GameObject target)
    {
        LeanSelectableByFinger selectable = target.GetComponent<LeanSelectableByFinger>();
        target.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;

        foreach (GameObject gm in selectedObjects)
        {
            gm.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;
        }
    }


}
