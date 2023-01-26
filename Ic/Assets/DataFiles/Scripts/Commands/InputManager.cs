using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject target;
    private int interactionType;
    private bool _blockInteraction;
    private ColorManager colorManager;
    private MoveCamera moveCamera;
    
    private Move move;
    private Rotate rotate;
    private ScaleObject scale;

    public event Func<GameObject> Move;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        colorManager = gameManager.GetComponent<ColorManager>();
        moveCamera = gameManager.cameraObject.GetComponent<MoveCamera>();
        move = gameManager.GetComponent<Move>();
        rotate = gameManager.GetComponent<Rotate>();
        scale = gameManager.GetComponent<ScaleObject>();
    }

    // Update is called once per frame
    void Update()
    {

        interactionType = gameManager.interactionType;
        //Criar cubo opaco
        if ( Input.GetKeyDown( KeyCode.Q ) && !Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.instantiationManager.Spawn( FormType.Cube, false );
        }
        //cria cubo transparente
        if ( Input.GetKeyDown( KeyCode.Q ) && Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.instantiationManager.Spawn( FormType.Cube, true );
        }
        //criar esfera opaca
        if ( Input.GetKeyDown( KeyCode.E ) && !Input.GetKey( KeyCode.LeftShift ))
        {
            gameManager.instantiationManager.Spawn( FormType.Sphere, false );
        }
        //cria esfera transparente
        if ( Input.GetKeyDown( KeyCode.E ) && Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.instantiationManager.Spawn( FormType.Sphere, true );
        }

        //Altera modo volume
        if ( Input.GetKeyDown( KeyCode.T ) )
        {
            gameManager.VolumeToggleEvent();
        }



        //teclas para selecionar os objetos
        //Mover
        if ( Input.GetKeyDown( KeyCode.Alpha0 ) )
        {
            gameManager.ChangeinteractionType( 0 );
        }
        //Rotacionar
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            gameManager.ChangeinteractionType( 1 );
        }
        //escalar
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            gameManager.ChangeinteractionType( 2 );
        }
        if ( Input.GetKeyDown( KeyCode.Alpha3 ) )
        {
            gameManager.ChangeinteractionType(3);
        }

        //Movimentacao
        /*
        if ( !gameManager.moveCamera )
        {
            if ( gameManager.GetSelectedObject() )
            {

                target = gameManager.GetSelectedObject();
                Form form = target.GetComponent<Form>();

                if ( interactionType == 1 )
                {
                    if ( ( Input.GetKeyDown( KeyCode.W ) || Input.GetKeyDown( KeyCode.UpArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
                    {
                        rotate.RotateUp();
                    }
                    if ( ( Input.GetKeyDown( KeyCode.S ) || Input.GetKeyDown( KeyCode.DownArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
                    {
                        rotate.RotateDown();
                    }
                    if ( ( Input.GetKeyDown( KeyCode.A ) || Input.GetKeyDown( KeyCode.LeftArrow ) ) )
                    {
                        rotate.RotateLeft();
                    }
                    if ( ( Input.GetKeyDown( KeyCode.D ) || Input.GetKeyDown( KeyCode.RightArrow ) ) )
                    {
                        rotate.RotateRight();
                    }
                    if ( ( Input.GetKeyDown( KeyCode.W ) || Input.GetKeyDown( KeyCode.UpArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
                    {
                        rotate.RotateForward();
                    }
                    if ( ( Input.GetKeyDown( KeyCode.S ) || Input.GetKeyDown( KeyCode.DownArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
                    {
                        rotate.RotateBackward();
                    }

                }
                
                else if ( ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move UP");
                        move.MoveUp();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale UP");
                        scale.ScaleUp();
                    }

                }
                if ( ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move Down");
                        move.MoveDown();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale Down");
                        scale.ScaleDown();
                    }
                }
                if ( Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move Right");
                        move.MoveRight();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale Right");
                        scale.ScaleRight();
                    }
                }
                if ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move Left");
                        move.MoveLeft();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale Left");
                        scale.ScaleLeft();
                    }
                }
                if ( ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move Forward");
                        move.MoveForward();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale Forward");
                        scale.ScaleForward();
                    }
                }
                if ( ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
                {
                    if ( interactionType == 0 )
                    {
                        //Debug.Log("Move Backward");
                        move.MoveBackward();
                    }
                    else if ( interactionType == 2 )
                    {
                        //Debug.Log("Scale Backward");
                        scale.ScaleBackward();
                    }
                }
                
                if ( !_blockInteraction )
                {
                    //Mudar Cor
                    if ( Input.GetKeyDown( KeyCode.H ) )
                    {
                        //Debug.Log("W: Mudando Cor Laranja");
                        colorManager.ChangeColor( 0, target );

                    }
                    if ( Input.GetKeyDown( KeyCode.J ) )
                    {
                        //Debug.Log("A: Mudando Cor Vermelho");
                        colorManager.ChangeColor( 1, target );
                    }
                    if ( Input.GetKeyDown( KeyCode.K ) )
                    {
                        //Debug.Log("S: Mudando Cor Rosa");
                        colorManager.ChangeColor( 2, target );
                    }
                    if ( Input.GetKeyDown( KeyCode.L ) )
                    {
                        //Debug.Log("D: Mudando Cor Amarelo");
                        colorManager.ChangeColor( 3, target );
                    }
                }

            }
        }
        */
        if ( gameManager.moveCamera )
        {
            if ( ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
            {
                moveCamera.MoveForward();
            }
            if ( ( Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
            {
                moveCamera.MoveBackward();
            }
            if ( ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow ) ) )
            {
                moveCamera.MoveLeft();
            }
            if ( ( Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow ) ) )
            {
                moveCamera.MoveRight();
            }
            if ( ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
            {
                Debug.Log( "AAAAAAAAAA" );
                moveCamera.MoveUp();
            }
            if ( ( Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
            {
                moveCamera.MoveDown();
            }
        }

        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            gameManager.ChangeconnectionType();
        }
        if ( Input.GetKeyDown( KeyCode.Z ) )
        {
            int aux = gameManager.GetconnectionType();
            if ( aux == 2 )
            {
                //gameManager.FaceToFace();
            }
        }

        if ( Input.GetKeyDown( KeyCode.P ) )
        {
            Debug.Log( "Restart" );
            gameManager.Restart();
        }
        /*
        if(Input.GetKeyDown( KeyCode.Delete ) || Input.GetKeyDown( KeyCode.Backspace ) )
        {
            gameManager.DeleteGameObect(gameManager.GetSelectedObjectForm());
        }
        */
    }

    
}
