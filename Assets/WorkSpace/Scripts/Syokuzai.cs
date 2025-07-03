/*
 * Date 2025�N6��13��
 * programar Sum1r3
 * Syokuzai.cs
 * �H�ނ�������Ă��邨�M�̃N���X
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Syokuzai : MonoBehaviour{
    private Camera cam;
    //�Ăяo���t���[�c
    private GameObject InstatiateObject = null;
    //�����p�̃t���[�c
    private GameObject putObject = null;
    
    [SerializeField]Transform foodPos;
    Vector3 SpawnPos;
    int layerMask = -1;
    int maxDistance = 1000;

    void Start() {
        cam = Camera.main;

        SpawnPos = foodPos.position;
        layerMask = LayerMask.GetMask("Foods");


    }

   
    void Update(){
        // �}�E�X���N���b�N�ő���J�n
        if (!Input.GetMouseButtonDown(0)) return;
        
        //���C�L���X�g�擾
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask);
        //raycast�m�F
        foreach (RaycastHit hit in hits) {
            //���g�ɓ������Ă��邩
            if (hit.collider.gameObject == this.gameObject) {
                Instantiate(InstatiateObject, SpawnPos, Quaternion.Euler(0, 0, 0));
                MargeManager.haveFruit = true;
               
            }
            
        }
        
    } 


    public void ChangePutFruit(GameObject putFruit,GameObject instantObject) {
        if (foodPos.GetChild(0).gameObject != null) {
            Destroy(foodPos.GetChild(0).gameObject);
        }
        InstatiateObject = instantObject;
        putObject = putFruit;

        Instantiate(putFruit, foodPos.transform.position,transform.rotation,foodPos);
    }

    
}
