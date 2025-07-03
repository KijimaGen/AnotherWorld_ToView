/*
 * Date 2025”N6Œ30“ú
 * programar Sum1r3
 * CustomerManager.cs
 * ‚¨‹q‚³‚ñŒÄ‚Ño‚µˆ—
 */
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomerManager : MonoBehaviour{
    //‚¨‹q‚³‚ñŒÄ‚Ño‚µ‚É•K—v‚È‚à‚Ì
    [SerializeField]
    private List<GameObject> customerList;
    [SerializeField]
    Transform customerSpawnPos;
    

    //‚¨‹q‚³‚ñ‚Éˆø‚«“n‚µ‚½‚¢î•ñ
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
