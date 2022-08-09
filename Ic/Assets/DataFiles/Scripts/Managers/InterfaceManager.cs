using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceManager : MonoBehaviour
{
    public Button areaAberta;
    public Button areaFechada;
    public Button reuniaoAtiva;
    public Button reuniaoPassiva;
    public GameObject parent;
    private InstantiationManager instantiationManager;

    private void Awake()
    {
        instantiationManager = GetComponent<InstantiationManager>();
        areaAberta.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, false ) );
        areaFechada.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, false ) );
        reuniaoAtiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Cube, true ) );
        reuniaoPassiva.onClick.AddListener( () => instantiationManager.Spawn( FormType.Sphere, true ) );
    }

    private void Task(FormType ft, bool isTransparent)
    {
        instantiationManager.Spawn( FormType.Cube, false );
    }
}
