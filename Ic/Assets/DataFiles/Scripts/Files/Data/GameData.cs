using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int numberCreatedObjects;
    public List<Form> createdForms;

    public GameData()
    {
        this.numberCreatedObjects = 0;
        this.createdForms = null;
    }
}
