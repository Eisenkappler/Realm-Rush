using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[ExecuteAlways] //will also run in edit mode 
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();

    private void Awake() {
        label = GetComponent<TextMeshPro>();  
        DisplayCoordinates();   
    }
    
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);  
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);  
    
        label.text = coordinates.x + ","+coordinates.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
