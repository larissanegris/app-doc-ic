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


    [SerializeField] private List<Form> interactions = new List<Form>();
    [SerializeField] private List<float> distances = new List<float>();

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
        highlightManager = gameManager.highlightManager;
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

    public void SetToSelected()
    {
        isSelected = true;
    }
    public void SetToUnselected()
    {
        isSelected = false;
    }

    public void AddInteraction(Form interaction)
    {
        foreach(GameObject gm in interaction.transform.parent.GetComponent<InteractionBlock>().interactionList)
        {
            Form form = gm.GetComponent<Form>();
            if (!this.interactions.Contains(form) && form != this)
            {
                interactions.Add(form);
                if (!form.interactions.Contains(this) && form.gameObject != interaction)
                {
                    form.interactions.Add(this);
                    form.SetIsInBlock(true);
                }
                
                //form.AddSingleInteraction(this);
                
            }
            //form.AddSingleInteraction(this);
        }

        isInBlock = true;
        
        if(interactions.Count > 0)
        {
            colorManager.LigtherColor(this.gameObject);
        }
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
}
