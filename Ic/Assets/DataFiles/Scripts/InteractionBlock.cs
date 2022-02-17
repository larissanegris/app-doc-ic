using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractionBlock : MonoBehaviour
{
    public List<Form> interactionList = new List<Form>();
    public int listSize = 0;
    public GameObject floor;
    public GameObject block;
    public GameObject interactionBlockPrefab;

    private void Awake()
    {
        block = gameObject;
        floor = GameObject.Find("Floor");
        interactionBlockPrefab = (GameObject) AssetDatabase.LoadAssetAtPath("Assets/DataFiles/Prefabs/InteractionBlock.prefab", typeof(GameObject));
    }

    public void AddInteraction(Form newInteraction)
    {
        interactionList.Add(newInteraction);
        listSize++;
    }

    public void RemoveInteraction(Form interaction)
    {
        interactionList.Remove(interaction);
        listSize--;
    }

    public void ClearInteractionList()
    {
        interactionList.Clear();
        listSize = 0;
    }

    //retorna true se estao
    public bool IsInTheSameBlock(GameObject gm, GameObject gm2)
    {
        Form form = gm.GetComponent<Form>();
        return form.interactions.Contains(gm2.GetComponent<Form>());
    }

    public void CombineInteractionBlock(GameObject gm1, GameObject adition)
    {
        //pega pais
        GameObject interactionBlock = gm1.transform.parent.transform.gameObject;
        
        GameObject aditionBlock = adition.transform.parent.transform.gameObject;
        Debug.Log("baseInteraction: " + gm1.name + "\nadition: " + adition.name + "\n" + "aditionBlock: " + aditionBlock.name);

        //loop para cada elemento filho
        for(int i = 0; i < aditionBlock.GetComponent<InteractionBlock>().listSize; i++)
        {
            GameObject child = aditionBlock.GetComponent<InteractionBlock>().interactionList[i].gameObject;
            if(child != gm1)
            {
                child.transform.SetParent(interactionBlock.transform, true);
                interactionBlock.GetComponent<InteractionBlock>().AddInteraction(child.GetComponent<Form>());
            }
        }
        aditionBlock.GetComponent<InteractionBlock>().ClearInteractionList();

        GameObject.Destroy(aditionBlock);
    }

    public void RemoveFromInteractionBlock(GameObject gm1, GameObject removal)
    {
        GameObject interactionBlock = gm1.transform.parent.transform.gameObject;
        Debug.Log("baseInteraction: " + gm1.name + "\nremoval: " + removal.name);

        if (interactionBlock.transform.Find(removal.name))
        {
            GameObject newBlock = Instantiate(interactionBlockPrefab, floor.transform);
            Form form = removal.GetComponent<Form>();
            
            removal.transform.SetParent(newBlock.transform, true);

            interactionBlock.GetComponent<InteractionBlock>().RemoveInteraction(form);
            newBlock.GetComponent<InteractionBlock>().AddInteraction(removal.GetComponent<Form>());
            
            gm1.transform.parent.name = "InteractionBlock" + gm1.GetComponent<Form>().id;
            newBlock.GetComponent<InteractionBlock>().AddInteraction(form);
            newBlock.name = "InsteractionBlock" + form.id;
        }
    }
}
