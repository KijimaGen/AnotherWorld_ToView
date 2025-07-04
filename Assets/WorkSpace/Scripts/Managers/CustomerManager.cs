/*
 * Date 2025年6月30日
 * programar Sum1r3
 * CustomerManager.cs
 * お客さん呼び出し処理
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerManager : MonoBehaviour{
    //お客さん呼び出しに必要なもの
    [SerializeField]
    private List<GameObject> customerList;
    [SerializeField]
    Transform customerSpawnPos;
    

    //お客さんに引き渡したい情報
    [SerializeField]
    Canvas canvas;
    [SerializeField]
    TextMeshProUGUI customerText;
    [SerializeField]
    Transform CustmerPos;
    public Transform CustomerEndPos;
    
    public static CustomerManager instance;

    private void Awake() {
        instance = this;
        canvas.enabled = false;
    }


    public void InstantiateCustmer() {
        Instantiate(customerList[0], CustmerPos.transform.position,Quaternion.identity);
    }

    public Canvas GetCustomerCanvas() {
        return canvas;
    }

    public TextMeshProUGUI GetCustmerText() {
        return customerText;
    }

    public Vector3 GetCustmerPos() {
        return CustmerPos.position;
    }

    public Vector3 GetCustomereEndPos() {
        return CustmerPos.position;
    }
}
