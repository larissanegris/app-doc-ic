using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public Form form;

    void OnTriggerEnter(Collider other)
    {
        form.AddInteraction(other.GetComponent<Form>());
    }

    private void OnTriggerExit(Collider other)
    {
        form.RemoveInteraction(other.GetComponent<Form>());
    }

    void Start()
    {
        form = GetComponent<Form>();
    }
}
