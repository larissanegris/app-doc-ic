using System.Collections;
using Lean.Touch;
using System.Collections.Generic;
using UnityEngine;

public class InteractMultipleObjects : MonoBehaviour
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
        Debug.Log("ChangeRequiredSelectable");
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
            if(gm.GetComponent<Form>().GetFormType() == FormType.Cube)
                gm.GetComponent<LeanTwistRotateAxis>().Use.RequiredSelectable = selectable;
        }
    }

    static void ChangeRequiredSelectableToTarget(List<GameObject> selectedObjects, GameObject target)
    {
        LeanSelectableByFinger selectable = target.GetComponent<LeanSelectableByFinger>();
        target.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;
        if (target.GetComponent<Form>().GetFormType() == FormType.Cube)
            target.GetComponent<LeanTwistRotateAxis>().Use.RequiredSelectable = selectable;

        foreach (GameObject gm in selectedObjects)
        {
            gm.GetComponent<LeanDragTranslate>().Use.RequiredSelectable = selectable;
            if (gm.GetComponent<Form>().GetFormType() == FormType.Cube)
                gm.GetComponent<LeanTwistRotateAxis>().Use.RequiredSelectable = selectable;
        }
    }


}
