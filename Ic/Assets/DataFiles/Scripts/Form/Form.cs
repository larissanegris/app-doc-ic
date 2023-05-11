using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Form : MonoBehaviour
{
    private GameManager gameManager;
    private TouchSelectionManager touchSelectionManager;

    [SerializeField] private int id;
    [SerializeField] private FormType type;
    [SerializeField] public PP pp;
    [SerializeField] private bool isSelected = false;

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


    public void CreateForm(int id, FormType type)
    {
        this.id = id;
        this.type = type;
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
        Debug.Log(name + "unselected");
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
}
