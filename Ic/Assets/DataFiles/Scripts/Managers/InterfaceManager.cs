using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public GameObject parent;

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
    private SelectionManager selectionManager;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        colorManager = GetComponent<ColorManager>();
        selectionManager = GetComponent<SelectionManager>();

        areaAberta.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, false ) );
        areaFechada.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, false ) );
        reuniaoAtiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, true ) );
        reuniaoPassiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, true ) );

        cor0.onClick.AddListener(() => colorManager.ChangeColor(0, gameManager.selectedObject));
        cor1.onClick.AddListener(() => colorManager.ChangeColor(1, gameManager.selectedObject));
        cor2.onClick.AddListener(() => colorManager.ChangeColor(2, gameManager.selectedObject));
        cor3.onClick.AddListener(() => colorManager.ChangeColor(3, gameManager.selectedObject));

        selectionManager.selectionChange += ChangeBtnColor;

    }

    private void Task(FormType ft, bool isTransparent)
    {
        instantiationManager.Spawn( FormType.Cube, false );
    }

    private void ChangeBtnColor(GameObject tgt)
    {
        colorManager.ChangeBtnColor(0, cor0.gameObject, tgt.GetComponent<Form>().GetFormType());
        colorManager.ChangeBtnColor(1, cor1.gameObject, tgt.GetComponent<Form>().GetFormType());
        colorManager.ChangeBtnColor(2, cor2.gameObject, tgt.GetComponent<Form>().GetFormType());
        colorManager.ChangeBtnColor(3, cor3.gameObject, tgt.GetComponent<Form>().GetFormType());
    }
}
