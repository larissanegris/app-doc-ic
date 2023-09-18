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

    public Button copy;


    [Header("Cores")]
    public Button cor0;
    public Button cor1;
    public Button cor2;
    public Button cor3;
    private List<Button> btns;


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

        touchSelectionManager.selectionChangeMultiple += ChangeBtnColor;
        //FindObjectOfType<InstantiationManager>().Instantiation += ChangeBtnColor;

        btns = new List<Button> { cor0, cor1, cor2, cor3 };

        SpawnBtnSetup();
        ColorBtnSetup();

        //selectionManager.selectionChange += ChangeBtnColor;

    }

    private void SpawnBtnSetup()
    {
        areaAberta.onClick.AddListener(() => instantiationManager.Spawn(FormType.Cube, false));
        areaFechada.onClick.AddListener(() => instantiationManager.Spawn(FormType.Sphere, false));
        reuniaoAtiva.onClick.AddListener(() => instantiationManager.Spawn(FormType.Cube, true));
        reuniaoPassiva.onClick.AddListener(() => instantiationManager.Spawn(FormType.Sphere, true));
    }

    private void ColorBtnSetup()
    {
        cor0.onClick.AddListener(() => colorManager.ChangeColor(0, tgt));
        cor1.onClick.AddListener(() => colorManager.ChangeColor(1, tgt));
        cor2.onClick.AddListener(() => colorManager.ChangeColor(2, tgt));
        cor3.onClick.AddListener(() => colorManager.ChangeColor(3, tgt));
    }

    private void ChangeColor(int i)
    {
        colorManager.ChangeColor(i, tgt);
    }

    private void ChangeBtnColor(bool selectMultipleObjects, List<GameObject> selectedObj, GameObject target)
    {
        if (!selectMultipleObjects)
        {
            tgt = target;
            cor3.gameObject.SetActive(true);
            if (target.GetComponent<Form>().GetFormType() == FormType.Cube)
                colorManager.BtnColorCube(btns);
            else {
                colorManager.BtnColorSphere(btns);
                if (target.GetComponent<Form>().transparent)
                    cor3.gameObject.SetActive(false);
            }
                


        }
        else
        {
            colorManager.BtnColorDisable(btns);
        }
        
    }

    private void CopySelectedObject()
    {
        
    }
}
