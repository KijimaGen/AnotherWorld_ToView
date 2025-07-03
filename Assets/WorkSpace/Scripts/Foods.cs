/*
 * Date 2025年6月9日
 * programar Sum1r3
 * Foods.cs
 * 食べものの基底クラス
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

        // オフセットを計算（ずれ防止）
        Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
        offset = selectedObject.transform.position - mouseWorld;
        Initialize();


    }

    private void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //コップに当たっていた時にこのアイテムをケス
        if (Input.GetMouseButtonUp(0)) {
            if (MargeManager.hitRayCop) {
                MargeManager.haveFruit = false;
                MargeSmoothie();
                SoundManager.instance.PlaySound(0);
                Destroy(gameObject);
            }
        }

        //レイキャストを取って当たってたら移動可能
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == this.gameObject.name) 
                catchThis = true;
            else
                catchThis = false;

            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            offset = selectedObject.transform.position - mouseWorld;
        }

        if (transform.position.y < -3) {
            //デバッグ削除
            Destroy(gameObject);
        }

        //ドラッグ移動
        if (Input.GetMouseButton(0) && catchThis) {
            Vector3 mouseWorld = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));
            selectedObject.transform.position = mouseWorld + offset;
            MargeManager.haveFruit = true;
        }

        
        //(クリックされていないとき)下降
        transform.position = new Vector3(transform.position.x,transform.position.y -0.01f ,transform.position.z);
        
        
    }

    public abstract void MargeSmoothie();

    public abstract void Initialize();
}