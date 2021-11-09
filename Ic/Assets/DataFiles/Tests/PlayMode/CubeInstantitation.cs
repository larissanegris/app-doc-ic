using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Vuforia;

public class CubeInstantiation
{
    public GameObject imageTarget;
    [UnityTest]
    public IEnumerator InstantiationCube()
    {/*
        var gameObject = new GameObject();
        var instantiator = gameObject.AddComponent<PrefabInstantiator>();

        var cubeGenerated = instantiator.SpawnCube();
        var cubePrefab = instantiator.cubePrefab;
        */
        yield return null;

        //Assert.AreEqual(expected: cubePrefab, actual: cubeGenerated);
    }
    
    [UnityTest]
    public IEnumerator CubePosition()
    {/*
        var gameObject = new GameObject();
        var instantiator = gameObject.AddComponent<PrefabInstantiator>();


        var cubeGenerated = instantiator.SpawnCube();
        
        Vector3 expectedPosition = imageTarget.transform.position;
            //mObserverBehaviour.transform;
        */
        yield return null;

        //Assert.AreEqual(expected: expectedPosition, actual: cubeGenerated.transform.position);
    }
    
}
