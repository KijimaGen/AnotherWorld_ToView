/*
 * Date 2025年6月23日
 * programar Sum1r3
 * ColorManager.cs
 * ジュースを複製とか挙動とかさせるためのモノ、バイバイン方式で増やす
 */
using UnityEngine;

public class Juice : MonoBehaviour{
    Rigidbody rb;
    public static Juice instance;
    private float powor = 10;

    //飛び出さないためのモノ
    private const float maxSpeed = 1;
    private float distance = -1;
    private const float maxDistanace = 0.3f;
    private GameObject Cop;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        instance = this;
        Cop = GameObject.Find("コップ");
    }
    private void Update() {
        if(rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
        distance = Vector3.Distance(this.gameObject.transform.position, Cop.transform.position);
        if (distance > maxDistanace) {
            rb.velocity = Vector3.zero;
            this.transform.position = Cop.transform.position;
        }
        
    }

    public void Shake(Vector3 ShakePowor) {
        //飛ばす
        rb.AddForce(ShakePowor / powor, ForceMode.Impulse);
        
    }
}
