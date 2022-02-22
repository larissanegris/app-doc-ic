using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public GameManager gameManager;

    private float darkeninFactor = 0.8f;
    private float lighteningFactor = 1.25f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    public void ChangeColor(Colors newColor, GameObject target)
    {
        if(target == null)
            return;

        //Debug.Log("Cor: " + target.name + newColor);

        target.GetComponent<Form>().saveColor(newColor);
        
        
        if (newColor == Colors.Yellow)
        {
            target.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (newColor == Colors.Orange)
        {
            target.GetComponent<Renderer>().material.color = new Color(1, 0.37f, 0.1f, 1);
        }
        else if (newColor == Colors.Red)
        {
            target.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (newColor == Colors.Pink)
        {
            target.GetComponent<Renderer>().material.color = new Color(0.9f, 0, 0.9f, 1);
        }
        else if (newColor == Colors.Grey)
        {
            target.GetComponent<Renderer>().material.color = Color.gray;
        }
        else if (newColor == Colors.White)
        {
            target.GetComponent<Renderer>().material.color = Color.white;
        }

        target.GetComponent<Renderer>().material.SetFloat("_Brightness", 0.8f);

        if (target.GetComponent<Form>().isSelected)
        {
            DarkerColor(target);
        }

    }

    public void ResetColor(GameObject target)
    {
        target.GetComponent<Renderer>().material.color = target.GetComponent<Renderer>().material.color;
    }
    public void DarkerColor(GameObject target)
    {
        //target.GetComponent<Renderer>().material.brightness = 0.7;
        target.GetComponent<Renderer>().material.SetFloat("_Brightness",
            target.GetComponent<Renderer>().material.GetFloat("_Brightness") * darkeninFactor);
    }

    public void LigtherColor(GameObject target)
    {
        target.GetComponent<Renderer>().material.SetFloat("_Brightness",
            target.GetComponent<Renderer>().material.GetFloat("_Brightness") * lighteningFactor);
    }
}

