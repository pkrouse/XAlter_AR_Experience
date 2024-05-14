using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopOutController : MonoBehaviour
{
    PopOut[] popOuts;
    [SerializeField] ColorChanger colorChanger;
    private Color downColor = Color.cyan;
    private Color upColor = Color.green;
    private Color errorColor = Color.red;
    private void Start()
    {
        popOuts  = GetComponentsInChildren<PopOut>();
        if (popOuts.Length > 0)
        {
            colorChanger.SetColor(upColor);
        }
        else
        {
            colorChanger.SetColor(errorColor);
        }
    }
    public void pointerDown()
    {
        colorChanger.SetColor(downColor);
    }
    public void pointerUp()
    {
        colorChanger.SetColor(upColor);
    }
}

