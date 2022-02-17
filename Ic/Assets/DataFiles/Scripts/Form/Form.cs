using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{
    private GameManager gameManager;
    public ColorManager colorManager;
    public HighlightManager highlightManager;

    public int id;
    public Type type;
    public Colors cor = Colors.White;
    private Colors previousCor = Colors.White;
    public bool isSelected = false;
    public bool isInBlock = false;


    public List<Form> interactions = new List<Form>();

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
        highlightManager = gameManager.highlightManager;
        //Debug.Log(gameObject);
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

    public void AddInteraction(GameObject interaction)
    {
        foreach(Form form in interaction.transform.parent.GetComponent<InteractionBlock>().interactionList)
        {
            if (!this.interactions.Contains(form) && form != this)
            {
                interactions.Add(form);
                if (!form.interactions.Contains(this) && form.gameObject != interaction)
                {
                    form.interactions.Add(this);
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
        Debug.Log("Capacidade: " + interactions.Count);
        if (interactions.Count <= 0)
        {
            colorManager.DarkerColor(this.gameObject);
        }
    }

    
}
