using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameObject parent;
    public GameObject tgt;

    [Header("Botoes Geração")]
    public Button areaAberta;
    public Button areaFechada;
    public Button reuniaoAtiva;
    public Button reuniaoPassiva;


    [Header("Cores")]
    public Button cor0;
    public Button cor1;
    public Button cor2;
    public Button cor3;


    private GameManager gameManager;
    private InstantiationManager instantiationManager;
    private ColorManager colorManager;
    private TouchSelectionManager touchSelectionManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        colorManager = GetComponent<ColorManager>();
        touchSelectionManager = GetComponent<TouchSelectionManager>();

        touchSelectionManager.selectionChange += ChangeBtnColor;
        //FindObjectOfType<InstantiationManager>().Instantiation += ChangeBtnColor;

        areaAberta.onClick.AddListener(() => instantiationManager.Spawn(FormType.Cube, false));
        areaFechada.onClick.AddListener(() => instantiationManager.Spawn(FormType.Sphere, false));
        reuniaoAtiva.onClick.AddListener(() => instantiationManager.Spawn(FormType.Cube, true));
        reuniaoPassiva.onClick.AddListener(() => instantiationManager.Spawn(FormType.Sphere, true));

        cor0.onClick.AddListener(() => colorManager.ChangeColor(0, tgt));
        cor1.onClick.AddListener(() => colorManager.ChangeColor(1, tgt));
        cor2.onClick.AddListener(() => colorManager.ChangeColor(2, tgt));
        cor3.onClick.AddListener(() => colorManager.ChangeColor(3, tgt));

        //selectionManager.selectionChange += ChangeBtnColor;

    }

    private void Task(FormType ft, bool isTransparent)
    {
        instantiationManager.Spawn(FormType.Cube, false);
    }

    private void ChangeBtnColor(bool selectMultipleObjects, List<GameObject> selectedObj)
    {
        if (!selectMultipleObjects)
        {
            tgt = selectedObj[0];
            colorManager.ChangeBtnColor(0, cor0.gameObject, tgt.GetComponent<Form>().GetFormType());
            colorManager.ChangeBtnColor(1, cor1.gameObject, tgt.GetComponent<Form>().GetFormType());
            colorManager.ChangeBtnColor(2, cor2.gameObject, tgt.GetComponent<Form>().GetFormType());
            colorManager.ChangeBtnColor(3, cor3.gameObject, tgt.GetComponent<Form>().GetFormType());
        }
        else
        {
            colorManager.ChangeBtnColor(-1, cor0.gameObject, FormType.Cube);
            colorManager.ChangeBtnColor(-1, cor1.gameObject, FormType.Cube);
            colorManager.ChangeBtnColor(-1, cor2.gameObject, FormType.Cube);
            colorManager.ChangeBtnColor(-1, cor3.gameObject, FormType.Cube);
        }
        
    }
}
