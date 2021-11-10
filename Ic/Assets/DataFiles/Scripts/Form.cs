using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Form : MonoBehaviour
{

    public int id;
    public int tipo;
    public Colors cor;
    public GameObject form;

    public List<Form> interactions = new List<Form>();

    public void SetForm(GameObject form)
    {
        this.form = form;
    }

    public void ChangeColor(Colors cor)
    {
        if (cor == Colors.Yellow)
        {
            form.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (cor == Colors.Orange)
        {
            form.GetComponent<Renderer>().material.color = new Color(1, 0.37f, 0.1f, 1);
        }
        else if (cor == Colors.Red)
        {
            form.GetComponent<Renderer>().material.color = Color.red;
        }
        else if (cor == Colors.Pink)
        {
            form.GetComponent<Renderer>().material.color = new Color(0.9f, 0, 0.9f, 1);
        }
        this.cor = cor;
    }
}
