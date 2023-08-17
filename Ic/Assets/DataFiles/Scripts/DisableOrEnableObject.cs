using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOrEnableObject : MonoBehaviour
{
    public GameObject DPSbtn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void whenButtonClicked()
    {
        if (DPSbtn.activeInHierarchy == false)
            DPSbtn.SetActive(true);
        else
            DPSbtn.SetActive(false);
    }
}
