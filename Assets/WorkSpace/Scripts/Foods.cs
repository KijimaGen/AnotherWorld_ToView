/*
 * Date 2025�N6��9��
 * programar Sum1r3
 * Foods.cs
 * �H�ׂ��̂̊��N���X
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Foods : MonoBehaviour{
    private Camera cam;
    private float zDistance;

    private GameObject selectedObject;
    private Vector3 offset;

    private bool catchThis = true; 

    void Start() {
        cam = Camera.main;

        selectedObject = this.gameObject;
        zDistance = cam.WorldToScreenPoint(selectedObject.transform.position).z;

        // �I�t�Z�b�g���v�Z�i����h�~�j
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
        offset = selectedObject.transform.position - mouseWorld;
        Initialize();


    }

    private void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //�R�b�v�ɓ������Ă������ɂ��̃A�C�e�����P�X
        if (Input.GetMouseButtonUp(0)) {
            if (MargeManager.hitRayCop) {
                MargeManager.haveFruit = false;
                MargeSmoothie();
                SoundManager.instance.PlaySound(0);
                Destroy(gameObject);
            }
        }

        //���C�L���X�g������ē������Ă���ړ��\
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == this.gameObject.name) 
                catchThis = true;
            else
                catchThis = false;

            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            offset = selectedObject.transform.position - mouseWorld;
        }

        if (transform.position.y < -3) {
            //�f�o�b�O�폜
            Destroy(gameObject);
        }

        //�h���b�O�ړ�
        if (Input.GetMouseButton(0) && catchThis) {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            selectedObject.transform.position = mouseWorld + offset;
            MargeManager.haveFruit = true;
        }

        
        //(�N���b�N����Ă��Ȃ��Ƃ�)���~
        transform.position = new Vector3(transform.position.x,transform.position.y -0.01f ,transform.position.z);
        
        
    }

    public abstract void MargeSmoothie();

    public abstract void Initialize();
}