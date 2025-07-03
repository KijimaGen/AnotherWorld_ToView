/*
 * Date 2025�N6��30��
 * programar Sum1r3
 * CustomerManager.cs
 * ���q����Ăяo������
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerManager : MonoBehaviour{
    //���q����Ăяo���ɕK�v�Ȃ���
    [SerializeField]
    private List<GameObject> customerList;
    [SerializeField]
    Transform customerSpawnPos;
    

    //���q����Ɉ����n���������
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
