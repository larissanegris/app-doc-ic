using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject gameObjectForm;
    
    private Vector3 mOffset;
    private float mZCoord;

    float rotationSpeed = 5000f;
    float sizeChange = 100f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDown()
    {
        gameManager.ChangeSelectedObject(gameObjectForm);
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (gameManager.tipoInteracao == 0)
        {
            Debug.Log("Movendo");
            transform.position = GetMouseAsWorldPoint() + mOffset;
        }
        else if (gameManager.tipoInteracao == 1)
        {
            Debug.Log("Rodando");
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.down, x);
            transform.Rotate(Vector3.right, y);
        }
        else if (gameManager.tipoInteracao == 2)
        {
            Debug.Log("Tamanho");
            float x = Input.GetAxis("Mouse X") * sizeChange * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * sizeChange * Time.deltaTime;
            //float z = Input.GetAxis("Mouse Z") * sizeChange * Time.deltaTime;
            transform.localScale = transform.localScale + new Vector3(x, y, 0);
        }
    }

 

    public void SetForm(GameObject gameObjectForm)
    {
        this.gameObjectForm = gameObjectForm;
    }

    public void ChangeColor(Colors newColor)
    {
        gameObjectForm.GetComponent<Form>().previousCor = gameObjectForm.GetComponent<Form>().cor;
        if (newColor == Colors.Yellow)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (newColor == Colors.Orange)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = new Color(1, 0.37f, 0.1f, 1);
        }
        else if (newColor == Colors.Red)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (newColor == Colors.Pink)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = new Color(0.9f, 0, 0.9f, 1);
        }
        else if (newColor == Colors.Grey)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = Color.gray;
        }
        else if (newColor == Colors.White)
        {
            gameObjectForm.GetComponent<Renderer>().material.color = Color.white;
        }
        gameObjectForm.GetComponent<Form>().cor = newColor;
    }
}
