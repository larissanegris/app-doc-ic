using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject target;
    private int tipoInteracao;
    public ColorManager colorManager;

    private void Start()
    {
        colorManager = gameManager.GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        target = gameManager.selectedObject;
        tipoInteracao = gameManager.tipoInteracao;
        //Criar cubo
        if (Input.GetKeyDown(KeyCode.Q))
        {
            //Debug.Log("Espaço: Criando Instancia de Cubo");
            gameManager.prefabInstantiator.SpawnCube();
        }
        //criar esfera
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log("Espaço: Criando Instancia de Esfera");
            gameManager.prefabInstantiator.SpawnSphere();
        }

        //Mudar Cores
        if (Input.GetKeyDown(KeyCode.W))
        {
            //Debug.Log("W: Mudando Cor Laranja");
            colorManager.ChangeColor(Colors.Orange, target);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("A: Mudando Cor Vermelho");
            colorManager.ChangeColor(Colors.Red, target);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            //Debug.Log("S: Mudando Cor Rosa");
            colorManager.ChangeColor(Colors.Pink, target);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //Debug.Log("D: Mudando Cor Amarelo");
            colorManager.ChangeColor(Colors.Yellow, target);
        }



        //teclas para selecionar os objetos
        //Mover
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            gameManager.tipoInteracao = 0;
        }
        //Rotacionar
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.tipoInteracao = 1;
        }
        //escalar
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.tipoInteracao = 2;
        }

        //Movimentacao
        if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            if(tipoInteracao == 0)
            {
                //Debug.Log("Move UP");
                target.GetComponent<MoveObject>().MoveUp();
            }
            else if(tipoInteracao == 1)
            {
                //Debug.Log("Rotate UP");
                target.GetComponent<RotateObject>().RotateUp();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale UP");
                target.GetComponent<ResizeObject>().ScaleUp();
            }

        }
        if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (tipoInteracao == 0)
            {
                //Debug.Log("Move Down");
                target.GetComponent<MoveObject>().MoveDown();
            }
            else if (tipoInteracao == 1)
            {
                //Debug.Log("Rotate Down");
                target.GetComponent<RotateObject>().RotateDown();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale Down");
                target.GetComponent<ResizeObject>().ScaleDown();
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (tipoInteracao == 0)
            {
                //Debug.Log("Move Right");
                target.GetComponent<MoveObject>().MoveRight();
            }
            else if (tipoInteracao == 1)
            {
                //Debug.Log("Rotate Right");
                target.GetComponent<RotateObject>().RotateRight();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale Right");
                target.GetComponent<ResizeObject>().ScaleRight();
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (tipoInteracao == 0)
            {
                //Debug.Log("Move Left");
                target.GetComponent<MoveObject>().MoveLeft();
            }
            else if (tipoInteracao == 1)
            {
                //Debug.Log("Rotate Left");
                target.GetComponent<RotateObject>().RotateLeft();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale Left");
                target.GetComponent<ResizeObject>().ScaleLeft();
            }
        }
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            if (tipoInteracao == 0)
            {
                //Debug.Log("Move Forward");
                target.GetComponent<MoveObject>().MoveForward();
            }
            else if (tipoInteracao == 1)
            {
                //Debug.Log("Rotate Forward");
                target.GetComponent<RotateObject>().RotateForward();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale Forward");
                target.GetComponent<ResizeObject>().ScaleForward();
            }
        }
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftShift))
        {
            if (tipoInteracao == 0)
            {
                //Debug.Log("Move Backward");
                target.GetComponent<MoveObject>().MoveBackward();
            }
            else if (tipoInteracao == 1)
            {
                //Debug.Log("Rotate Backward");
                target.GetComponent<RotateObject>().RotateBackward();
            }
            else if (tipoInteracao == 2)
            {
                //Debug.Log("Scale Backward");
                target.GetComponent<ResizeObject>().ScaleBackward();
            }
        }
    }
}
