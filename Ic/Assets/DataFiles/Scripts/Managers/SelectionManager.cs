using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private GameManager gameManager;
    private Transform _selection;

    private string selectableTag = "Selectable";
    private int layerMask = 1 << 6;

    public event Action<GameObject> selectionChange;

    private void Start()
    {
        gameManager = GameObject.Find( "GameManager" ).GetComponent<GameManager>();
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

    public void ChangeSelectedObject( GameObject gm )
    {
        selectionChange?.Invoke( gm );
    }
}
