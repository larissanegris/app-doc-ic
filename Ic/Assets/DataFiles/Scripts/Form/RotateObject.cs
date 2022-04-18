using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float rotationAngle = 90f;
    private bool isRotating = false;
    float smooth = 50.0f;



    public void Rotate( Vector3 target )
    {
        Debug.Log( "Rodando de " + transform.eulerAngles + " para " + ( transform.eulerAngles + target ) );
        transform.eulerAngles = transform.eulerAngles + target;
    }

    public void RotateUp()
    {
        Rotate( new Vector3( rotationAngle, 0, 0 ) );
    }
    public void RotateDown()
    {
        Rotate( new Vector3( -rotationAngle, 0, 0 ) );
    }
    public void RotateRight()
    {
        Rotate( new Vector3( 0, rotationAngle, 0 ) );
    }
    public void RotateLeft()
    {
        Rotate( new Vector3( 0, -rotationAngle, 0 ) );
    }
    public void RotateForward()
    {
        Rotate( new Vector3( 0, 0, rotationAngle ) );
    }
    public void RotateBackward()
    {
        Rotate( new Vector3( 0, 0, -rotationAngle ) );
    }
}
