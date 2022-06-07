using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
public class ObjectCollider : MonoBehaviour
{
    private bool isSelected;
    private GameManager gameManager;

    private Move move;

    private Vector3 halfBox;
    private Vector3 center;
    private Form form;

    [SerializeField] [Range (0, 20)] private float radius;
    [SerializeField] private GameObject closestObject;
    [SerializeField] private float distToClosest;
    [SerializeField] [Range(0, 2)] private float dist;
    private Vector3 closestPoint;
    private Vector3 colliderCenter;
    private DrawPlane plane;

    /*
    [SerializeField][Range (0, 1)] private float maxD = .1f;
    [SerializeField] private float currentDist;
    */

    private int tipoConecao;


    private void Awake()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        form = GetComponent<Form>();
        radius = 12;
        move = gameManager.GetComponent<Move>();
    }

    private void FixedUpdate()
    {
        if(tag == "Selected")
        {
            tipoConecao = gameManager.GetTipoConecao();
            center = transform.position;
            //Debug.DrawLine( closestPoint, center, Color.yellow, 1 );
            closestObject = nearbyObjects(out closestPoint);
            move.closestPoint = closestPoint;
            Debug.DrawLine( center, closestPoint, Color.yellow, 0.2f );
            
            if (form.GetFormType() == FormType.Cube )
            {
                if( closestObject != null )
                {
                    //MakeInteractionCube( closestObject );
                }
            }
            else if ( form.GetFormType() == FormType.Sphere )
            {
                if ( closestObject != null )
                {
                    //MakeInteractionSphere( closestObject );
                }
            }


            VerifyInteractionsCube();

        }
    }
    

    private GameObject nearbyObjects(out Vector3 closestPoint)
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        GameObject closest = null;
        distToClosest = float.PositiveInfinity;
        closestPoint = Vector3.zero;
        foreach (var hitCollider in hitColliders)
        {
            if ( hitCollider.gameObject != gameObject && hitCollider != null && hitCollider.gameObject.tag != "Floor")
            {
                float dis = Vector3.Distance( hitCollider.gameObject.transform.position, gameObject.transform.position );
                if (dis < distToClosest)
                {
                    closest = hitCollider.gameObject;
                    colliderCenter = closest.transform.position;
                    closestPoint = hitCollider.ClosestPoint(transform.position);
                    distToClosest = Vector3.Distance( center, closestPoint );
                }
            }
        }
        //Debug.Log("Closest: " + closest);
        return closest;
    }

    private void MakeInteractionCube(GameObject closestObject )
    {
        Vector3 colliderCenter = closestObject.transform.position;
        if ( closestObject != null )
        {
            halfBox = transform.lossyScale * 0.5f;
            //Sem conecao
            if ( tipoConecao == 0 )
            {
                gameManager.RestrainPoint( colliderCenter );
            }
            //Colisao
            if ( tipoConecao == 1 )
            {
                Debug.DrawLine( colliderCenter, colliderCenter + ( halfBox * 2 ), Color.red, 1 );
                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMaxDistance( closestObject.transform.lossyScale / 2 + halfBox );
            }
            //Face a Face
            if ( tipoConecao == 2 )
            {

                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMaxDistance( closestObject.transform.lossyScale / 2 + halfBox + (Vector3.one * dist) );
                gameManager.RestrainMinDistance( closestObject.transform.lossyScale / 2 + halfBox - (Vector3.one * dist) );

                //currentDist = ( closestObject.transform.lossyScale / 2 + ( Vector3.one * maxD ) ).magnitude;

                //Debug.DrawLine( center, closestObject.transform.lossyScale / 2 + halfBox + ( Vector3.one * maxD ), Color.magenta, 1 );
                //Debug.DrawLine( center, closestObject.transform.lossyScale / 2 + halfBox - ( Vector3.one * .1f ), Color.red, 1 );
            }
            //Distancia
            if ( tipoConecao == 3 )
            {
                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMinDistance( halfBox * 2 + Vector3.one );
                gameManager.RestrainMaxDistance( halfBox * 2 + Vector3.one * 6 );
            }

        }
    }

    private void VerifyInteractionsCube()
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        halfBox = transform.lossyScale * 0.5f;
        

        foreach (Collider hitCollider in hitColliders )
        {

            if ( hitCollider.gameObject != gameObject && hitCollider.gameObject.tag != "Floor" )
            {
                //verifica se é conecao do tipo 1
                Vector3 colliderCenter = hitCollider.transform.position;

                Vector3 hitColliderHalfBox = hitCollider.transform.lossyScale * 0.5f;
                Vector3 maxDistance = halfBox + hitColliderHalfBox;
                
                //Verifica contato
                if ( Mathf.Abs( ( colliderCenter.x - center.x ) ) < maxDistance.x )
                {
                    if ( Mathf.Abs( ( colliderCenter.y - center.y ) ) < maxDistance.y )
                    {
                        if ( Mathf.Abs( ( colliderCenter.z - center.z ) ) < maxDistance.z )
                        {
                            Debug.Log( "Dentro" );
                            Debug.DrawRay( center, colliderCenter, Color.red, 0.1f );
                            Debug.DrawRay( center, center + halfBox, Color.green, 0.1f );
                            continue;
                        }
                    }
                }

                //Verifica se é do tipo 2

                Vector3 volumeHalfBox = hitCollider.transform.GetChild( 0 ).transform.lossyScale * .5f;
                maxDistance = halfBox + colliderCenter + volumeHalfBox;

                if ( Mathf.Abs( ( colliderCenter.x - center.x ) ) < maxDistance.x )
                {
                    if ( Mathf.Abs( ( colliderCenter.y - center.y ) ) < maxDistance.y )
                    {
                        if ( Mathf.Abs( ( colliderCenter.z - center.z ) ) < maxDistance.z )
                        {
                            Debug.Log( "Dentro" );
                            Debug.DrawRay( center, colliderCenter, Color.red, 0.1f );
                            Debug.DrawRay( center, center + halfBox, Color.green, 0.1f );
                            continue;
                        }
                    }
                }


            }

        }

    }

    private void MakeInteractionSphere( GameObject closestObject )
    {
        

        Vector3 colliderCenter = closestObject.transform.position;
        if ( closestObject != null )
        {
            halfBox = transform.lossyScale * 0.5f;
            //Sem conecao
            if ( tipoConecao == 0 )
            {
                gameManager.RestrainPoint( colliderCenter );
            }
            //Colisao
            if ( tipoConecao == 1 )
            {
                Debug.DrawLine( colliderCenter, colliderCenter + ( halfBox * 2 ), Color.red, 1 );
                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMaxDistance( closestObject.transform.lossyScale / 2 );
            }
            //Face a Face
            if ( tipoConecao == 2 )
            {

                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMaxDistance( closestObject.transform.lossyScale / 2 + halfBox + ( Vector3.one * .1f ) );
                gameManager.RestrainMinDistance( closestObject.transform.lossyScale / 2 + halfBox - ( Vector3.one * .1f ) );


            }
            //Distancia
            if ( tipoConecao == 3 )
            {
                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMinDistance( halfBox * 2 + Vector3.one );
                gameManager.RestrainMaxDistance( halfBox * 2 + Vector3.one * 6 );
            }

        }
    }
}
