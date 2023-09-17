using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class SphereControl : MonoBehaviour
{
    public Axis axis;
    public int dir;
    private string name;
    public GameObject selectedObject;
    private TouchSelectionManager touchSelectionManager;
    public bool updatePosition;

    private void Start()
    {
        //LeanTouch.OnFingerUp += UpdatePosition;
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
        touchSelectionManager.selectionChangeMultiple += SelectionChange;
        touchSelectionManager.selectionSphereChange += UpdateSphereStatus;
        //selectionManager.FingerUp += UpdatePosition;
        updatePosition = false;
        selectedObject = null;
    }

    private void Update()
    {
        if (updatePosition)
            UpdatePosition();
    }


    public void StartUp()
    {
        name = gameObject.name;
        if (name[0] == 'x')
        {
            axis = Axis.x;
        }
        else if (name[0] == 'y')
        {
            axis = Axis.y;
        }
        else if (name[0] == 'z')
        {
            axis = Axis.z;
        }

        if (name[1] == '1')
        {
            dir = 1;
        }
        else if (name[1] == '2')
        {
            dir = -1;
        }
    }

    void UpdatePosition()
    {
        //Debug.Log("Sphere control - Update position");
        if (selectedObject != null)
        {
            Vector3 pos = selectedObject.transform.position;
            Quaternion rot = selectedObject.transform.rotation;
            Vector3 size = selectedObject.transform.lossyScale / 2;
            if (axis == Axis.x)
            {
                transform.position = (pos - dir * (rot * (new Vector3(size.x, 0, 0))));
            }
            if (axis == Axis.y)
            {
                transform.position = (pos - dir * (rot * new Vector3(0, size.y, 0)));
            }
            if (axis == Axis.z)
            {
                transform.position = (pos - dir * (rot * new Vector3(0, 0, size.z)));
            }
        }

    }

    private void SelectionChange(bool selectMultipleObjects, List<GameObject> selectedObj, GameObject target)
    {
        if(!selectMultipleObjects)
        {
            if (target.GetComponent<Form>().GetFormType() == FormType.Sphere)
                gameObject.SetActive(false);
            else
            {
                selectedObject = target;
                UpdatePosition();
            }
            
        }
    }

    void UpdateSphereStatus(GameObject go)
    {
        if (go == this.gameObject)
            updatePosition = false;
        else
            updatePosition = true;
    }

}
