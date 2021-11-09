using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("a");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Espaço: Criando Instancia de Cubo");
            gameManager.selectedObject = gameManager.prefabInstantiator.SpawnCube();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Espaço: Criando Instancia de Esfera");

            gameManager.selectedObject = gameManager.prefabInstantiator.SpawnSphere();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");

            gameManager.selectedObject.GetComponent<Form>().ChangeColor(Colors.Orange);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");

            gameManager.selectedObject.GetComponent<Form>().ChangeColor(Colors.Yellow);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");

            gameManager.selectedObject.GetComponent<Form>().ChangeColor(Colors.Red);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Esquerda: Mudando Cor Laranja");

            gameManager.selectedObject.GetComponent<Form>().ChangeColor(Colors.Pink);
        }
    }
}
