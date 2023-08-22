using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnDisable : MonoBehaviour
{
    public List<GameObject> disable;

    public void Disable()
    {
        foreach (GameObject i in disable)
            i.SetActive(false);
    }

    private void OnDisable()
    {
        Disable();
    }
}
