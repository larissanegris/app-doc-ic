using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ColorManager : MonoBehaviour
{
    private GameManager gameManager;

    private float darkeninFactor = 0.8f;
    private float lighteningFactor = 1.25f;

    readonly Color White = new Color(1, 1, 1);
    readonly Color Pink = new Color(0.7960784f, 0.003921569f, 0.372549f);
    readonly Color Yellow = new Color(1f, 0.9098039f, 0.1176471f);
    readonly Color Orange = new Color(1f, 0.3335596f, 0f);
    readonly Color Red = new Color(0.7960784f, 0f, 0f);
    readonly Color Blue = new Color(0.4745098039f, 0.7882352941f, 0.6196078431f);
    readonly Color Green = new Color(0.3411764706f, 0.7215686275f, 1f);
    readonly Color Purple = new Color(0.5411764706f, 0.3098039216f, 1f);
    readonly Color Grey = new Color(0.3450980392f, 0.2941176471f, 0.3254901961f);
    List<Color> cubeColors;
    List<Color> sphereColors;


    void Start()
    {
        cubeColors = new List<Color> { Pink, Yellow, Orange, Red };
        sphereColors = new List<Color> { Blue, Green, Purple, Grey };
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    public void ChangeColor(int newColor, GameObject target)
    {
        if(target == null)
            return;



        if( target.GetComponent<Form>().GetFormType() == FormType.Cube )
        {
            if ( newColor == 0 )
            {
                target.GetComponent<Renderer>().material.color = Pink;
            }
            else if ( newColor == 1 )
            {
                target.GetComponent<Renderer>().material.color = Yellow;
            }
            else if ( newColor == 2 )
            {
                target.GetComponent<Renderer>().material.color = Orange;
            }
            else if ( newColor == 3 )
            {
                target.GetComponent<Renderer>().material.color = Red;
            }
            else if ( newColor == -1 )
            {
                target.GetComponent<Renderer>().material.color = White;
            }
            target.GetComponent<Form>().pp = (PP) newColor;
        }
        if ( target.GetComponent<Form>().GetFormType() == FormType.Sphere )
        {
            if ( newColor == 0 )
            {
                target.GetComponent<Renderer>().material.color = Blue;
            }
            else if ( newColor == 1 )
            {
                target.GetComponent<Renderer>().material.color = Green;
            }
            else if ( newColor == 2 )
            {
                target.GetComponent<Renderer>().material.color = Purple;
            }
            else if ( newColor == 3 )
            {
                target.GetComponent<Renderer>().material.color = Grey;
            }
            else if ( newColor == -1 )
            {
                target.GetComponent<Renderer>().material.color = White;
            }
            target.GetComponent<Form>().pp = (PP) newColor + 4;
        }


    }

    public void BtnColorCube(List<Button> btns)
    {
        for(int i = 0; i < 4; i++)
        {
            btns[i].GetComponent<Image>().color = cubeColors[i];
        }
    }

    public void BtnColorSphere(List<Button> btns)
    {
        for (int i = 0; i < 4; i++)
        {
            btns[i].GetComponent<Image>().color = sphereColors[i];
        }
    }

    public void BtnColorDisable(List<Button> btns)
    {
        for (int i = 0; i < 4; i++)
        {
            btns[i].GetComponent<Image>().color = White;
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

