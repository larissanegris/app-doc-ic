using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    private GameManager gameManager;
    private ColorManager colorManager;
    private HighlightManager highlightManager;

    [SerializeField] private int id;
    [SerializeField] private FormType type;
    [SerializeField] private Colors cor = Colors.White;
    [SerializeField] private Colors previousCor = Colors.White;
    [SerializeField] private bool isSelected = false;
    [SerializeField] private bool isInBlock = false;
    private Outline outline;



    [SerializeField] private List<Form> interactions = new List<Form>();
    [SerializeField] private List<float> distances = new List<float>();

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
        highlightManager = gameManager.highlightManager;
        outline = gameObject.GetComponent<Outline>();
    }

    private void OnEnable()
    {
        FindObjectOfType<SelectionManager>().selectionChange += ChangeSelectedObject;
    }

    private void OnDisable()
    {
        //FindObjectOfType<SelectionManager>().selectionChange -= ChangeSelectedObject;
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

    public void AddInteraction(Form interaction)
    {/*
        isInBlock = true;
        
        if(interactions.Count > 0)
        {
            colorManager.LigtherColor(this.gameObject);
        }
        */
    }

    public void AddSingleInteraction(Form form)
    {
        if (!this.interactions.Contains(form) && form != this)
        {
            interactions.Add(form);
        }
        //isInBlock = true;

        if (interactions.Count > 0)
        {
            colorManager.LigtherColor(this.gameObject);
        }
    }

    public void RemoveInteraction(Form interation)
    {
        if (interactions.Exists(element => element == interation))
        {
            interactions.Remove(interation);
        }
        if (interactions.Count <= 0)
        {
            colorManager.DarkerColor(this.gameObject);
        }
    }

    public bool GetIsInBlock()
    {
        return isInBlock;
    }

    public void SetIsInBlock(bool isInBlock)
    {
        this.isInBlock = isInBlock;
    }

    public int GetId()
    {
        return id;
    }

    public bool InteractionsContains(Form form)
    {
        return interactions.Contains(form);
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
