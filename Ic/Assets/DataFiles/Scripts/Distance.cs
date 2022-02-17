using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distances : MonoBehaviour
{
    private enum Distance
    {
        Space,
        XYPlane
    }

    [SerializeField] private GameObject object1;
    [SerializeField] private GameObject object2;
    [SerializeField] private TextMesh distanceIndicator;
    [SerializeField] private Distance distanceType;

    private float distance;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, object1.transform.position);
        lineRenderer.SetPosition(1, object2.transform.position);


        switch (distanceType)
        {
            case Distance.Space:
                distance = CalculateDistanceInSpace();
                distanceIndicator.text = "Distance in space: " + distance.ToString();
                break;
            case Distance.XYPlane:
                distance = CalculateDistanceXYPlane();
                distanceIndicator.text = "Distance in XYPlane: " + distance.ToString();
                break;
        }
    }

    private float CalculateDistanceInSpace()
    {
        return Vector3.Distance(object1.transform.position, object2.transform.position);
    }

    private float CalculateDistanceXYPlane()
    {
        Vector2 v1 = new Vector2(object1.transform.position.x, object1.transform.position.y);
        Vector2 v2 = new Vector2(object2.transform.position.x, object2.transform.position.y);
        return Vector3.Distance(v1, v2);
    }

}
