using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";

    public GameManager gameManager;
    private Transform _selection;
    public Form form;
    public ColorManager colorManager;

    [SerializeField] private int layerMask = 1 << 6;

    public event Action<GameObject> selectionChange;

    private void Start()
    {
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
        colorManager = gameManager.colorManager;
    }

    private void Update()
    {
        if ( _selection != null )
        {
            _selection = null;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            if ( Physics.Raycast( ray, out hit, layerMask ) )
            {
                var selection = hit.transform;
                if ( selection.CompareTag( selectableTag ) )
                {

                    if ( selection.gameObject != gameManager.GetSelectedObject() )
                    {
                        if( selectionChange != null )
                        {
                            selectionChange( selection.gameObject );
                        }
                        //gameManager.ChangeSelectedObject( selection.gameObject );
                    }

                    _selection = selection;

                }
            }
        }
    }

    public void ChangeSelectedObject(GameObject gm )
    {
        gameManager.ChangeSelectedObject( gm );
        selectionChange?.Invoke( gm );
    }
}
