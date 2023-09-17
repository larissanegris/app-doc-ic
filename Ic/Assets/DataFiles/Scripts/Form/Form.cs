using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Newtonsoft.Json;

[System.Serializable]
[JsonObject(MemberSerialization.OptIn)]
public class Form : MonoBehaviour
{
    private GameManager gameManager;
    private TouchSelectionManager touchSelectionManager;

    [SerializeField] [JsonProperty] public int id;
    [SerializeField] [JsonProperty] private FormType type;
    [SerializeField] [JsonProperty] public bool transparent;
    [SerializeField] [JsonProperty] public int cor;
    [SerializeField] [JsonProperty] public PP pp;
    
    [SerializeField] private bool isSelected = false;

    [SerializeField] [JsonProperty] private Vector3 pos;
    [SerializeField] [JsonProperty] private Quaternion rot;
    [SerializeField] [JsonProperty] private Vector3 scale;

    private Outline outline;
    public Vector3 halfBoxVolume;

    public GameObject volume;


    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        touchSelectionManager = FindObjectOfType<TouchSelectionManager>();
        outline = gameObject.GetComponent<Outline>();
        touchSelectionManager.selectionChangeMultiple += ChangeSelectedObject;
        gameManager.VolumeToggle += DisplayVolume;
    }


    public void CreateForm(int id, FormType type )
    {
        this.id = id;
        this.type = type;
        this.cor = -1;
        this.transparent = (GetComponent<MeshRenderer>().material.name == "TransparentCube (Instance)" 
            || GetComponent<MeshRenderer>().material.name == "TransparentSphere (Instance)");
    }

    public void CreateForm(int id, FormType type, int c)
    {
        this.id = id;
        this.type = type;
        this.cor = c;
        this.transparent = (GetComponent<MeshRenderer>().material.name == "TransparentCube (Instance)"
            || GetComponent<MeshRenderer>().material.name == "TransparentSphere (Instance)");
    }

    public void DisplayVolume(bool b)
    {
        volume.SetActive(b);
    }

    public void ChangeSelectedObject(bool selectMultipleObjects, List<GameObject> selectedObj, GameObject target)
    {
        if (selectedObj.Contains(this.gameObject))
            isSelected = true;
        else
            isSelected = false;

        ChangeOutline();
        ChangePinchEnableStatus(selectMultipleObjects);
    }

    private void ChangePinchEnableStatus(bool selectMultipleObjects)
    {
        GetComponent<LeanPinchScale>().enabled = !selectMultipleObjects;
    }

    private void ChangeOutline()
    {
        if (isSelected)
        {
            outline.OutlineMode = Outline.Mode.OutlineVisible;
        }
        else
        {
            outline.OutlineMode = Outline.Mode.OutlineHidden;
        }
    }

    public void SetToSelected()
    {
        isSelected = true;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
    }
    public void SetToUnselected()
    {
        isSelected = false;
        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

    public int GetId()
    {
        return id;
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }

    public FormType GetFormType()
    {
        return type;
    }

    public void DeleteSelf()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void SaveForm()
    {
        if (!gameObject.activeInHierarchy)
            return;
        pos = gameObject.transform.position;
        rot = gameObject.transform.rotation;
        scale = gameObject.transform.localScale;
    }

    public void LoadForm(Form form)
    {
        id = form.id;
        type = form.type;
        pp = form.pp;
        pos = form.pos;
        rot = form.rot;
        scale = form.scale;

        gameObject.transform.position = pos;
        gameObject.transform.rotation = rot;
        gameObject.transform.localScale = scale;
        //int aux = (int)(type == FormType.Cube);
        //gameManager.colorManager.ChangeColor((int)pp%4, this.gameObject);
    }
}
