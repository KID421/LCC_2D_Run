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
    [Header("移動速度"), Range(1.5f, 15.5f)]
    public float speed = 10.5f;
    [Header("是否在地板上"), Tooltip("用來判定角色有沒有站在地板上。")]
    public bool isGround;                   // true 是、false 否
    [Header("角色名稱")]
    public string characterName = "KID";

    public Transform dog, cam;
    #endregion

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
}