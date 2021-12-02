using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    private float resizeSpeed = 2f;

    public void ScaleUp()
    {
        transform.localScale = transform.localScale + new Vector3(0, resizeSpeed, 0) * Time.deltaTime;
    }
    public void ScaleDown()
    {
        transform.localScale = transform.localScale - new Vector3(0, resizeSpeed, 0) * Time.deltaTime;
    }
    public void ScaleRight()
    {
        transform.localScale = transform.localScale + new Vector3(resizeSpeed, 0, 0) * Time.deltaTime;
    }
    public void ScaleLeft()
    {
        transform.localScale = transform.localScale - new Vector3(resizeSpeed, 0, 0) * Time.deltaTime;
    }
    public void ScaleForward()
    {
        transform.localScale = transform.localScale + new Vector3(0, 0, resizeSpeed) * Time.deltaTime;
    }
    public void ScaleBackward()
    {
        transform.localScale = transform.localScale - new Vector3(0, 0, resizeSpeed) * Time.deltaTime;
    }
}
