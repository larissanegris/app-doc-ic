using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Objetos de Texto")]
    public Text textObjectMode;
    public Text selectedObject;
    public Text conectionType;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        textObjectMode.text = "Modo: ";
        if(gameManager.interactionType == 0)
        {
            textObjectMode.text = "Modo: Mover";
        }
        else if (gameManager.interactionType == 1)
        {
            textObjectMode.text = "Modo: Rotacao";
        }
        else if (gameManager.interactionType == 2)
        {
            textObjectMode.text = "Modo: Tamanho";
        }
        else if ( gameManager.interactionType == 3 )
        {
            textObjectMode.text = "Modo: Camera";
        }


        if (gameManager.GetSelectedObject() != null)
        {
            selectedObject.text = "Objeto Selecionado: " + gameManager.GetSelectedObject().name.ToString();
        }
        else
        {
            selectedObject.text = "Objeto Selecionado: Nenhum";
        }

        conectionType.text = "Conecao: ";
        if (gameManager.connectionType == 0)
        {
            conectionType.text = "Conecao: Nenhuma";
        }
        else if (gameManager.connectionType == 1)
        {
            conectionType.text = "Conecao: Colisao";
        }
        else if (gameManager.connectionType == 2)
        {
            conectionType.text = "Conecao: Face a Face";
        }
        else if (gameManager.connectionType == 3)
        {
            conectionType.text = "Conecao: Proximidade";
        }

    }
}
