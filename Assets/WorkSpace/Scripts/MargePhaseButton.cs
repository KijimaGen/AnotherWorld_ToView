/**
 * @file MargePhaseButton.cs
 * @brief �F�X���{�^��
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

    //���g�̃T�C�Y
    int width = -1;
    int height = -1;

    //�㉺�����E��
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

        //�}�E�X�̍��W�̎擾
        mousePosition = Input.mousePosition;
        //�}�E�X���N���b�N�����Ƃ��Ɏ��g�ɓ����Ă��邩���m�F
        if(Input.GetMouseButtonDown(0)) {
            if(!CheckGetButton()) return;
            
            getButton = true;
        }
        //�����Ă�����getButton�����ĉ����Ă���ԂɃ}�E�X�����ꂽ��false

        //�������^�C�~���O��getButton�����Ă����玟�̃t�F�[�Y
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
                    //�����ŐF�X���Z�b�g
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

        //�}�E�X��������Ă���Ƃ��ɏk��
        if (getButton) {
            this.gameObject.transform.localScale = buttonDown;
        }
        else {
            this.gameObject.transform.localScale = Vector3.one;
        }

        //�e�L�X�g�̕����ς��Ƃ�
        switch (state) {
            case GameState.Make:
                if (Cop.havingItem <= 0) canvas.enabled = false;
                else canvas.enabled = true;

                buttonText.text = "�ӂ�I";
                break;
            case GameState.Shake:
                if (ShakeManager.ShakeCount <= 0) {
                    buttonText.text = "�ӂ낤�I";

                }
                else {
                    buttonText.text = "�킽���I";
                }
                break;
            case GameState.Drink:
                buttonText.text = "���̂��Ⴍ";
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
    /// �{�^���̓����蔻��
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
