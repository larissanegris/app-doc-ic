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

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        instantiationManager = GetComponent<InstantiationManager>();
        colorManager = GetComponent<ColorManager>();


        areaAberta.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, false ) );
        areaFechada.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, false ) );
        reuniaoAtiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, true ) );
        reuniaoPassiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, true ) );

        cor0.onClick.AddListener(() => colorManager.ChangeColor(0, gameManager.selectedObject));
        cor1.onClick.AddListener(() => colorManager.ChangeColor(1, gameManager.selectedObject));
        cor2.onClick.AddListener(() => colorManager.ChangeColor(2, gameManager.selectedObject));
        cor3.onClick.AddListener(() => colorManager.ChangeColor(3, gameManager.selectedObject));

    }

    private void Task(FormType ft, bool isTransparent)
    {
        instantiationManager.Spawn( FormType.Cube, false );
    }
}
