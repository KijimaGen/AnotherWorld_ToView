/*
 * Date 2025年6月18日
 * programar Sum1r3
 * RoundManager.cs
 * ラウンド(作って提供して評価してもらうまで)の処理管理
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour{
    public enum GameState {
        Come,
        Make,
        Shake,
        Drink,
        Result,
        Go,
        Max
    };

    public static GameState state;

    public static RoundManager instance;
    void Start(){
        instance = this;
        state = GameState.Come;
    }

    
    void Update(){
        
    }
}
