﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFPSDisplay : MonoBehaviour
{
	float deltaTime = 0.0f;

    private void Awake()
    {
		Application.targetFrameRate = 60;
	}

    void Update()
	{
		deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
	}

	void OnGUI()
	{
		int w = Screen.width, h = Screen.height;

		GUIStyle style = new GUIStyle();

		Rect rect = new Rect(0f, h-70f, (w - 50.0f), h * 2 / 100);
		style.alignment = TextAnchor.LowerRight;
		style.fontSize = h * 2 / 100;
		style.normal.textColor = new Color(0f, 0f, 0f, 0.3f);
		float msec = deltaTime * 1000.0f;
		float fps = 1.0f / deltaTime;
		//string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
		string text = string.Format("{1:0.} fps", msec, fps);
		GUI.Label(rect, text, style);
	}
}
