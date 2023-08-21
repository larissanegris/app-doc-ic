using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PrevNext : MonoBehaviour
{

    public List<GameObject> groups;
    public GameObject Nextbtn;
    public GameObject Prevbtn;

    public GameObject Group1to5;
    public GameObject Group6to10;
    public GameObject Group11to15;
    public GameObject Group16to20;
    public GameObject Group21to25;
    public GameObject Group26to29;


    public int index = 0;
    public int index_atual = 0;


    // Start is called before the first frame update
    void Start()
    {
        groups.Add(Group1to5);
        groups.Add(Group6to10);
        groups.Add(Group11to15);
        groups.Add(Group16to20);
        groups.Add(Group21to25);
        groups.Add(Group26to29);

       
    }

    public void WhenNextClicked()
    {
        /*if (index_atual >= 0 && index_atual < 6 )
        {
            index = index_atual + 1;
            groups[index_atual].SetActive(false);
            groups[index].SetActive(true);
            index_atual = index;
        }*/
            

        if (groups[0].activeInHierarchy == true)
        {
            groups[0].SetActive(false);
            groups[1].SetActive(true);
            Prevbtn.SetActive(true);
        }

        else if (groups[1].activeInHierarchy == true)
        {
            groups[1].SetActive(false);
            groups[2].SetActive(true);
            Prevbtn.SetActive(true);
        }

        else if (groups[2].activeInHierarchy == true)
        {
            groups[2].SetActive(false);
            groups[3].SetActive(true);
            Prevbtn.SetActive(true);
        }

        else if (groups[3].activeInHierarchy == true)
        {
            groups[3].SetActive(false);
            groups[4].SetActive(true);
            Prevbtn.SetActive(true);
        }

        else if (groups[4].activeInHierarchy == true)
        {
            groups[4].SetActive(false);
            groups[5].SetActive(true);
            Prevbtn.SetActive(true);
            Nextbtn.SetActive(false);
        }
    }

    public void WhenPrevClicked()
    {
        /*if (index_atual > 0)
        {
            index = index_atual - 1;
            groups[index_atual].SetActive(false);
            groups[index].SetActive(true);
            index_atual = index;
        }*/
        

        if (groups[5].activeInHierarchy == true)
        {
            groups[5].SetActive(false);
            groups[4].SetActive(true);
            Nextbtn.SetActive(true);
        }

        else if (groups[4].activeInHierarchy == true)
        {
            groups[4].SetActive(false);
            groups[3].SetActive(true);
        }

        else if (groups[3].activeInHierarchy == true)
        {
            groups[3].SetActive(false);
            groups[2].SetActive(true);
        }

        else if (groups[2].activeInHierarchy == true)
        {
            groups[2].SetActive(false);
            groups[1].SetActive(true);
        }

        else if (groups[1].activeInHierarchy == true)
        {
            groups[1].SetActive(false);
            groups[0].SetActive(true);
            Prevbtn.SetActive(false);
        }
    }
}
   

