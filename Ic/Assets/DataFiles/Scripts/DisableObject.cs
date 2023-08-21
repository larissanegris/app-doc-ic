using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObject : MonoBehaviour
{
    //variáveis da seção de parametros de projeto
    public GameObject DPSDetailbtn;
    public GameObject Previouspagedpsbtn;
    public GameObject Nextpagedpsbtn;

    public GameObject Group1to5;
    public GameObject Group6to10;
    public GameObject Group11to15;
    public GameObject Group16to20;
    public GameObject Group21to25;
    public GameObject Group26to29;

    //variáveis da seção de categorias parametros de projeto
    public GameObject DPSCatdefbtn;
    public GameObject Category1;
    public GameObject Category2;
    public GameObject Category3;
    public GameObject Category4;
    public GameObject Category5;
    public GameObject GroupCategoriesbtn;

    //variáveis da seção de elementos básicos
    public GameObject BESDetailbtn;
    public GameObject BESReprs;

    //variáveis da seção de categorias de elementos básicos
    public GameObject BESCatdefbtn;
    public GameObject BESReprscat;


    public void WhenButtonClicked() //pode nomear como quiser
    {
        //Desativa elementos da seção de parametros de projeto
        if (DPSDetailbtn.activeInHierarchy == true)
            DPSDetailbtn.SetActive(false);
        if (Previouspagedpsbtn.activeInHierarchy == true)
            Previouspagedpsbtn.SetActive(false);
        if (Nextpagedpsbtn.activeInHierarchy == true)
            Nextpagedpsbtn.SetActive(false);
        if (Group1to5.activeInHierarchy == true)
            Group1to5.SetActive(false);
        if (Group6to10.activeInHierarchy == true)
            Group6to10.SetActive(false);
        if (Group11to15.activeInHierarchy == true)
            Group11to15.SetActive(false);
        if (Group16to20.activeInHierarchy == true)
            Group16to20.SetActive(false);
        if (Group21to25.activeInHierarchy == true)
            Group21to25.SetActive(false);
        if (Group26to29.activeInHierarchy == true)
            Group26to29.SetActive(false);

        //Desativa elementos da seção de categorias de parametros de projeto
        if (DPSCatdefbtn.activeInHierarchy == true)
            DPSCatdefbtn.SetActive(false);
        if (Category1.activeInHierarchy == true)
            Category1.SetActive(false);
        if (Category2.activeInHierarchy == true)
            Category2.SetActive(false);
        if (Category3.activeInHierarchy == true)
            Category3.SetActive(false);
        if (Category4.activeInHierarchy == true)
            Category4.SetActive(false);
        if (Category5.activeInHierarchy == true)
            Category5.SetActive(false);
        if (GroupCategoriesbtn.activeInHierarchy == true)
            GroupCategoriesbtn.SetActive(false);

        //Desativa elementos da seção de elementos básicos
        if (BESDetailbtn.activeInHierarchy == true)
            BESDetailbtn.SetActive(false);
        if (BESReprs.activeInHierarchy == true)
            BESReprs.SetActive(false);

        //Desativa elementos da seção de categorias de elementos básicos
        if (BESCatdefbtn.activeInHierarchy == true)
            BESCatdefbtn.SetActive(false);
        if (BESReprscat.activeInHierarchy == true)
            BESReprscat.SetActive(false);
    }
}