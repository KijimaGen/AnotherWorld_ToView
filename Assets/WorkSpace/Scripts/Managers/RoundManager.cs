/*
 * Date 2025”N6Œ18“ú
 * programar Sum1r3
 * RoundManager.cs
 * ƒ‰ƒEƒ“ƒh(ì‚Á‚Ä’ñ‹Ÿ‚µ‚Ä•]‰¿‚µ‚Ä‚à‚ç‚¤‚Ü‚Å)‚Ìˆ—ŠÇ—
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
