using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    public GameManager gameManager;
    private Transform _selection;
    public Form form;
    public ColorManager colorManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
    }

    private void Update()
    {
        if (_selection != null)
        {
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                
                if(selection.gameObject != gameManager.selectedObject)
                {
                    var previousSelect = gameManager.selectedObject;

                    gameManager.ChangeSelectedObject(selection.gameObject);
                }
                
                _selection = selection;
                
            }
        }
    }
}
