using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    private float RotationtSpeed = 100f;
    private bool isRotating = false;



    public void Rotate( Vector3 finalRotation )
    {
        Vector3 initialRotation = transform.rotation.eulerAngles;
        if ( !isRotating )
        {
            while ( initialRotation != finalRotation )
            {
                transform.eulerAngles = ( finalRotation - initialRotation ) * Time.deltaTime;
            }
        }
    }

    public void RotateUp()
    {
        Rotate( new Vector3( RotationtSpeed, 0, 0 ) );
    }
    public void RotateDown()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3( RotationtSpeed, 0, 0 ) * Time.deltaTime;
    }
    public void RotateRight()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3( 0, RotationtSpeed, 0 ) * Time.deltaTime;
    }
    public void RotateLeft()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3( 0, RotationtSpeed, 0 ) * Time.deltaTime;
    }
    public void RotateForward()
    {
        transform.eulerAngles = transform.eulerAngles + new Vector3( 0, 0, RotationtSpeed ) * Time.deltaTime;
    }
    public void RotateBackward()
    {
        transform.eulerAngles = transform.eulerAngles - new Vector3( 0, 0, RotationtSpeed ) * Time.deltaTime;
    }
}
