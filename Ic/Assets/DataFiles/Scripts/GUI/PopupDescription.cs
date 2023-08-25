using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupDescription : MonoBehaviour
{
    private GameManager gameManager;
    private TouchSelectionManager touchSelectionManager;
    private ColorManager colorManager;

    [SerializeField]
    private GameObject TextMeshPro;
    private TMP_Text TMP;
    [SerializeField]
    private string[,,] textsDescription = new string[2, 2, 4];

    private void Start()
    {
        TMP = TextMeshPro.GetComponent<TMP_Text>();
        gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        touchSelectionManager = gameManager.GetComponent<TouchSelectionManager>();
        colorManager = gameManager.GetComponent<ColorManager>();

        touchSelectionManager.selectionChangeMultiple += ChangeTextSelect;
        colorManager.colorChanged += ChangeTextCol;

        //Cubo Opaco
        textsDescription[0, 0, 0] = "Áreas Sociais";
        textsDescription[0, 0, 1] = "Cantina";
        textsDescription[0, 0, 2] = "Áreas para Público";
        textsDescription[0, 0, 3] = "Atividades";

        textsDescription[1, 0, 0] = "Administração";
        textsDescription[1, 0, 1] = "Áreas Sujas";
        textsDescription[1, 0, 2] = "Alim. Casual";
        textsDescription[1, 0, 3] = "Banheiros";

        textsDescription[0, 1, 0] = "Flexibilidade";
        textsDescription[0, 1, 1] = "Ativ. em Grupo";
        textsDescription[0, 1, 2] = "Ativ. Individual";
        textsDescription[0, 1, 3] = "Comunidade";

        textsDescription[1, 1, 0] = "Armazenamento";
        textsDescription[1, 1, 1] = "Zoneamento";
        textsDescription[1, 1, 2] = "Exibição";
        textsDescription[1, 1, 3] = "";

    }

    private void ChangeTextSelect(bool selectMultiple, List<GameObject> multiple, GameObject go)
    {
        if (!selectMultiple)
            ChangeTextCol(go);
        else
            TMP.text = "Seleção Múltipla";
    }

    private void ChangeTextCol(GameObject go)
    {
        Form f = go.GetComponent<Form>();
        int cube = (int)f.GetFormType();
        int transparent = (f.transparent ? 1 : 0);
        int cor = f.cor;
        Debug.Log(cube.ToString() + " " + transparent.ToString() + " " + cor.ToString());
        if (cor == -1)
            TMP.text = "Nenhum";
        else
            TMP.text = textsDescription[cube, transparent, cor];
    }

}
