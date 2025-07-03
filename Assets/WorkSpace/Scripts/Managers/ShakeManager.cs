/*
 * Date 2025�N6��18��
 * programar Sum1r3
 * ShakeManager.cs
 * �X�}�z���h��Ă��邩�ǂ��������m���邽�߂̕�
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
        //���Ⴏ�ӂ��[���̎����������悤��
        if (RoundManager.state == RoundManager.GameState.Shake) {
            ShakeCheck();
            //�f�o�b�O�p�̂��Ⴏ
            if (Input.GetKeyDown(KeyCode.S)) {
                ShakeCount++;
                Juice.instance.Shake(Vector3.up);
                SoundManager.instance.PlaySound(1);
            }
        }
    }


    /// <summary>
    /// �X�}�z���h��Ă��邩�ǂ����̃`�F�b�N
    /// </summary>
    void ShakeCheck() {
        //���݂̈ړ��x�N�g����pre�ɑ��
        preAcceleration = Acceleration;
        //���݂̈ړ��t���[���̏�������
        Acceleration = Input.acceleration;
        //��̃x�N�g���̓��ς����߂�
        DotProduct = Vector3.Dot(Acceleration, preAcceleration);
        //���ς�0�ȉ� = �t�����ɓ����Ă���̂ŏ��� 
        if(DotProduct < 0) {
            ShakeCount++;
            SoundManager.instance.PlaySound(1);
            Juice.instance.Shake(preAcceleration);
        }
    }
}
