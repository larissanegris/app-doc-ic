using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject selectedObject;

    private float resizeSpeed = 2f;
    private Form form;

    private void Awake()
    {
        //FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        form = GetComponent<Form>();
    }

    private void ChangeSelectedObject(GameObject gm)
    {
        selectedObject = gm;
        form = selectedObject.GetComponent<Form>();
    }

    private void Scale(Vector3 dir)
    {
        selectedObject.transform.localScale = selectedObject.transform.localScale + dir * Time.deltaTime;
    }

    public void ScaleUp()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(new Vector3(0, resizeSpeed, 0));
        else if (form.GetFormType() == FormType.Sphere)
            Scale(Vector3.one * resizeSpeed);
    }
    public void ScaleDown()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(new Vector3(0, -resizeSpeed, 0));
        else if (form.GetFormType() == FormType.Sphere)
            Scale(Vector3.one * -resizeSpeed);
    }
    public void ScaleRight()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(new Vector3(resizeSpeed, 0, 0));
    }
    public void ScaleLeft()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(-new Vector3(resizeSpeed, 0, 0));
    }
    public void ScaleForward()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(new Vector3(0, 0, resizeSpeed));
    }
    public void ScaleBackward()
    {
        if (form.GetFormType() == FormType.Cube)
            Scale(-new Vector3(0, 0, resizeSpeed));
    }
}