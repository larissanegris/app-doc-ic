using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotPassFloor : MonoBehaviour
{
    private Transform trans;
    [SerializeField]
    private GameObject floor;
    private GameManager gameManager;
    private Form form;

    // Start is called before the first frame update
    void Start()
    {
        form = GetComponent<Form>();
        floor = GameObject.FindWithTag("Floor");
    }

    // Update is called once per frame
    void Update()
    {
        if (form.GetIsSelected())
        {
            FrontOfPlane();
        }
    }

    public void FrontOfPlane()
    {
        Vector3 position = transform.position;
        Vector3 planeNormal = floor.transform.up;
        Vector3 planePoint = floor.transform.position;

        // Calcula a distância do centro do GameObject ao plano
        float distance = Vector3.Dot(planeNormal, position - planePoint);

        // Considera as dimensões do objeto para determinar a frente do objeto
        Vector3 objectDimensions = GetComponent<Renderer>().bounds.size;
        Vector3 objectFront = transform.position - transform.up * objectDimensions.y * 0.5f;

        float distanceToObjectFront = Vector3.Dot(planeNormal, objectFront - planePoint);

        // Se a frente do objeto estiver atrás do plano, ajusta sua posição
        if (distanceToObjectFront < 0f)
        {
            Debug.Log("Frente do objeto atrás do plano");

            // Move o GameObject para frente do plano e ajusta a altura
            float moveDistance = -distanceToObjectFront;
            Vector3 moveVector = planeNormal * moveDistance;
            position += moveVector;
            transform.position = position;
        }
    }


}
