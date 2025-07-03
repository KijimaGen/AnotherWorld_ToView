/**
 * @file MargePhaseButton.cs
 * @brief 色々やるボタン
 * @author Sum1r3
 * @date 2025/6/18
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static RoundManager;

public class MargePhaseButton : MonoBehaviour{

    //自身のサイズ
    int width = -1;
    int height = -1;

    //上下限左右限
    int buttonLeft = -1;
    int buttonRight = -1;
    int buttonUp = -1;
    int buttonBottom = -1;

    bool getButton = false;
    Vector3 mousePosition = Vector3.zero;
    Vector3 buttonDown = new Vector3(0.9f, 0.9f, 0.9f);

    [SerializeField]
    TextMeshProUGUI buttonText;
    [SerializeField]
    Canvas canvas;

    void Start() {
        width = (int)this.GetComponent<RectTransform>().sizeDelta.x;
        height = (int) this.GetComponent<RectTransform>().sizeDelta.y;
       

        buttonLeft = (int) this.transform.position.x - width / 2;
        buttonRight = (int) this.transform.position.x + width / 2;
        buttonUp = (int) this.transform.position.y + height / 2;
        buttonBottom = (int) this.transform.position.y - height / 2;
    }

    void Update() {

        //マウスの座標の取得
        mousePosition = Input.mousePosition;
        //マウスをクリックしたときに自身に入っているかを確認
        if(Input.GetMouseButtonDown(0)) {
            if(!CheckGetButton()) return;
            
            getButton = true;
        }
        //入っていたらgetButtonをつけて押している間にマウスが離れたらfalse

        //離したタイミングでgetButtonがついていたら次のフェーズ
        if(Input.GetMouseButtonUp(0) &&getButton) {
            switch (state) {
                case GameState.Make:
                    if (Cop.havingItem > 0)
                        state = GameState.Shake;
                    break;
                case GameState.Shake:
                    if (ShakeManager.ShakeCount > 0) {
                        state = GameState.Drink;
                        SoundManager.instance.PlaySound(0);
                    }

                    break;
                case GameState.Drink:
                    //ここで色々リセット
                    Cop.instance.Resetting();
                    ShakeManager.ShakeCount = 0;
                    state = GameState.Go;
                    break;
                case GameState.Result:
                    break;
                
                case GameState.Come:
                    break;
                case GameState.Go:
                    break;
            }




            getButton = false;
        }

        //マウスが押されているときに縮む
        if (getButton) {
            this.gameObject.transform.localScale = buttonDown;
        }
        else {
            this.gameObject.transform.localScale = Vector3.one;
        }

        //テキストの文字変えとか
        switch (state) {
            case GameState.Make:
                if (Cop.havingItem <= 0) canvas.enabled = false;
                else canvas.enabled = true;

                buttonText.text = "ふる！";
                break;
            case GameState.Shake:
                if (ShakeManager.ShakeCount <= 0) {
                    buttonText.text = "ふろう！";

                }
                else {
                    buttonText.text = "わたす！";
                }
                break;
            case GameState.Drink:
                buttonText.text = "つぎのきゃく";
                break;
            case GameState.Result:
                break;
            
            case GameState.Come:
                if(canvas.enabled)
                canvas.enabled = false;
                break;
            case GameState.Go:
                if (canvas.enabled)
                    canvas.enabled = false;
                break;
        }


    }

    /// <summary>
    /// ボタンの当たり判定
    /// </summary>
    /// <returns></returns>
    private bool CheckGetButton() {
        if (mousePosition.x < buttonLeft) return false;
        if (mousePosition.x > buttonRight) return false;
        if (mousePosition.y > buttonUp) return false;
        if (mousePosition.y < buttonBottom) return false;
        return true;
    }

}
