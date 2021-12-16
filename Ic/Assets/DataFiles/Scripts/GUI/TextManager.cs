using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textObjectMode;
    public Text selectedObject;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        textObjectMode.text = "Modo: ";
        if(gameManager.tipoInteracao == 0)
        {
            textObjectMode.text = "Modo: Mover";
        }
        else if (gameManager.tipoInteracao == 1)
        {
            textObjectMode.text = "Modo: Rotacao";
        }
        else if (gameManager.tipoInteracao == 2)
        {
            textObjectMode.text = "Modo: Tamanho";
        }
        if (gameManager.selectedObject != null)
        {
            selectedObject.text = "Objeto Selecionado: " + gameManager.selectedObject.name.ToString();
        }
        else
        {
            selectedObject.text = "Objeto Selecionado: Nenhum";
        }

    }
}
