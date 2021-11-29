using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private float MovementSpeed = 10f;

    public void MoveUp()
    {
        transform.position = transform.position + new Vector3(0, MovementSpeed, 0) * Time.deltaTime;
    }
    public void MoveDown()
    {
        transform.position = transform.position - new Vector3(0, MovementSpeed, 0) * Time.deltaTime;
    }
    public void MoveRight()
    {
        transform.position = transform.position + new Vector3(MovementSpeed, 0, 0) * Time.deltaTime;
    }
    public void MoveLeft()
    {
        transform.position = transform.position - new Vector3(MovementSpeed, 0, 0) * Time.deltaTime;
    }
    public void MoveForward()
    {
        transform.position = transform.position + new Vector3(0, 0, MovementSpeed) * Time.deltaTime;
    }
    public void MoveBackward()
    {
        transform.position = transform.position - new Vector3(0, 0, MovementSpeed) * Time.deltaTime;
    }
}