using System;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;


public class ScaleManager : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject parent;
    public GameObject sphereControlPrefab;
    public GameObject selectedSphere;
    public GameObject auxSphere;

    public ScaleButton scaleBtn;

    private Camera camera;
    private LeanFinger finger;

    private TouchSelectionManager touchSelectionManager;

    public List<GameObject> spheres = new List<GameObject>();

    public Action UpdatePosition;

    void Start()
    {
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
        camera = Camera.main;

        touchSelectionManager.selectionChange += ChangeSelectedObject;
        touchSelectionManager.selectionSphereChange += ChangeSelectedSphere;
        touchSelectionManager.FingerDown += UpdateFinger;
        scaleBtn.ToggleControlSphere += ToggleShowScaleSphere;

        for (int i = 0; i < 6; i++)
            spheres.Add(GameObject.Instantiate(sphereControlPrefab, parent.transform));
        spheres[0].name = "x1";
        spheres[1].name = "y1";
        spheres[2].name = "z1";
        spheres[3].name = "x2";
        spheres[4].name = "y2";
        spheres[5].name = "z2";

        for (int i = 0; i < 6; i++)
            spheres[i].GetComponent<SphereControl>().StartUp();

    }

    private void Update()
    {
        UpdateObjectSize();
    }

    public void UpdateControlSpherePosition()
    {
        Vector3 pos = selectedObject.transform.position;
        Vector3 size = selectedObject.transform.lossyScale / 2;
        for (int i = 0; i < 6; i++)
        {
            float x = 0, y = 0, z = 0;
            if (i % 3 == 0)
            {
                if (i % 2 == 0)
                    x = 1;
                else
                    x = -1;
            }
            if (i % 3 == 1)
            {
                if (i % 2 == 0)
                    y = 1;
                else
                    y = -1;
            }
            if (i % 3 == 2)
            {
                if (i % 2 == 0)
                    z = 1;
                else
                    z = -1;
            }
            spheres[i].transform.position = (pos + selectedObject.transform.rotation * new Vector3(x * size.x, y * size.y, z * size.z));
        }
    }

    void UpdateObjectSize()
    {
        if (selectedObject != null && selectedSphere != null)
        {
            Vector3 pos = selectedObject.transform.position;
            Vector3 scale = selectedObject.transform.localScale;
            Vector3 selSphePos = (pos - selectedSphere.transform.position) * 2;
            Vector3 point = finger.GetWorldPosition(Vector3.Distance(selectedSphere.transform.position, camera.transform.position), camera);
            Debug.DrawRay(camera.transform.position, point, Color.red, 0.1f);
            Debug.Log("ScaleManager - Update Object Size");

            if (selectedSphere.name[0] == 'x')
                selectedObject.transform.localScale = new Vector3(selSphePos.x, scale.y, scale.z);
            if (selectedSphere.name[0] == 'y')
                selectedObject.transform.localScale = new Vector3(scale.x, selSphePos.y, scale.z);
            if (selectedSphere.name[0] == 'z')
                selectedObject.transform.localScale = new Vector3(scale.x, scale.y, selSphePos.x);
        }

    }

    void ToggleShowScaleSphere(bool b)
    {
        foreach (GameObject sphere in spheres)
        {
            sphere.SetActive(b);
        }
    }

    // Update is called once per frame
    void ChangeSelectedObject(GameObject go)
    {
        selectedObject = go;
    }

    void ChangeSelectedSphere(GameObject go)
    {
        selectedSphere = go;
    }

    void UpdateFinger(LeanFinger f)
    {
        finger = f;
    }

}
