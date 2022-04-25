using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject selectedObject;
    private Form form;

    private float rotationAngle = 90f;
    private bool isRotating = false;
    float smooth = 50.0f;

    private void Awake()
    {
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }

    private void ChangeSelectedObject( GameObject gm )
    {
        selectedObject = gm;
        form = selectedObject.GetComponent<Form>();
    }

    public void Rotation( Vector3 target )
    {
        //Debug.Log( "Rodando de " + transform.eulerAngles + " para " + ( transform.eulerAngles + target ) );
        selectedObject.transform.eulerAngles = selectedObject.transform.eulerAngles + target;
    }

    public void RotateUp()
    {
        Rotation( new Vector3( rotationAngle, 0, 0 ) );
    }
    public void RotateDown()
    {
        Rotation( new Vector3( -rotationAngle, 0, 0 ) );
    }
    public void RotateRight()
    {
        Rotation( new Vector3( 0, rotationAngle, 0 ) );
    }
    public void RotateLeft()
    {
        Rotation( new Vector3( 0, -rotationAngle, 0 ) );
    }
    public void RotateForward()
    {
        Rotation( new Vector3( 0, 0, rotationAngle ) );
    }
    public void RotateBackward()
    {
        Rotation( new Vector3( 0, 0, -rotationAngle ) );
    }
}
