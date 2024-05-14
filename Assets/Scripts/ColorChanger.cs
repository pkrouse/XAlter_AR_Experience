using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public void SetColor(Color color)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }
}
