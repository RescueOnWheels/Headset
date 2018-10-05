using UnityEngine;
using System;

using UnityEngine.UI;

/// <summary>
/// A Unity3D Script to dipsplay Mjpeg streams. Apply this script to the mesh that you want to use to view the Mjpeg stream. 
/// </summary>
public class RotateServo : MonoBehaviour
{
    
    /// <summary>
    /// Show rotation (OnGUI).
    /// </summary>
    [Tooltip("Show r (OnGUI).")]
    public bool showRot = true;


    const int initWidth = 2;
    const int initHeight = 2;


    public void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
       
    }

    void DrawRot()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(-90, 20 + (h * 4 / 100 + 10), w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(255, 0, 0, 255);
		
        float x_rotate = gameObject.transform.localEulerAngles.x;
		float y_rotate = gameObject.transform.localEulerAngles.y;
		
        string text = string.Format("X: {0:0.0} \nY: {1:0.0}", x_rotate, y_rotate);
        GUI.Label(rect, text, style);
    }

    void OnGUI()
    {
        if (showRot) DrawRot();
    }

    
}