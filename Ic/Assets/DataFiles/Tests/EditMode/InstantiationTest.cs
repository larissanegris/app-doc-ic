
using NUnit.Framework;
using UnityEngine;

public class InstantiationTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void InstantiationCube()
    {
        // Use the Assert class to test conditions
        Assert.AreEqual(expected: new Vector3(x: 0, y: 0, z: 0), actual: new Vector3(x: 0, y: 0, z: 0));
    }
}
