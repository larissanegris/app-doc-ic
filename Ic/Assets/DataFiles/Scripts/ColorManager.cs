using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private GameManager gameManager;

    private float darkeninFactor = 0.8f;
    private float lighteningFactor = 1.25f;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    public void ChangeColor(Colors newColor, GameObject target)
    {
        if (target == null)
            return;

        if (target.GetComponent<Form>().GetFormType() == FormType.Cube)
        {
            if (newColor == 0)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.7960784f, 0.003921569f, 0.372549f);
            }
            else if (newColor == 1)
            {
                target.GetComponent<Renderer>().material.color = new Color(1f, 0.9098039f, 0.1176471f);
            }
            else if (newColor == 2)
            {
                target.GetComponent<Renderer>().material.color = new Color(1f, 0.3335596f, 0f);
            }
            else if (newColor == 3)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.7960784f, 0f, 0f);
            }
            else if (newColor == -1)
            {
                target.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            }
        }
        if (target.GetComponent<Form>().GetFormType() == FormType.Sphere)
        {
            if (newColor == 0)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.4745098039f, 0.7882352941f, 0.6196078431f);
            }
            else if (newColor == 1)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.3411764706f, 0.7215686275f, 1f);
            }
            else if (newColor == 2)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.5411764706f, 0.3098039216f, 1f);
            }
            else if (newColor == 3)
            {
                target.GetComponent<Renderer>().material.color = new Color(0.3450980392f, 0.2941176471f, 0.3254901961f);
            }
            else if (newColor == -1)
            {
                target.GetComponent<Renderer>().material.color = new Color(1, 1, 1);
            }
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

