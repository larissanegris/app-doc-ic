using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPlane : MonoBehaviour
{
    float xOffset = 0;
    [SerializeField] [Range(0f, 1f)] float yRotOfsset;
    List<Vector3> vertices;
    Vector3 aux;

    [SerializeField] [Range(0f, 1f)] float x;
    [SerializeField] [Range(0f, 1f)] float y;
    private Vector3 point;

    private void Update()
    {
        //drawCube(this.gameObject);
    }
    public void Draw( Vector3 position, Vector3 normal )
    {

        Vector3 v3; ;

        if ( normal.normalized != Vector3.forward )
            v3 = Vector3.Cross( normal, Vector3.forward ).normalized * normal.magnitude;
        else
            v3 = Vector3.Cross( normal, Vector3.up ).normalized * normal.magnitude; ;

        var corner0 = position + v3;
        var corner2 = position - v3;
        var q = Quaternion.AngleAxis(90.0f, normal);
        v3 = q * v3;
        var corner1 = position + v3;
        var corner3 = position - v3;

        Debug.DrawLine( corner0, corner2, Color.green );
        Debug.DrawLine( corner1, corner3, Color.green );
        Debug.DrawLine( corner0, corner1, Color.green );
        Debug.DrawLine( corner1, corner2, Color.green );
        Debug.DrawLine( corner2, corner3, Color.green );
        Debug.DrawLine( corner3, corner0, Color.green );
        Debug.DrawRay( position, normal, Color.red );
    }

    public void drawCube(GameObject Cube)
    {
        Vector3 center = Cube.transform.position;
        Vector3 scale = Cube.transform.lossyScale;
        scale /= 2;
        Vector3 rotation = Cube.transform.rotation.eulerAngles;
        Vector3 lrotation = Cube.transform.localRotation.eulerAngles;


        vertices = new List<Vector3>();
        Vector3 newCenter = center;
        newCenter.x += xOffset*2;
        Vector3 newRotation = lrotation;
        newRotation.y += yRotOfsset * 90;

        point = new Vector3( x + center.x - scale.x, y + center.y - scale.y, center.z - scale.z );

        Debug.DrawLine ( newCenter, point, Color.yellow, 1 );

        for (int i = 0; i < 2; i++ )
        {
            for ( int j = 0; j < 2; j++ )
            {
                for ( int k = 0; k < 2; k++ )
                {
                    aux.x = (i == 0 ? -scale.x : scale.x);
                    aux.y = (j == 0 ? -scale.y : scale.y);
                    aux.z = (k == 0 ? -scale.z : scale.z);
                    aux = Quaternion.Euler( newRotation ) * aux;
                    aux += newCenter;
                    
                    vertices.Add(aux);
                }
            }
        }
        
        foreach(Vector3 v in vertices )
        {
            foreach(Vector3 v2 in vertices )
            {
                if(v != v2 )
                {
                    Debug.DrawLine( v, v2, Color.black, 0.3f );
                }
            }
        }
    }
}
