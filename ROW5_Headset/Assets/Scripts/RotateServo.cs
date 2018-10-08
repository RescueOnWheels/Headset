using UnityEngine;
using System;
using SocketIO;

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
	float x_rotate;
	float y_rotate;
	float z_rotate;

    public void Start()
    {
        
    }
	
    // Update is called once per frame
    void Update()
    {
       
		// Get rotations
        x_rotate = gameObject.transform.localEulerAngles.x;
		y_rotate = gameObject.transform.localEulerAngles.y;
		z_rotate = gameObject.transform.localEulerAngles.z;
		
		// Rotation mirror
		if(x_rotate > 180){
			x_rotate -= 360;
		}
		if(y_rotate > 180){
			y_rotate -= 360;
		}
		if(z_rotate > 180){
			z_rotate -= 360;
		}
    }

    void DrawRot()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(-90, 20 + (h * 4 / 100 + 10), w, h * 2 / 100);
        style.alignment = TextAnchor.UpperRight;
        style.fontSize = h * 4 / 100;
        style.normal.textColor = new Color(255, 0, 0, 255);
		
        string text = string.Format("X: {0:0.0} \nY: {1:0.0}", x_rotate, y_rotate);
        GUI.Label(rect, text, style);
    }

    void OnGUI()
    {
        if (showRot) DrawRot();
    }

    
}