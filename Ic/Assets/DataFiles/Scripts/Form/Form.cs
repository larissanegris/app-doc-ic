using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    private GameManager gameManager;
    private ColorManager colorManager;

    [SerializeField] private int id;
    [SerializeField] private FormType type;
    [SerializeField] private Colors cor = Colors.White;
    [SerializeField] private Colors previousCor = Colors.White;
    [SerializeField] private bool isSelected = false;
    
    private Outline outline;
    public Vector3 halfBoxVolume ;



    [SerializeField] private List<Form> interactions = new List<Form>();
    [SerializeField] private List<float> distances = new List<float>();

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
        outline = gameObject.GetComponent<Outline>();
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
    }


    public void CreateForm(int id, FormType type)
    {
        this.id = id;
        this.type = type;
    }

    public void saveColor()
    {
        previousCor = cor;
    }
    public void saveColor(Colors newCor)
    {
        previousCor = cor;
        cor = newCor;
    }

    public void ChangeSelectedObject(GameObject gm)
    {
        if(gm == gameObject ) {
            isSelected = true;
            outline.OutlineMode = Outline.Mode.OutlineVisible;
        }
        else
        {
            isSelected = false;
            outline.OutlineMode = Outline.Mode.OutlineHidden;
        }
    }

    public void SetToSelected()
    {
        isSelected = true;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }
    public void SetToUnselected()
    {
        isSelected = false;
        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

    public int GetId()
    {
        return id;
    }

    public List<Form> GetInteractions()
    {
        return interactions;
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }

    public Colors GetCor()
    {
        return cor;
    }
    public FormType GetFormType()
    {
        return type;
    }

    public void DeleteSelf()
    {
        GameObject.Destroy(this.gameObject);
    }
}
