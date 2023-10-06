using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public Color playerColor;


    void Start()
    {
        RandomColor();
    }
    public void RandomColor()
    {
        playerColor = new Color(Random.value, Random.value, Random.value);
        GetComponent<MeshRenderer>().material.color = playerColor;
    }

    
}