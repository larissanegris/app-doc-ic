using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float RotationtSpeed = 100f;
    public void RotateUp()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(RotationtSpeed, 0, 0) * Time.deltaTime;
    }
    public void RotateDown()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(RotationtSpeed, 0, 0) * Time.deltaTime;
    }
    public void RotateRight()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, RotationtSpeed, 0) * Time.deltaTime;
    }
    public void RotateLeft()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, RotationtSpeed, 0) * Time.deltaTime;
    }
    public void RotateForward()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, RotationtSpeed) * Time.deltaTime;
    }
    public void RotateBackward()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3(0, 0, RotationtSpeed) * Time.deltaTime;
    }
}
