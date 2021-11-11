using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        //Criar cubo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espaço: Criando Instancia de Cubo");
            gameManager.selectedObject = gameManager.prefabInstantiator.SpawnCube();
        }
        //criar esfera
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Espaço: Criando Instancia de Esfera");
            gameManager.selectedObject = gameManager.prefabInstantiator.SpawnSphere();
        }

        //Mudar Cores
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");
            gameManager.selectedObject.GetComponent<Interactions>().ChangeColor(Colors.Orange);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");
            gameManager.selectedObject.GetComponent<Interactions>().ChangeColor(Colors.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");
            gameManager.selectedObject.GetComponent<Interactions>().ChangeColor(Colors.Red);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");
            gameManager.selectedObject.GetComponent<Interactions>().ChangeColor(Colors.Pink);
        }

        //teclas para selecionar os objetos
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            gameManager.tipoInteracao = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gameManager.tipoInteracao = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gameManager.tipoInteracao = 2;
        }


    }
}
