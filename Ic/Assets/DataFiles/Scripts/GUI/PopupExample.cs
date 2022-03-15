using UnityEngine;
using UnityEditor;

public enum OPTIONS
{
    COLISAO = 0,
    FACEAFACE = 1,
    DISTANCIA = 2,
    NENHUMA = 3,
}




public class PopupExample : PopupWindowContent
{
    public OPTIONS op;
    GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    public override Vector2 GetWindowSize()
    {
        return new Vector2(300, 100);
    }

    public override void OnGUI(Rect rect)
    {
        op = (OPTIONS)EditorGUILayout.EnumPopup("Primitive to create:", op);
        if (GUILayout.Button("Send"))
            gameManager.SetTipoConecao(((int)op));
    }

    

    public override void OnOpen()
    {
        Debug.Log("Popup opened: " + this);
    }

    public override void OnClose()
    {
        Debug.Log("Popup closed: " + this);
    }
}