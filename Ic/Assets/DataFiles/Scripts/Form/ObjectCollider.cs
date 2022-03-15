using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    private bool isSelected;
    private GameManager gameManager;
    private InteractionBlock interactionBlock;
    public PopupExample pop;

    [SerializeField] private Vector3 halfBox;
    private Vector3 center;
    private Form form;

    [SerializeField] [Range (0, 20)] private float radius;
    [SerializeField] private GameObject closestObject;
    [SerializeField] private float distToClosest;
    private Vector3 closestPoint;
    private Vector3 colliderCenter;
    private DrawPlane plane;

    public Vector3 a;
    public Vector3 distance;
    public Vector3 n;

    private int tipoConecao;


    private void Awake()
    {
        
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        form = GetComponent<Form>();
        interactionBlock = transform.parent.GetComponent<InteractionBlock>();
        plane = GameObject.Find("Auxiliar").GetComponent<DrawPlane>();
        radius = 12;
    }

    private void FixedUpdate()
    {
        if(tag == "Selected")
        {
            if(form.GetFormType() == Type.Cube )
            {
                tipoConecao = gameManager.GetTipoConecao();
                center = transform.position;
                Debug.DrawLine( closestPoint, center, Color.yellow, 1 );

                GameObject closestObject = nearbyObjects();
                MakeInteraction(closestObject);
            }
            
        }
    }
    

    private GameObject nearbyObjects()
    {
        
        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        closestObject = null;
        distToClosest = float.PositiveInfinity;

        foreach (var hitCollider in hitColliders)
        {
            if ( hitCollider.gameObject != gameObject && hitCollider != null )
            {
                float dis = Vector3.Distance( hitCollider.gameObject.transform.position, gameObject.transform.position );
                if (dis < distToClosest)
                {
                    closestObject = hitCollider.gameObject;
                    colliderCenter = closestObject.transform.position;
                    closestPoint = hitCollider.ClosestPoint(transform.position);
                    distToClosest = Vector3.Distance( center, closestPoint );
                }
            }
        }
        return closestObject;
    }

    private void MakeInteraction(GameObject closestObject )
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
                Faces( this.gameObject, closestObject, out Vector3 point );
                /*
                gameManager.RestrainPoint( closestPoint );
                gameManager.RestrainMinDistance( Vector3.zero );
                gameManager.RestrainMaxDistance( Vector3.one * 3 );
                */
                gameManager.RestrainPoint( colliderCenter );
                gameManager.RestrainMaxDistance( closestObject.transform.lossyScale / 2 + halfBox + (Vector3.one * .1f) );
                gameManager.RestrainMinDistance( closestObject.transform.lossyScale / 2 + halfBox - (Vector3.one * .1f) );


                //Debug.DrawLine( center, closestPoint, Color.magenta, 1 );
                Debug.DrawLine( Vector3.zero, point, Color.magenta, 1 );
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

    private Vector3 FindNormal( Vector3 vec )
    {
        Vector3 aux = vec;
        if ( vec.x > vec.y )
        {
            if ( vec.x > vec.z )
                aux.x = 0;
            else
                aux.z = 0;
        }
        else
        {
            if ( vec.y > vec.z )
                aux.y = 0;
            else
                aux.z = 0;
        }
        return aux;
    }

    public bool Faces( GameObject source, GameObject target, out Vector3 point )
    {
        Vector3 spos = source.transform.position;
        Vector3 shbox = source.transform.lossyScale/2;

        Vector3 tpos = target.transform.position;
        Vector3 thbox = target.transform.lossyScale/2;

        

        if( (spos.y < tpos.y + thbox.y && spos.y > tpos.y - thbox.y )
            || ( spos.x < tpos.x + thbox.x && spos.x > tpos.x - thbox.x )
            )
        {
            Vector3 a = spos;
            a.z = tpos.z + thbox.z;
            Vector3 b = spos;
            b.z  = tpos.z - thbox.z;
            Debug.DrawLine( a, b, Color.red, 1 );

            plane.drawCube( target );
            Vector3 dst = spos - tpos;
            point = ( tpos + ( dst ) ).normalized;
            point *= ( thbox + shbox ).magnitude;

            return true;
        }
        point = Vector3.zero;
        return false;
    }
}
