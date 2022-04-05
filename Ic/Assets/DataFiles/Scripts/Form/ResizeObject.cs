using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    private float resizeSpeed = 2f;
    private Form form;

    private void Awake()
    {
        form = GetComponent<Form>();
    }
    public void ScaleUp()
    {
        if(form.GetFormType() == FormType.Cube)
            transform.localScale = transform.localScale + new Vector3(0, resizeSpeed, 0) * Time.deltaTime;
        else if ( form.GetFormType() == FormType.Sphere )
            transform.localScale = transform.localScale + Vector3.one * resizeSpeed * Time.deltaTime;
    }
    public void ScaleDown()
    {
        if ( form.GetFormType() == FormType.Cube )
            transform.localScale = transform.localScale - new Vector3(0, resizeSpeed, 0) * Time.deltaTime;
        else if ( form.GetFormType() == FormType.Sphere )
            transform.localScale = transform.localScale + Vector3.one * -resizeSpeed * Time.deltaTime;
    }
    public void ScaleRight()
    {
        if ( form.GetFormType() == FormType.Cube )
            transform.localScale = transform.localScale + new Vector3(resizeSpeed, 0, 0) * Time.deltaTime;
    }
    public void ScaleLeft()
    {
        if ( form.GetFormType() == FormType.Cube )
            transform.localScale = transform.localScale - new Vector3(resizeSpeed, 0, 0) * Time.deltaTime;
    }
    public void ScaleForward()
    {
        if ( form.GetFormType() == FormType.Cube )
            transform.localScale = transform.localScale + new Vector3(0, 0, resizeSpeed) * Time.deltaTime;
    }
    public void ScaleBackward()
    {
        if ( form.GetFormType() == FormType.Cube )
            transform.localScale = transform.localScale - new Vector3(0, 0, resizeSpeed) * Time.deltaTime;
    }
}
