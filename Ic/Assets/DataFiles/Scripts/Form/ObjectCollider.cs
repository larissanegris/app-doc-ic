using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollider : MonoBehaviour
{
    public Form form;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); ;
        form = GetComponent<Form>();
    }

    void OnTriggerEnter(Collider other)
    {
        form = gameObject.GetComponent<Form>();
        if (!gameObject.GetComponent<Form>().interactions.Contains(other.GetComponent<Form>()))
        {
            if (gameObject.tag == "Selected")
            {
                Debug.Log("ENTRANDO COLISAO\nSelected: " + name);
                gameObject.transform.parent.GetComponent<InteractionBlock>().CombineInteractionBlock(gameObject, other.gameObject);
            }
            form.AddInteraction(other.gameObject);
        }
        
    }
    
    private void OnTriggerExit(Collider other)
    {      
        form = gameObject.GetComponent<Form>();
        if (gameObject.GetComponent<Form>().interactions.Contains(other.GetComponent<Form>()))
        {
            if (gameObject.tag == "Selected")
            {
                Debug.Log("SAINDO COLISAO\nSelected Remove: " + name);
                gameObject.transform.parent.GetComponent<InteractionBlock>().RemoveFromInteractionBlock(gameObject, other.gameObject);
            }
            form.RemoveInteraction(other.GetComponent<Form>());
        }

        
    }
    
}
