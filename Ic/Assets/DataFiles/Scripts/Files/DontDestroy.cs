using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static bool LoadFromSave;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void setLoadFromSave(bool b)
    {
        LoadFromSave = b;
    }

}
