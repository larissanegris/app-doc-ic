using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSave : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    public void SaveGame()
    {
        SaveLoad.SaveData(gameManager.number);
        SaveLoad.SaveTransform(gameManager.createdForms.ToArray());
    }

    public void LoadGame()
    {
        Form[] forms = SaveLoad.LoadTransform();
        Debug.Log(forms);
        foreach(Form f in forms)
        {
            Debug.Log(f.gameObject.name);
        }
    }
}
