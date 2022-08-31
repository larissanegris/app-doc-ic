using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    GameManager gameManager;
    Move move;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
        move = GetComponent<Move>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            gameManager.selectedObject.transform.position =(touchPosition);
        }
    }
}
