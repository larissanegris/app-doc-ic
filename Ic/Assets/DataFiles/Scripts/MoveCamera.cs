using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] [Range(0, 15)] private float MovementSpeed = 10f;


    public void Move( Vector3 dir )
    {
        //transform.position = CalculatePosition( dir );
        transform.Translate( CalculatePosition( dir ) );
    }
    public Vector3 CalculatePosition( Vector3 dir )
    {
        return dir * Time.deltaTime;
    }

    public void MoveUp()
    {

        //transform.Translate( CalculatePosition( new Vector3( 0, 10, 0 ) ) );
        Debug.Log( "BB" + Time.deltaTime);

        Move( new Vector3( 0, 10, 0 ) );
    }
    public void MoveDown()
    {
        Move( new Vector3( 0, -MovementSpeed, 0 ) );
    }
    public void MoveRight()
    {
        Move( new Vector3( MovementSpeed, 0, 0 ) );
    }
    public void MoveLeft()
    {
        Move( new Vector3( -MovementSpeed, 0, 0 ) );
    }
    public void MoveForward()
    {
        Move( new Vector3( 0, 0, MovementSpeed ) );
    }
    public void MoveBackward()
    {
        Move( new Vector3( 0, 0, -MovementSpeed ) );
    }
}
