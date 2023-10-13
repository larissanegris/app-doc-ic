using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableOrEnableObject : MonoBehaviour
{
    /*//variáveis da seção de parametros de projeto
    public GameObject DPSDetailbtn;
    public GameObject Group1to5;
    public GameObject Previouspagedpsbtn;
    public GameObject Nextpagedpsbtn;

    //variáveis da seção de categorias parametros de projeto
    public GameObject DPSCatdefbtn;
    public GameObject Category1;
    public GameObject Category2;
    public GameObject Category3;
    public GameObject Category4;
    public GameObject Category5;
    public GameObject GroupCategoriesbtn;
    public GameObject Cat1btn;
    public GameObject Cat2btn;
    public GameObject Cat3btn;
    public GameObject Cat4btn;
    public GameObject Cat5btn;

    //variáveis da seção de elementos básicos
    public GameObject BESDetailbtn;
    public GameObject BESReprs;

    //variáveis da seção de categorias de elementos básicos
    public GameObject BESCatDefbtn;
    public GameObject BESReprscat;*/

    //variáveis da área de trabalho
    public GameObject FundoBotoesCategoria;
    public GameObject TextAreas;
    public GameObject TextReuniao;
    public GameObject Btn_Areas_Abertas;
    public GameObject Btn_Areas_Fechadas;
    public GameObject Btn_Reuniao_Ativa;
    public GameObject Btn_Reuniao_Passiva;

    public void WhenMenuEBbtnCLicked()
    {
        if (FundoBotoesCategoria.activeInHierarchy == false)
            FundoBotoesCategoria.SetActive(true);
        else
            FundoBotoesCategoria.SetActive(false);

        if (TextAreas.activeInHierarchy == false)
            TextAreas.SetActive(true);
        else
            TextAreas.SetActive(false);

        if (TextReuniao.activeInHierarchy == false)
            TextReuniao.SetActive(true);
        else
            TextReuniao.SetActive(false);

        if (Btn_Areas_Abertas.activeInHierarchy == true)
            Btn_Areas_Abertas.SetActive(false);

        if (Btn_Areas_Fechadas.activeInHierarchy == true)
            Btn_Areas_Fechadas.SetActive(false);

        if (Btn_Reuniao_Ativa.activeInHierarchy == true)
            Btn_Reuniao_Ativa.SetActive(false);

        if (Btn_Reuniao_Passiva.activeInHierarchy == true)
            Btn_Reuniao_Passiva.SetActive(false);
    }

    public void WhenAreasbtnCLicked()
    {
        if (Btn_Areas_Abertas.activeInHierarchy == false)
            Btn_Areas_Abertas.SetActive(true);
        else
            Btn_Areas_Abertas.SetActive(false);

        if (Btn_Areas_Fechadas.activeInHierarchy == false)
            Btn_Areas_Fechadas.SetActive(true);
        else
            Btn_Areas_Fechadas.SetActive(false);
    }

    public void WhenReuniaobtnCLicked()
    {
        if (Btn_Reuniao_Ativa.activeInHierarchy == false)
            Btn_Reuniao_Ativa.SetActive(true);
        else
            Btn_Reuniao_Ativa.SetActive(false);

        if (Btn_Reuniao_Passiva.activeInHierarchy == false)
            Btn_Reuniao_Passiva.SetActive(true);
        else
            Btn_Reuniao_Passiva.SetActive(false);
    }

    // Seção parametros de projeto
    /*public void WhenDPSbtnClicked() //pode nomear como quiser
    {
        if (DPSDetailbtn.activeInHierarchy == false)
            DPSDetailbtn.SetActive(true);
        else
            DPSDetailbtn.SetActive(false);
    }

    public void WhenDPSDetailbtnClicked()
    {
        if (Group1to5.activeInHierarchy == false)
            Group1to5.SetActive(true);
        else
            Group1to5.SetActive(false);

        if (Nextpagedpsbtn.activeInHierarchy == false)
            Nextpagedpsbtn.SetActive(true);
        else
            Nextpagedpsbtn.SetActive(false);
    }

    // Seção categoria de parametros de projeto
    public void WhenDPSCatbtnClicked()
    {
        if (DPSCatdefbtn.activeInHierarchy == false)
            DPSCatdefbtn.SetActive(true);
        else
            DPSCatdefbtn.SetActive(false);
    }

    public void WhenDPSCatdefbtnClicked()
    {
        if (Category1.activeInHierarchy == false)
            Category1.SetActive(true);
        else
            Category1.SetActive(false);

        if (GroupCategoriesbtn.activeInHierarchy == false)
            GroupCategoriesbtn.SetActive(true);
        else
            GroupCategoriesbtn.SetActive(false);
    }

    public void WhenCat1btnClicked()
    {
        if (Category1.activeInHierarchy == false)
            Category1.SetActive(true);

        if (Category2.activeInHierarchy == true)
            Category2.SetActive(false);
        if (Category3.activeInHierarchy == true)
            Category3.SetActive(false);
        if (Category4.activeInHierarchy == true)
            Category4.SetActive(false);
        if (Category5.activeInHierarchy == true)
            Category5.SetActive(false);
    }

    public void WhenCat2btnClicked()
    {
        if (Category2.activeInHierarchy == false)
            Category2.SetActive(true);

        if (Category1.activeInHierarchy == true)
            Category1.SetActive(false);
        if (Category3.activeInHierarchy == true)
            Category3.SetActive(false);
        if (Category4.activeInHierarchy == true)
            Category4.SetActive(false);
        if (Category5.activeInHierarchy == true)
            Category5.SetActive(false);
    }

    public void WhenCat3btnClicked()
    {
        if (Category3.activeInHierarchy == false)
            Category3.SetActive(true);

        if (Category1.activeInHierarchy == true)
            Category1.SetActive(false);
        if (Category2.activeInHierarchy == true)
            Category2.SetActive(false);
        if (Category4.activeInHierarchy == true)
            Category4.SetActive(false);
        if (Category5.activeInHierarchy == true)
            Category5.SetActive(false);
    }

    public void WhenCat4btnClicked()
    {
        if (Category4.activeInHierarchy == false)
            Category4.SetActive(true);

        if (Category1.activeInHierarchy == true)
            Category1.SetActive(false);
        if (Category2.activeInHierarchy == true)
            Category2.SetActive(false);
        if (Category3.activeInHierarchy == true)
            Category3.SetActive(false);
        if (Category5.activeInHierarchy == true)
            Category5.SetActive(false);
    }

    public void WhenCat5btnClicked()
    {
        if (Category5.activeInHierarchy == false)
            Category5.SetActive(true);

        if (Category1.activeInHierarchy == true)
            Category1.SetActive(false);
        if (Category2.activeInHierarchy == true)
            Category2.SetActive(false);
        if (Category3.activeInHierarchy == true)
            Category3.SetActive(false);
        if (Category4.activeInHierarchy == true)
            Category4.SetActive(false);
    }*/

    /*// Seção elementos básicos
    public void WhenBEsbtnClicked()
    {
        if (BESDetailbtn.activeInHierarchy == false)
            BESDetailbtn.SetActive(true);
      //  else
        //    BESDetailbtn.SetActive(false);
    }

    public void WhenBEsdetailbtnClicked()
    {
        if (BESReprs.activeInHierarchy == false)
            BESReprs.SetActive(true);
       // else
          //  BESReprs.SetActive(false);
    }

    // Seção categoria elementos básicos
    public void WhenBEsCatbtnClicked()
    {
        if (BESCatDefbtn.activeInHierarchy == false)
            BESCatDefbtn.SetActive(true);
      //  else
        //    BESCatbtn.SetActive(false);
    }

    public void WhenBEsCatdefbtnClicked()
    {
        if (BESReprscat.activeInHierarchy == false)
            BESReprscat.SetActive(true);
      //  else
         //   BESReprscat.SetActive(false);
    }*/



}
