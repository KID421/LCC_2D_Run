using UnityEngine;

public class Dog : MonoBehaviour
{
    #region 欄位區域
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

    public Transform dog, cam;
    public Animator ani;            // 動畫控制器
    public CapsuleCollider2D cc2d;
    #endregion

    #region 事件
    // 初始事件：遊戲開始執行一次
    private void Start()
    {
        //print("哈囉，沃德~");
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
    #endregion

    #region 方法
    /// <summary>
    /// 狗移動方法。
    /// </summary>
    private void MoveDog()
    {
        // 物件.移動(x, y, z);
        // Time.delta 為裝置一禎的時間
        dog.Translate(speed * Time.deltaTime, 0, 0);
    }

    /// <summary>
    /// 攝影機移動方法。
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
        print("跳躍!");
        ani.SetBool("跳躍開關", true);
    }

    /// <summary>
    /// 滑行方法，縮小設定碰撞器
    /// </summary>
    public void Slide()
    {
        print("滑行");
	    ani.SetBool("滑行開關", true);
        cc2d.offset = new Vector2(-0.1f, -0.9f);
        cc2d.size = new Vector2(0.95f, 1.1f);
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