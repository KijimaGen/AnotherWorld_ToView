/*
 * Date 2025年6月13日
 * programar Sum1r3
 * Syokuzai.cs
 * 食材を乗っけてあるお皿のクラス
 */

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Syokuzai : MonoBehaviour{
    private Camera cam;
    //呼び出すフルーツ
    private GameObject InstatiateObject = null;
    //装飾用のフルーツ
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
        // マウス左クリックで操作開始
        if (!Input.GetMouseButtonDown(0)) return;
        
        //レイキャスト取得
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits = Physics.RaycastAll(ray, maxDistance, layerMask);
        //raycast確認
        foreach (RaycastHit hit in hits) {
            //自身に当たっているか
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
