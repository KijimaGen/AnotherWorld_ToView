/*
 * Date 2025�N6��23��
 * programar Sum1r3
 * ColorManager.cs
 * �W���[�X�𕡐��Ƃ������Ƃ������邽�߂̃��m�A�o�C�o�C�������ő��₷
 */
using UnityEngine;

public class Juice : MonoBehaviour{
    Rigidbody rb;
    public static Juice instance;
    private float powor = 10;

    //��яo���Ȃ����߂̃��m
    private const float maxSpeed = 1;
    private float distance = -1;
    private const float maxDistanace = 0.3f;
    private GameObject Cop;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        instance = this;
        Cop = GameObject.Find("�R�b�v");
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
        //��΂�
        rb.AddForce(ShakePowor / powor, ForceMode.Impulse);
        
    }
}
