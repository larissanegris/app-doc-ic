using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightManager : MonoBehaviour
{
    public GameManager gameManager;
    public ColorManager colorManager;

    public Material baseMaterial;
    public Material highlightMat;

    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = GetComponent<ColorManager>();
    }

    //funcao que da highlight no objeto
    public void HighlightObject(GameObject target)
    {
        if (target == null)
            return;
        //pega componentes
        Renderer render = target.GetComponent<Renderer>();
        Form form = target.GetComponent<Form>();

        //muda material e deixa da mesma cor
        // render.material = highlightMat;
        colorManager.ChangeColor(form.cor, target);
    }

    public void UnhighlightObject(GameObject target)
    {
        //pega componentes
        Renderer render = target.GetComponent<Renderer>();
        Form form = target.GetComponent<Form>();

        //muda material e deixa da mesma cor
        colorManager.ChangeColor(form.cor, target);
    }
}
