/*
 * Date 2025�N6��18��
 * programar Sum1r3
 * RoundManager.cs
 * ���E���h(����Ē񋟂��ĕ]�����Ă��炤�܂�)�̏����Ǘ�
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
