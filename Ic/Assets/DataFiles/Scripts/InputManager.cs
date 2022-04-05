using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject target;
    private int tipoInteracao;
    private bool _blockInteraction;
    public ColorManager colorManager;

    private void Start()
    {
        colorManager = gameManager.GetComponent<ColorManager>();
    }

    // Update is called once per frame
    void Update()
    {

        tipoInteracao = gameManager.tipoInteracao;
        _blockInteraction = gameManager.blockInteraction;
        //Criar cubo opaco
        if ( Input.GetKeyDown( KeyCode.Q ) && !Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.prefabInstantiator.Spawn( FormType.Cube, false );
        }
        //cria cubo transparente
        if ( Input.GetKeyDown( KeyCode.Q ) && Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.prefabInstantiator.Spawn( FormType.Cube, true );
        }
        //criar esfera opaca
        if ( Input.GetKeyDown( KeyCode.E ) && !Input.GetKey( KeyCode.LeftShift ))
        {
            gameManager.prefabInstantiator.Spawn( FormType.Sphere, false );
        }
        //cria esfera transparente
        if ( Input.GetKeyDown( KeyCode.E ) && Input.GetKey( KeyCode.LeftShift ) )
        {
            gameManager.prefabInstantiator.Spawn( FormType.Sphere, true );
        }



        //teclas para selecionar os objetos
        //Mover
        if ( Input.GetKeyDown( KeyCode.Alpha0 ) )
        {
            gameManager.tipoInteracao = 0;
        }
        //Rotacionar
        if ( Input.GetKeyDown( KeyCode.Alpha1 ) )
        {
            gameManager.tipoInteracao = 1;
        }
        //escalar
        if ( Input.GetKeyDown( KeyCode.Alpha2 ) )
        {
            gameManager.tipoInteracao = 2;
        }

        //Movimentacao
        if ( gameManager.GetSelectedObject() )
        {

            target = gameManager.GetSelectedObject();
            Form form = target.GetComponent<Form>();

            if ( form.GetIsInBlock() && gameManager.blockInteraction )
            {
                target = target.transform.parent.gameObject;
            }


            if ( (Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move UP");
                    target.GetComponent<MoveObject>().MoveUp();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate UP");
                    target.GetComponent<RotateObject>().RotateUp();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale UP");
                    target.GetComponent<ResizeObject>().ScaleUp();
                }

            }
            if ( (Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) ) && !Input.GetKey( KeyCode.LeftShift ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move Down");
                    target.GetComponent<MoveObject>().MoveDown();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate Down");
                    target.GetComponent<RotateObject>().RotateDown();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale Down");
                    target.GetComponent<ResizeObject>().ScaleDown();
                }
            }
            if ( Input.GetKey( KeyCode.D ) || Input.GetKey( KeyCode.RightArrow ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move Right");
                    target.GetComponent<MoveObject>().MoveRight();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate Right");
                    target.GetComponent<RotateObject>().RotateRight();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale Right");
                    target.GetComponent<ResizeObject>().ScaleRight();
                }
            }
            if ( Input.GetKey( KeyCode.A ) || Input.GetKey( KeyCode.LeftArrow ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move Left");
                    target.GetComponent<MoveObject>().MoveLeft();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate Left");
                    target.GetComponent<RotateObject>().RotateLeft();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale Left");
                    target.GetComponent<ResizeObject>().ScaleLeft();
                }
            }
            if ( (Input.GetKey( KeyCode.W ) || Input.GetKey( KeyCode.UpArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move Forward");
                    target.GetComponent<MoveObject>().MoveForward();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate Forward");
                    target.GetComponent<RotateObject>().RotateForward();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale Forward");
                    target.GetComponent<ResizeObject>().ScaleForward();
                }
            }
            if ( (Input.GetKey( KeyCode.S ) || Input.GetKey( KeyCode.DownArrow ) ) && Input.GetKey( KeyCode.LeftShift ) )
            {
                if ( tipoInteracao == 0 )
                {
                    //Debug.Log("Move Backward");
                    target.GetComponent<MoveObject>().MoveBackward();
                }
                else if ( tipoInteracao == 1 )
                {
                    //Debug.Log("Rotate Backward");
                    target.GetComponent<RotateObject>().RotateBackward();
                }
                else if ( tipoInteracao == 2 )
                {
                    //Debug.Log("Scale Backward");
                    target.GetComponent<ResizeObject>().ScaleBackward();
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

        if ( Input.GetKeyDown( KeyCode.R ) )
        {
            gameManager.changeBlockInteraction();
        }
        if ( Input.GetKeyDown( KeyCode.Space ) )
        {
            int aux = gameManager.GetTipoConecao();
            if ( aux == 3 ) gameManager.SetTipoConecao( 0 );
            else gameManager.SetTipoConecao( ++aux );
        }
        if ( Input.GetKeyDown( KeyCode.Z ) )
        {
            int aux = gameManager.GetTipoConecao();
            if ( aux == 2 )
            {
                //gameManager.FaceToFace();
            }
        }
    }
}
