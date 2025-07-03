/*
 * Date 2025年6月18日
 * programar Sum1r3
 * ShakeManager.cs
 * スマホが揺れているかどうかを感知するための物
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeManager : MonoBehaviour{
    private Vector3 Acceleration;
    private Vector3 preAcceleration;
    float DotProduct;
    public static int ShakeCount;

    public void Update() {
        //しゃけふぇーずの時だけ動くように
        if (RoundManager.state == RoundManager.GameState.Shake) {
            ShakeCheck();
            //デバッグ用のしゃけ
            if (Input.GetKeyDown(KeyCode.S)) {
                ShakeCount++;
                Juice.instance.Shake(Vector3.up);
                SoundManager.instance.PlaySound(1);
            }
        }
    }


    /// <summary>
    /// スマホが揺れているかどうかのチェック
    /// </summary>
    void ShakeCheck() {
        //現在の移動ベクトルをpreに代入
        preAcceleration = Acceleration;
        //現在の移動フレームの書き換え
        Acceleration = Input.acceleration;
        //二つのベクトルの内積を求める
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        //内積が0以下 = 逆方向に動いているので処理 
        if(DotProduct < 0) {
            ShakeCount++;
            SoundManager.instance.PlaySound(1);
            Juice.instance.Shake(preAcceleration);
        }
    }
}
