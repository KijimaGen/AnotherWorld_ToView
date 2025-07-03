/*
 * Date 2025�N6��13��
 * programar Sum1r3
 * MargeManager.cs
 * �ʕ��ƃW���[�X�{�̂�������̂��Ǘ��������
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MargeManager : MonoBehaviour {
    //�C���X�^���X
    public static MargeManager instance;
    [SerializeField]
    private Material juice;
    Camera cam;

    public static bool haveFruit;
    public static bool hitRayCop;

    private float maxDistance = 100;

    private void Start() {
        instance = this;
        cam = Camera.main;
    }

    private void Update() {
        if (haveFruit && hitRayCop) 
            juice.color = Color.red;
        else
            juice.color = Color.green;

        if(Input.GetMouseButtonUp(0))
            haveFruit = false;

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance);

        foreach (RaycastHit hit in hits) {
            if (hit.transform.tag == "Cop") {
                hitRayCop = true;
                return;
            }
        }

        

        hitRayCop = false;

    }

    /// <summary>
    /// �t���[�c�ƃR�b�v���d�Ȃ��Ă��邩��Ԃ��֐�(FC2����Ȃ���I�I)
    /// </summary>
    /// <returns></returns>
    public bool OverlapF2C() {
        return haveFruit && hitRayCop;
    }
}