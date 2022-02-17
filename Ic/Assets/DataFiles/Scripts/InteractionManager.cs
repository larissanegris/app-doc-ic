using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    private GameManager gameManager;
    public List<InteractionBlock> interactionArray = new List<InteractionBlock>();
    public GameObject interactionParent;
    public GameObject floor;

    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        floor = GameObject.Find("Floor");        
    }

    void Interaction(Form form1, Form form2)
    {
        if(!form1.isInBlock && !form2.isInBlock)
        {
            GameObject newParent = new GameObject("Parent");
            newParent.transform.parent = floor.transform;
        }
        else
        {
            form1.AddInteraction(form2.gameObject);
        }
    }

}
