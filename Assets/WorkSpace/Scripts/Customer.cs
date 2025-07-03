/*
 * Date 2025年6月20日
 * programar Sum1r3
 * Customer.cs
 * お客さんの処理
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

    //制限時間設定
    float timer = -1;

    private const float _TIME_GOOD = 15;
    private const float _TIME_NOTBAD = 0;

    //public static Customer instance;

    //要求
    private Taste hopeTaste;
    private Effect hopeEffect;

    //テキストボックスの取得
    Canvas canvas;
    TextMeshProUGUI customerText;

    //停止座標、しょうめちゅ座標を宣言
    Vector3 customerPos;
    Vector3 customerEndPos;

    //必要なテキスト
    string customerName;
    string tasteText;
    string effectText;

    //移動スピード
    const float speed = 1;

    //画面外判定
    Camera camera;
    Renderer rend;

    //回転の矯正
    Vector3 lookRot = new Vector3(0, 90, 0);

    private const float DISTANCE_MIN = 0.1f; 
    private void Start() {
        Initialize();
        
    }


    public void Initialize() {
        //制限時間の設定(後々お客さんにも性格を設定してそれぞれで設定したいカモ)
        //↓ゆえに今はマジックナンバーで許してください
        timer = 30.0f;
        //デバッグ
        customerName = "やさしそうなきゃく";
       
        //ここで希望の商品を作成(この奇怪な文体は変なステートを拾わないためのモノ也)
        do {
            hopeEffect = GetRandomEnumValue<Effect>();
        } while (hopeEffect == Effect.Max);

        
        do {
            hopeTaste = GetRandomEnumValue<Taste>();
        } while (hopeTaste == Taste.None || hopeTaste == Taste.Max || hopeTaste == Taste.Chaos);

        //何回も呼び出すための物
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

        //ここで特定のゲームステートの時の挙動
        
        
        switch (state) {
            case GameState.Come:
                // ターゲット方向を計算
                Vector3 direction = (customerPos - transform.position).normalized;

                // 移動
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(customerPos);
                if (Vector3.Distance(customerPos,this.transform.position) < DISTANCE_MIN) 
                    state = GameState.Make;

                //ここで非表示
                if (canvas.enabled)
                    canvas.enabled = false;

                break;
            case GameState.Make:
                if (!canvas.enabled)
                    canvas.enabled = true;
                ChangeTextFromTaste();
                ChangeTextFromEffect();
                this.transform.LookAt(camera.transform.position);
                customerText.text = customerName + "\n" + tasteText + effectText + "スムージーをおねがい";
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
                //キャンバスを非表示にしておくよん
                if (canvas.enabled)
                    canvas.enabled = false;
                
                // ターゲット方向を計算
                direction = (customerEndPos - transform.position).normalized;

                // 移動
                transform.position += direction * speed * Time.deltaTime;
                transform.LookAt(customerEndPos);
                //ゴールに着いたらもう一個再生成して消える
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
                customerText.text = "こうかがちがうじゃないか！";
                return;
            }

            if(hopeTaste != other.GetComponent<Cop>().GetTaste()) {
                customerText.text = "あじがちがうじゃないか！";
            }

            if (timer > _TIME_GOOD) {
                customerText.text = "はやいね、ありがと";
            }
            else if(timer > _TIME_NOTBAD) {
                customerText.text = "ありがとう";
            }
            else {
                customerText.text = "おそかったけどありがと";
            }
        }
    }

    void OnGUI() {
        GUI.Label(new Rect(10, 10, 100, 20),$"{timer}");
    }

    private void ChangeTextFromTaste() {
        switch (hopeTaste) {
            case Taste.Sweet:
                tasteText = "あまい\n";
                break;
            case Taste.Spicy:
                tasteText = "からい\n";
                break;
            case Taste.Bitter:
                tasteText = "にがい\n";
                break;
            case Taste.Acid:
                tasteText = "すっぱい\n";
                break;
        }
    }

    private void ChangeTextFromEffect() {
        switch (hopeEffect) {
            case Effect.None:
                effectText = "";
                break;
            case Effect.Life:
                effectText = "げんきがもらえる\n";
                break;
            case Effect.Power:
                effectText = "ちからがつく\n";
                break;
            case Effect.Defense:
                effectText = "がんじょうになれる\n";
                break;
            case Effect.Heal:
                effectText = "きずのなおりがはやくなる\n";
                break;
            case Effect.Magic:
                effectText = "まりょくがもらえる\n";
                break;
            case Effect.Lucky:
                effectText = "うんがよくなる\n";
                break;
            
        }
    }
}