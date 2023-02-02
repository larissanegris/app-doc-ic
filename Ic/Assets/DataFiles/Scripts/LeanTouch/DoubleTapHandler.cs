using System;
using UnityEngine;
using Lean.Touch;

public class DoubleTapHandler : MonoBehaviour
{
    [SerializeField][Range (0, 100)]
    private float doubleTapThreshold = 5f;
    private float lastTap;

    public Action<LeanFinger> DoubleTap;

    private void Awake()
    {
        LeanTouch.OnFingerTap += HandleDoubleTap;
    }
    private void HandleDoubleTap(LeanFinger finger)
    {
        if (Time.frameCount - lastTap  < doubleTapThreshold )
        {
            //Debug.Log("Double tap ");
            DoubleTap(finger);
        }
        lastTap = Time.frameCount;
    }
}
