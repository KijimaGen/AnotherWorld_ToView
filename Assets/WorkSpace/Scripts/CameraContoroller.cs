/*
 * Date 2025年6月18日
 * programar Sum1r3
 * CameraContoroller.cs
 * カメラがアニメーションするための処理
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraContoroller : MonoBehaviour{

    //注視するときの距離
    private float distance = -1;
    //注視対象
    [SerializeField]
    private GameObject target;
    float speed = 1f;
    //本来の座標
    Vector3 originPos;
    Quaternion originRotate;

    private void Start() {
        distance = 0.5f;
        originPos = transform.position;
        originRotate =transform.rotation;
    }

    private void Update() {
        if(RoundManager.state == RoundManager.GameState.Shake) {
            //距離が一定以上だったら
            if(Vector3.Distance(this.transform.position, target.transform.position)> distance) {
                //注視する対象に近づく
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            transform.LookAt(target.transform.position);

        }
        else {
            transform.position = originPos;
            transform.rotation = originRotate;
        }
        
    }

    /// <summary>
    /// 位置の初期化処理
    /// </summary>
    private void Reset() {
        transform.position = originPos;
        transform.rotation = originRotate;
    }
}
