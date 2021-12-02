using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{

    public int id;
    public Type tipo;
    public Colors cor = Colors.White;
    public Colors previousCor = Colors.White;
    public bool isSelected = false;

    public GameManager gameManager;

    public List<Form> interactions = new List<Form>();

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
}
