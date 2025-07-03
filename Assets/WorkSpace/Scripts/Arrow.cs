/*
 * Date 2025�N6��25��
 * programar Sum1r3
 * Arrow.cs
 * ��ʏ�ɕ\��������UI
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static RoundManager;

public class Arrow : MonoBehaviour{
    //�t���[�c�̑����l
    [SerializeField]
    private int changeValue;

    [SerializeField]
    Canvas canvas;

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

    [SerializeField]
    private Outline outline;

    private void Awake() {
        Initialized();
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Initialized() {
        canvas.enabled = true;
        outline = GetComponent<Outline>();

        width = (int) this.GetComponent<RectTransform>().sizeDelta.x;
        height = (int) this.GetComponent<RectTransform>().sizeDelta.y;


        buttonLeft = (int) this.transform.position.x - width / 2;
        buttonRight = (int) this.transform.position.x + width / 2;
        buttonUp = (int) this.transform.position.y + height / 2;
        buttonBottom = (int) this.transform.position.y - height / 2;
    }

    //�V�������@�Arect���擾���ē����蔻����s���̂�����
    private void Update() {
        //���[�N�t�F�[�Y�ȊO�Ȃ�\�������Ȃ�
        if (state != GameState.Make) {
            canvas.enabled = false;
            return;
        }
        else {
            if (!canvas.enabled) {
                canvas.enabled = true;
            }
            mousePosition = Input.mousePosition;

            if (CheckGetButton()) {
                getButton = true;
            }else {
                getButton = false;
            }


            if (Input.GetMouseButtonUp(0) && getButton) {
                FoodManager.instance.IncreaceIndex(changeValue);
            }

            

        }
    }

    private bool CheckGetButton() {
        if (mousePosition.x < buttonLeft) return false;
        if (mousePosition.x > buttonRight) return false;
        if (mousePosition.y > buttonUp) return false;
        if (mousePosition.y < buttonBottom) return false;
        return true;
    }
}
