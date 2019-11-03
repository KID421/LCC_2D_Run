using UnityEngine;

public class Dog : MonoBehaviour
{
    #region 欄位
    // 欄位 field (變數)
    // 修飾詞 欄位類型 欄位名稱 (指定 值) 結束
    // private 私人(不顯示) public 公開(顯示)
    [Header("跳躍次數"), Range(1, 10)]
    public int jumpCount = 2;
    [Header("跳躍高度")]
    public int jump = 200;
    [Header("移動速度"), Range(0, 15.5f)]
    public float speed = 10.5f;
    [Header("是否在地板上"), Tooltip("用來判定角色有沒有站在地板上。")]
    public bool isGround;                   // true 是、false 否
    [Header("角色名稱")]
    public string characterName = "KID";

    public AudioClip soundJump, soundSlide;

    private Transform cam;
    private Animator ani;            // 動畫控制器
    private CapsuleCollider2D cc2d;  // 膠囊碰撞器
    private Rigidbody2D r2d;         // 剛體
    private AudioSource aud;         // 音源
    private SpriteRenderer sr;       // 圖片渲染
    #endregion

    #region 事件
    // 初始事件：遊戲開始執行一次
    private void Start()
    {
        //print("哈囉，沃德~");
        // GetComponent<T>() 泛型方法<T>
        ani = GetComponent<Animator>();
        cc2d = GetComponent<CapsuleCollider2D>();
        r2d = GetComponent<Rigidbody2D>();
        aud = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();

        cam = GameObject.Find("Main Camera").transform;
    }

    // 更新事件：每一禎執行一次 60fps
    private void Update()
    {
        //print("哈囉~");

        MoveDog();
        MoveCamera();
    }

    // 碰撞事件：當物件碰撞開始時執行一次
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 如果 碰到 物件 名稱 等於 "地板"
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "障礙物")
        {
            Damage();
        }
    }
    #endregion

    #region 方法
    /// <summary>
    /// 角色受傷
    /// </summary>
    private void Damage()
    {
        Debug.Log("受傷!!!");
        sr.enabled = false;
        Invoke("ShowSprite", .1f);  // 延遲調用("方法名稱"，延遲時間)
    }

    private void ShowSprite()
    {
        sr.enabled = true;
    }

    /// <summary>
    /// 狗移動方法
    /// </summary>
    private void MoveDog()
    {
        // 物件.移動(x, y, z);
        // Time.delta 為裝置一禎的時間
        //dog.Translate(speed * Time.deltaTime, 0, 0);
        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// 攝影機移動方法
    /// </summary>
    private void MoveCamera()
    {
        cam.Translate(speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// 跳躍方法
    /// </summary>
    public void Jump()
    {
        // 如果 在地板上布林值 等於 勾選
        if (isGround == true)
        {
            print("跳躍!");
            ani.SetBool("跳躍開關", true);
            r2d.AddForce(new Vector2(0, jump)); // 剛體.推力(二維向量)
            isGround = false;                   // 地板布林值 = 取消
            aud.PlayOneShot(soundJump);
        }
    }

    /// <summary>
    /// 滑行方法，縮小設定碰撞器
    /// </summary>
    public void Slide()
    {
        print("滑行");
	    ani.SetBool("滑行開關", true);
        cc2d.offset = new Vector2(-0.1f, -1f);
        cc2d.size = new Vector2(0.95f, 1f);
        aud.PlayOneShot(soundSlide, 3);
    }

    /// <summary>
    /// 重新設定跳躍與滑行布林值，重新設定碰撞器
    /// </summary>
    public void ResetAnimator()
    {
        ani.SetBool("跳躍開關", false);
        ani.SetBool("滑行開關", false);

        cc2d.offset = new Vector2(-0.1f, -0.25f);
        cc2d.size = new Vector2(0.95f, 2.5f);
    }
    #endregion
}