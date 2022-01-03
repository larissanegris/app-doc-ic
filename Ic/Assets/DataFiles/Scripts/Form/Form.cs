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


    public List<Form> interactions = new List<Form>();

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
        highlightManager = gameManager.highlightManager;
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

    public void AddInteraction(Form interation)
    {
        if (!interactions.Exists(element => element == interation))
        {
            interactions.Add(interation);
        }
        if(interactions.Count > 0)
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
