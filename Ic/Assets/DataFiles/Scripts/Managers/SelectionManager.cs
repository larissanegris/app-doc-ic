using System;
using UnityEngine;

interface selectionManager
{
    event Action<GameObject> selectionChange;
}

public class SelectionManager : MonoBehaviour, selectionManager 
{
    protected GameManager gameManager;
    protected Transform _selection;

    protected string selectableTag = "Selectable";
    protected int layerMask = 1 << 6;

    public event Action<GameObject> selectionChange;

    protected void Start()
    {
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
    }

    public void RaycastSelection()
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

    public void ChangeSelectedObject( GameObject gm )
    {
        selectionChange?.Invoke( gm );
    }
}
