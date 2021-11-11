using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text textObject;
    public GameManager gameManager;
    public string text;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        textObject.text = "Modo: " + gameManager.tipoInteracao;
    }
}
