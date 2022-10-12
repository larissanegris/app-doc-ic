using UnityEngine;
using UnityEditor;

public class Move : MonoBehaviour
{

    private GameManager gameManager;
    public GameObject selectedObject;
    private Form form;
    [Space(20)]
    [SerializeField] [Range(0, 15)] private float MovementSpeed = 10f;
    
    
    private int restrainType;
    private Vector3 restrainPoint;
    private Vector3 maxDistance; //Distancia que nao pode ficar mais longe
    private Vector3 scale;
    private Vector3 center;
    [HideInInspector] public Vector3 closestPoint;
    private Vector3 minDistance; //Distancia que nao pode ficar mais perto
    private float distance;

    //public event Func<GameObject> Move;

    private void Awake()
    {
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
        FindObjectOfType<TouchSelectionManager>().selectionChange += ChangeSelectedObject;
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }

    private void Update()
    {
        selectedObject = gameManager.selectedObject;
        restrainType = gameManager.connectionType;
        //Debug.DrawLine(center, restrainPoint, Color.cyan, 0.2f);
        //Debug.DrawLine( center, closestPoint, Color.green, 0.2f );

        if ( restrainPoint != null )
            distance = Vector3.Distance( transform.position, restrainPoint );
    }
    private void ChangeSelectedObject(GameObject gm)
    {
        selectedObject = gm;
        form = selectedObject.GetComponent<Form>();
        UpdateSelectedObjectStats();
    }

    private void UpdateSelectedObjectStats()
    {
        scale = selectedObject.transform.lossyScale / 2;
        center = selectedObject.transform.position;
    }
    public Vector3 CalculateSelectedObjectPosition( Vector3 dir )
    {
        Vector3 currentPos = selectedObject.transform.position;
        Vector3 nextPos = CalculatePosition( dir );

        if ( restrainType == 0 )
        {
            return nextPos;
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
                            return nextPos;
                        }
                    }
                }
            }
            else if ( restrainType == 2 )
            {

                if ( Vector3.Distance( restrainPoint, nextPos ) <= maxDistance.magnitude )
                {
                    //Verifica se esta dentro dos dois limites
                    if ( ( nextPos.x > restrainPoint.x + minDistance.x || nextPos.x < restrainPoint.x - minDistance.x )
                        || ( nextPos.y > restrainPoint.y + minDistance.y || nextPos.y < restrainPoint.y - minDistance.y )
                        || ( nextPos.z > restrainPoint.z + minDistance.z || nextPos.z < restrainPoint.z - minDistance.z ) )
                    {
                        return( nextPos );
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
                        return ( nextPos );
                    }
                }
            }

        }
        else if ( form.GetFormType() == FormType.Sphere )
        {
            if ( restrainType == 1 )
            {
                Debug.Log( "AAAAA" );
                float a = scale.x;
                float b = scale.y;
                float c = scale.z;



                float x0 = nextPos.x;
                float y0 = nextPos.y;
                float z0 = nextPos.z;

                if ( ( ( ( closestPoint.x - x0 ) / a ) * ( ( closestPoint.x - x0 ) / a ) ) +
                    ( ( ( closestPoint.y - y0 ) / b ) * ( ( closestPoint.y - y0 ) / b ) ) +
                    ( ( ( closestPoint.z - z0 ) / c ) * ( ( closestPoint.z - z0 ) / c ) ) < 1 )
                {
                    Debug.Log( ( ( ( closestPoint.x - x0 ) / a ) * ( ( closestPoint.x - x0 ) / a ) ) +
                    ( ( ( closestPoint.y - y0 ) / b ) * ( ( closestPoint.y - y0 ) / b ) ) +
                    ( ( ( closestPoint.z - z0 ) / c ) * ( ( closestPoint.z - z0 ) / c ) ) < 1 );
                    return( nextPos );
                }
            }
            else if ( restrainType == 2 )
            {
                if ( Vector3.Distance( restrainPoint, nextPos ) <= maxDistance.magnitude )
                {
                    //Verifica se esta dentro dos dois limites
                    if ( ( nextPos.x > restrainPoint.x + minDistance.x || nextPos.x < restrainPoint.x - minDistance.x )
                        || ( nextPos.y > restrainPoint.y + minDistance.y || nextPos.y < restrainPoint.y - minDistance.y )
                        || ( nextPos.z > restrainPoint.z + minDistance.z || nextPos.z < restrainPoint.z - minDistance.z ) )
                    {
                        return( nextPos );
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
                        return( nextPos );
                    }
                }
            }
        }
        return currentPos;
    }

    public void MoveSelectedObject( Vector3 newPosition )
    {
        UpdateSelectedObjectStats();
        Vector3 nextPosition = CalculateSelectedObjectPosition(newPosition);
        selectedObject.transform.position = nextPosition;
    }
    public Vector3 CalculatePosition( Vector3 dir )
    {
        return selectedObject.transform.position + dir * Time.deltaTime;
    }

    public void MoveUp()
    {
        MoveSelectedObject( new Vector3( 0, MovementSpeed, 0 ) );
    }
    public void MoveDown()
    {
        MoveSelectedObject( new Vector3( 0, -MovementSpeed, 0 ) );
    }
    public void MoveRight()
    {
        MoveSelectedObject( new Vector3( MovementSpeed, 0, 0 ) );
    }
    public void MoveLeft()
    {
        MoveSelectedObject( new Vector3( -MovementSpeed, 0, 0 ) );
    }
    public void MoveForward()
    {
        MoveSelectedObject( new Vector3( 0, 0, MovementSpeed ) );
    }
    public void MoveBackward()
    {
        MoveSelectedObject( new Vector3( 0, 0, -MovementSpeed ) );
    }

    public void SetRestraintType( int value )
    {
        restrainType = value;
    }

    public void SetRestraintPoint( Vector3 value )
    {
        restrainPoint = value;
    }

    public void SetMaxDistance( Vector3 value )
    {
        maxDistance = value;
    }

    public void SetMinDistance( Vector3 value )
    {
        minDistance = value;
    }

}