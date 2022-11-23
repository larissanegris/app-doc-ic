using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleButton : MonoBehaviour
{
    public Button scale;
    public bool scaleToggle = true;

    private GameManager gameManager;
    private ScaleManager scaleManager;

    public Action<bool> ToggleControlSphere;
    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        scaleManager = GetComponent<ScaleManager>();

        scale.onClick.AddListener(() => ToggleControlSphere(scaleToggle = !scaleToggle));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
