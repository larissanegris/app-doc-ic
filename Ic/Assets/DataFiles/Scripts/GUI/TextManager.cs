using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textObjectMode;
    public Text selectedObject;
    public Text interactionBlock;
    public Text conectionType;
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


        if (gameManager.GetSelectedObject() != null)
        {
            selectedObject.text = "Objeto Selecionado: " + gameManager.GetSelectedObject().name.ToString();
        }
        else
        {
            selectedObject.text = "Objeto Selecionado: Nenhum";
        }

        if (gameManager.blockInteraction)
        {
            interactionBlock.text = "Bloco";
        }
        else
        {
            interactionBlock.text = "Individual";
        }

        conectionType.text = "Conecao: ";
        if (gameManager.tipoConecao == 0)
        {
            conectionType.text = "Conecao: Nenhuma";
        }
        else if (gameManager.tipoConecao == 1)
        {
            conectionType.text = "Conecao: Colisao";
        }
        else if (gameManager.tipoConecao == 2)
        {
            conectionType.text = "Conecao: Face a Face";
        }
        else if (gameManager.tipoConecao == 3)
        {
            conectionType.text = "Conecao: Proximidade";
        }

    }
}
