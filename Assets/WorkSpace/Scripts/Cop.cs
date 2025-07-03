/*
 * Date 2025�N6��9��
 * programar Sum1r3
 * Cop.cs
 * �R�b�v�N���X
 */
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static GameConst;

public class Cop : MonoBehaviour{
    private Camera cam;
    [SerializeField]
    Material juiceMaterial;
    Color juiceColor;
    
    private int sweet;  //��
    private int spicy;  //�h
    private int bitter; //��
    private int acid;   //�_

    //���ł��������������邽�߂̂���
    int max;
    
    //���̖�
    Taste taste;

    //��Ɉړ�����Ƃ��̂��ǂ��X�s�[�h
    const float speed = 0.75f;
    //�����Ă���A�C�e���̌�(����͂��Ȃ���)
    public static int havingItem;
    [SerializeField]
    TextMeshProUGUI copText;

    //���ꂼ��A���\�A���A�S�̂̃e�L�X�g
    private string effectText = "�������Ȃ���";
    private string tasteText =  "�ނ݂�";
    private string juiceText = "�X���[�W�[";

    private Vector3 originPos = Vector3.zero;

    //�ړ����邩�ǂ�����bool
    bool isHaveCop ;

    //���g�̃C���X�^���X(��ɋq�����g������)
    public static Cop instance;

    public Effect nowEffect { get; private set; }

    [SerializeField]
    Canvas canvas;

    private void Start() {
        originPos = transform.position;
        cam = Camera.main;
        instance = this;
        Initialize();
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Initialize() {
        sweet = 0;
        spicy = 0;
        bitter = 0;
        acid = 0;
        nowEffect = Effect.None;
        juiceColor = new Color(255, 255, 255);
        havingItem = 0;
        isHaveCop = false;
        this.transform.position = originPos;
        effectText = "�������Ȃ���";
        tasteText = "�ނ݂�";
        juiceText = "�X���[�W�[";
        taste = Taste.None;
    }

    private void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            //���g�ɓ������Ă��邩
            if (hit.collider.gameObject == this.gameObject)
                MargeManager.hitRayCop = true;
        }
        else {
            MargeManager.hitRayCop = false;
        }

        
        //�R�b�v�ɏd�Ȃ��Ă�����A�E�g���C���̐F��ς���
        if (MargeManager.instance.OverlapF2C())
            GetComponent<Outline>().ChangeOutlineColor(new Color(255, 255, 0));
        else 
            GetComponent<Outline>().ChangeOutlineColor(Color.white);


        //���E���h���Ƃ̏���
        switch (RoundManager.state) {
            case RoundManager.GameState.Make: {
                
                //�R�b�v�̌��\�ɂ���ăe�L�X�g�ύX
                ChangeEffectText();

                if (!canvas.enabled)
                    canvas.enabled = true;
            }
                break;
            case RoundManager.GameState.Shake:
                if (this.transform.position.y < 1)
                    transform.Translate(-transform.up * speed * Time.deltaTime);
                
                break;
            case RoundManager.GameState.Drink:
                if (!isHaveCop)
                    transform.Translate(-transform.forward * speed * Time.deltaTime);
                canvas.enabled = false;
                break;
            case RoundManager.GameState.Result:
                break;
            case RoundManager.GameState.Max:
                break;
        }

        //�R�b�v�̒��g�̐F�𔽉f
        juiceMaterial.color = juiceColor;
        //�W���[�X�̒��ɂ���A�C�e���̐��̔��f
        havingItem = sweet + spicy + bitter + acid;
        //�R�b�v�̖��ɂ��e�L�X�g�ύX
        ChangeTasteText();
        //�W���[�X�̖��O���쐬
        copText.text = tasteText + "\n" + effectText + "\n" + juiceText;

    }

    /// <summary>
    /// Sweet�̉��Z
    /// </summary>
    public  void AddSweet() {
        sweet++;
    } /// <summary>
    /// Sweet�̉��Z
    /// </summary>
    public  void AddSpicy() {
        spicy++;
    } /// <summary>
    /// Sweet�̉��Z
    /// </summary>
    public void AddBitter() {
      bitter++;
    } /// <summary>
    /// Sweet�̉��Z
    /// </summary>
    public void AddAcid() {
        acid++;
    }

    public void ChangeisHaveCop(bool _haveCop) {
        isHaveCop = _haveCop;
    }

    public void Resetting() {
        Initialize();
    }

    public void ChangeText(string text) {
        tasteText = text;
        effectText = "";
        juiceText = "";
    }

    public void ChangeEffect(Effect effect) {
        nowEffect = effect;
    }

    private void ChangeEffectText() {
        switch (nowEffect) {
            case Effect.Life:
                effectText = "���񂫂����炦��";
                break;
            case Effect.Power:
                effectText = "������̂�������";
                break;
            case Effect.Defense:
                effectText = "���񂶂傤�ɂȂꂻ����";
                break;
            case Effect.Heal:
                effectText = "�����ӂ��ɂ悳������";
                break;
            case Effect.Magic:
                effectText = "�܂�傭�����炦������";
                break;
            case Effect.Lucky:
                effectText = "���������";
                break;
            
        }
    }

    /// <summary>
    /// ���̒ǉ��@�I
    /// </summary>
    /// <param name="taste"></param>
    public void AddTaste(Taste taste) {
        switch (taste) {
           
            case Taste.Sweet:
                sweet++;
                break;
            case Taste.Spicy:
                spicy++;
                break;
            case Taste.Bitter:
                bitter++;
                break;
            case Taste.Acid:
                acid++;
                break;
            
        }
    }

    private void ChangeTasteText() {
        //�����ł����΂񍂂����̗v�f��������Ă��̐F�ɕύX����
        if (sweet == spicy && spicy == bitter && bitter == acid) {
            max = 0;
        }
        else {
            max = Mathf.Max(sweet, spicy, bitter, acid);
        }

        if (max == sweet) {
            juiceColor = new Color(1, 0.6f, 1);
            tasteText = "���܂�";
            taste = Taste.Sweet;
        }
        if (max == spicy) {
            juiceColor = Color.red;
            tasteText = "���炢";
            taste = Taste.Spicy;
        }
        if (max == bitter) {
            juiceColor = Color.green;
            tasteText = "�ɂ���";
            taste = Taste.Bitter;
        }
        if (max == acid) {
            juiceColor = Color.yellow;
            tasteText = "�����ς�";
            taste = Taste.Acid;
        }
        if (max == 0) {
            if (havingItem == 0) {
                juiceColor = Color.white;
                taste = Taste.None;
                tasteText = "�ӂ���";
            }
            else {
                juiceColor = ColorManager.rainbow;
                taste = Taste.Chaos;
                tasteText = "�J�I�X��";
            }
        }
    
    }

    /// <summary>
    /// ����^����
    /// </summary>
    /// <returns></returns>
    public Taste GetTaste() {
        return taste;
    }

    /// <summary>
    /// ���\���^����
    /// </summary>
    /// <returns></returns>
    public Effect GetEffect() {
        return nowEffect;
    }

}