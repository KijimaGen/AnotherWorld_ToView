/*
 * Date 2025年6月9日
 * programar Sum1r3
 * GameManager.cs
 * ゲームマネージャー
 */
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour{
    

    public static GameManager instance;
    void Start() {
        instance = this;
    }
    
    
    void Update()
    {
        
    }
}
