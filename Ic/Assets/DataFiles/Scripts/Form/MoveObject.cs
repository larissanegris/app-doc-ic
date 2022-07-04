using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] [Range(0, 15)] private float MovementSpeed = 10f;
    int restrainType;
    [SerializeField] private Vector3 restrainPoint;
    private Vector3 maxDistance; //Distancia que nao pode ficar mais longe
    private Vector3 minDistance; //Distancia que nao pode ficar mais perto
    [SerializeField] private float distance;

    private Form form;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        form = GetComponent<Form>();
    }

    private void Update()
    {
        restrainType = gameManager.connectionType;
        if ( restrainPoint != null )
            distance = Vector3.Distance( transform.position, restrainPoint );
        //if( tag == "Selected")
            //Debug.DrawLine( restrainPoint, transform.position, Color.cyan, 1 );
    }

    public void Move(Vector3 dir)
    {
        Vector3 nextPos = CalculatePosition( dir );
        if ( restrainType == 0 )
        {
            MoveToPosition( nextPos );
        }
        else if ( form.GetFormType() == FormType.Cube )
        {
            if ( restrainType == 1 )
            {
                //Verifica so se nao esta fora do limite
                if ( Mathf.Abs( ( restrainPoint.x - nextPos.x ) ) < maxDistance.x )
                {
                    if ( Mathf.Abs( ( restrainPoint.y - nextPos.y ) ) < maxDistance.y )
                    {
                        if ( Mathf.Abs( ( restrainPoint.z - nextPos.z ) ) < maxDistance.z )
                        {
                            MoveToPosition( nextPos );
                        }
                    }
                }
            }
            else if ( restrainType == 2 )
            {
                /*
                if ( Vector3.Distance( restrainPoint, nextPos ) <= maxDistance.magnitude )
                {

                    if ( (nextPos.x > restrainPoint.x + minDistance.x || nextPos.x < restrainPoint.x - minDistance.x)
                        || (nextPos.y > restrainPoint.y + minDistance.y || nextPos.y < restrainPoint.y - minDistance.y)
                        || (nextPos.z > restrainPoint.z + minDistance.z || nextPos.z < restrainPoint.z - minDistance.z) )
                    {
                        MoveToPosition( nextPos );
                    }
                }*/
                if ( Vector3.Distance( restrainPoint, nextPos ) <= maxDistance.magnitude )
                {
                    //Verifica se esta dentro dos dois limites
                    if ( ( nextPos.x > restrainPoint.x + minDistance.x || nextPos.x < restrainPoint.x - minDistance.x )
                        || ( nextPos.y > restrainPoint.y + minDistance.y || nextPos.y < restrainPoint.y - minDistance.y )
                        || ( nextPos.z > restrainPoint.z + minDistance.z || nextPos.z < restrainPoint.z - minDistance.z ) )
                    {
                        MoveToPosition( nextPos );
                    }
                }
            }
            else if ( restrainType == 3 )
            {
                if ( Vector3.Distance( restrainPoint, nextPos ) <= maxDistance.magnitude )
                {
                    if ( ( nextPos.x > restrainPoint.x + minDistance.x || nextPos.x < restrainPoint.x - minDistance.x )
                        || ( nextPos.y > restrainPoint.y + minDistance.y || nextPos.y < restrainPoint.y - minDistance.y )
                        || ( nextPos.z > restrainPoint.z + minDistance.z || nextPos.z < restrainPoint.z - minDistance.z ) )
                    {
                        MoveToPosition( nextPos );
                    }
                }
            }
        }
        else if ( form.GetFormType() == FormType.Sphere )
        {
            if ( restrainType == 1 )
            {
                //Verifica so se nao esta fora do limite
                if ( Mathf.Abs( ( restrainPoint.x - nextPos.x ) ) < (maxDistance.x) /maxDistance.normalized.x )
                {
                    if ( Mathf.Abs( ( restrainPoint.y - nextPos.y ) ) < maxDistance.y )
                    {
                        if ( Mathf.Abs( ( restrainPoint.z - nextPos.z ) ) < maxDistance.z )
                        {
                            MoveToPosition( nextPos );
                        }
                    }
                }
            }
        }
    }

    public void MoveToPosition( Vector3 newPosition )
    {
        transform.position = newPosition;
    }
    public Vector3 CalculatePosition( Vector3 dir )
    {
        return transform.position + dir * Time.deltaTime;
    }

    public void MoveUp()
    {
        Move(new Vector3(0, MovementSpeed, 0));
    }
    public void MoveDown()
    {
        Move(new Vector3(0, -MovementSpeed, 0));
    }
    public void MoveRight()
    {
        Move(new Vector3(MovementSpeed, 0, 0));
    }
    public void MoveLeft()
    {
        Move(new Vector3(-MovementSpeed, 0, 0));
    }
    public void MoveForward()
    {
        Move(new Vector3(0, 0, MovementSpeed));
    }
    public void MoveBackward()
    {
        Move(new Vector3(0, 0, -MovementSpeed));
    }

    public void SetRestraintType(int value)
    {
        restrainType = value;
    }

    public void SetRestraintPoint(Vector3 value)
    {
        restrainPoint = value;
    }

    public void SetMaxDistance(Vector3 value)
    {
        maxDistance = value;
    }

    public void SetMinDistance(Vector3 value)
    {
        minDistance = value;
    }

    private float FindMaxComponent( Vector3 vec)
    {
        if (vec.x > vec.y)
        {
            if( vec.x > vec.z)
                return vec.x;
            else
                return vec.z;
        }
        else
        {
            if (vec.y > vec.z)
                return vec.y;
            else
                return vec.z;
        }
    }

    
}