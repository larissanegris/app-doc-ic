using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textObject;
    public GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        textObject.text = "Modo: ";
        if(gameManager.tipoInteracao == 0)
        {
            textObject.text = "Modo: Mover";
        }
        else if (gameManager.tipoInteracao == 1)
        {
            textObject.text = "Modo: Rotacao";
        }
        else if (gameManager.tipoInteracao == 2)
        {
            textObject.text = "Modo: Tamanho";
        }
    }
}
