/*
 * Date 2025年6月23日
 * programar Sum1r3
 * ColorManager.cs
 * 色管理スクリプト(主にゲーミング色)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour{

    public static Color rainbow;

    public float colorSpeed = 1f;

    private void Update() {
        
        float t = Mathf.PingPong(Time.time * colorSpeed, 1f);
        rainbow = Color.HSVToRGB(t, 1f, 1f); // HSVでぐるぐる
        
    }
}
