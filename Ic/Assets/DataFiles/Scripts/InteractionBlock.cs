using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractionBlock : MonoBehaviour
{
    public List<GameObject> interactionList = new List<GameObject>();
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


    public void AddInteraction(GameObject newInteraction)
    {
        interactionList.Add(newInteraction);
        listSize++;
    }

    public void RemoveInteraction(GameObject interaction)
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
        return form.InteractionsContains(gm2.GetComponent<Form>());
    }

    public void CombineInteractionBlock(GameObject gm1, GameObject adition)
    {        
        //pega pais
        GameObject interactionBlock = gm1.transform.parent.transform.gameObject;
        
        GameObject aditionBlock = adition.transform.parent.transform.gameObject;
        Debug.Log("<color=magenta>baseInteraction: " + interactionBlock.name + "\n" + "aditionBlock: " + aditionBlock.name + "</color>");

        interactionBlock.GetComponent<InteractionBlock>().ClearInteractionList();
        interactionBlock.GetComponent<InteractionBlock>().AddInteraction(gm1);
        //loop para cada elemento filho
        foreach (GameObject child in aditionBlock.GetComponent<InteractionBlock>().interactionList)
        {
            Debug.Log("<color=yellow>Child: " + child.name + "</color>");
            child.transform.SetParent(interactionBlock.transform);
            interactionBlock.GetComponent<InteractionBlock>().AddInteraction(child.gameObject);
        }

        GameObject.Destroy(aditionBlock);

        gm1.GetComponent<Form>().AddInteraction(adition.GetComponent<Form>());
        
    }

    public void RemoveFromInteractionBlock(GameObject gm1, GameObject removal)
    {
        GameObject interactionBlock = gm1.transform.parent.transform.gameObject;
        Debug.Log("<color=blue>baseInteraction: " + gm1.name + "\nremoval: " + removal.name + "</color>");
        
        if (interactionBlock.transform.Find(removal.name))
        {
            //criar pai
            GameObject newBlock = Instantiate(interactionBlockPrefab, floor.transform);
            Form form = removal.GetComponent<Form>();
            
            removal.transform.SetParent(newBlock.transform, true);

            //atualizar interacoes
            interactionBlock.GetComponent<InteractionBlock>().RemoveInteraction(removal);
            newBlock.GetComponent<InteractionBlock>().AddInteraction(removal);
            
            //mudar nomes
            interactionBlock.name = "InteractionBlock" + gm1.GetComponent<Form>().GetId();
            newBlock.name = "InsteractionBlock" + form.GetId();

            form.RemoveInteraction(gm1.GetComponent<Form>());
            gm1.GetComponent<Form>().RemoveInteraction(form);
        }
        
    }

}
