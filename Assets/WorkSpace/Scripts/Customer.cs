/*
 * Date 2025�N6��20��
 * programar Sum1r3
 * Customer.cs
 * ���q����̏���
 */
using UnityEngine;
using static RoundManager;
using static GameConst;
using static CommonModule;
using static UnityEngine.GraphicsBuffer;
using TMPro;
using UnityEngine.Animations;

public class Customer : MonoBehaviour{
    [SerializeField]
    Transform child;

    //�������Ԑݒ�
    float timer = -1;

    private const float _TIME_GOOD = 15;
    private const float _TIME_NOTBAD = 0;

    //public static Customer instance;

    //�v��
    private Taste hopeTaste;
    private Effect hopeEffect;

    //�e�L�X�g�{�b�N�X�̎擾
    Canvas canvas;
    TextMeshProUGUI customerText;

    //��~���W�A���傤�߂�����W��錾
    Vector3 customerPos;
    Vector3 customerEndPos;

    //�K�v�ȃe�L�X�g
    string customerName;
    string tasteText;
    string effectText;

    //�ړ��X�s�[�h
    const float speed = 1;

    //��ʊO����
    Camera camera;
    Renderer rend;

    //��]�̋���
    Vector3 lookRot = new Vector3(0, 90, 0);

    private const float DISTANCE_MIN = 0.1f; 
    private void Start() {
        Initialize();
        
    }


    public void Initialize() {
        //�������Ԃ̐ݒ�(��X���q����ɂ����i��ݒ肵�Ă��ꂼ��Őݒ肵�����J��)
        //���䂦�ɍ��̓}�W�b�N�i���o�[�ŋ����Ă�������
        timer = 30.0f;
        //�f�o�b�O
        customerName = "�₳�������Ȃ��Ⴍ";
       
        //�����Ŋ�]�̏��i���쐬(���̊���ȕ��͕̂ςȃX�e�[�g���E��Ȃ����߂̃��m��)
        do {
            hopeEffect = GetRandomEnumValue<Effect>();
        } while (hopeEffect == Effect.Max);

        
        do {
            hopeTaste = GetRandomEnumValue<Taste>();
        } while (hopeTaste == Taste.None || hopeTaste == Taste.Max || hopeTaste == Taste.Chaos);

        //������Ăяo�����߂̕�
        canvas = CustomerManager.instance.GetCustomerCanvas();
        customerText = CustomerManager.instance.GetCustmerText();
        customerPos = CustomerManager.instance.GetCustmerPos();
        customerEndPos = CustomerManager.instance.GetCustomereEndPos();


        camera = Camera.main;
        rend = GetComponent<Renderer>();
    }

    private void Update() {
        if (timer > _TIME_BOTTOM && state == GameState.Make || state == GameState.Shake) {
            timer -= Time.deltaTime;
        }

        //�����œ���̃Q�[���X�e�[�g�̎��̋���
        
        
        switch (state) {
            case GameState.Come:
                // �^�[�Q�b�g�������v�Z
                Vector3 direction = (customerPos - transform.position).normalized;

                // �ړ�
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(customerPos);
                if (Vector3.Distance(customerPos,this.transform.position) < DISTANCE_MIN) 
                    state = GameState.Make;

                //�����Ŕ�\��
                if (canvas.enabled)
                    canvas.enabled = false;

                break;
            case GameState.Make:
                if (!canvas.enabled)
                    canvas.enabled = true;
                ChangeTextFromTaste();
                ChangeTextFromEffect();
                this.transform.LookAt(camera.transform.position);
                customerText.text = customerName + "\n" + tasteText + effectText + "�X���[�W�[�����˂���";
                break;
            case GameState.Shake:
                customerText.text = "";
                this.transform.LookAt(camera.transform.position);
                break;
            case GameState.Drink:
                this.transform.LookAt(camera.transform.position);
                break;
            case GameState.Result:
                break;
            case GameState.Go:
                //�L�����o�X���\���ɂ��Ă������
                if (canvas.enabled)
                    canvas.enabled = false;
                
                // �^�[�Q�b�g�������v�Z
                direction = (customerEndPos - transform.position).normalized;

                // �ړ�
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(customerEndPos);
                //�S�[���ɒ������������Đ������ď�����
                if (Vector3.Distance(customerEndPos, this.transform.position) < DISTANCE_MIN) {
                    
                }
                break;
           
        }

        transform.Rotate(lookRot + new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z));

    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Cop") {
            other.gameObject.transform.position = child.position;
            other.GetComponent<Cop>().ChangeisHaveCop(true);

            if(hopeEffect != other.GetComponent<Cop>().GetEffect()) {
                customerText.text = "������������������Ȃ����I";
                return;
            }

            if(hopeTaste != other.GetComponent<Cop>().GetTaste()) {
                customerText.text = "����������������Ȃ����I";
            }

            if (timer > _TIME_GOOD) {
                customerText.text = "�͂₢�ˁA���肪��";
            }
            else if(timer > _TIME_NOTBAD) {
                customerText.text = "���肪�Ƃ�";
            }
            else {
                customerText.text = "�������������ǂ��肪��";
            }
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20),$"{timer}");
    }

    private void ChangeTextFromTaste() {
        switch (hopeTaste) {
            case Taste.Sweet:
                tasteText = "���܂�\n";
                break;
            case Taste.Spicy:
                tasteText = "���炢\n";
                break;
            case Taste.Bitter:
                tasteText = "�ɂ���\n";
                break;
            case Taste.Acid:
                tasteText = "�����ς�\n";
                break;
        }
    }

    private void ChangeTextFromEffect() {
        switch (hopeEffect) {
            case Effect.None:
                effectText = "";
                break;
            case Effect.Life:
                effectText = "���񂫂����炦��\n";
                break;
            case Effect.Power:
                effectText = "�����炪��\n";
                break;
            case Effect.Defense:
                effectText = "���񂶂傤�ɂȂ��\n";
                break;
            case Effect.Heal:
                effectText = "�����̂Ȃ��肪�͂₭�Ȃ�\n";
                break;
            case Effect.Magic:
                effectText = "�܂�傭�����炦��\n";
                break;
            case Effect.Lucky:
                effectText = "���񂪂悭�Ȃ�\n";
                break;
            
        }
    }
}