using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabInstantiator prefabInstantiator;
    public GameObject selectedObject;

    public List<Form> createdForms = new List<Form>();

    public int number = 0;
    public int numberCube = 0;
    public int numberSphere = 0;

}
