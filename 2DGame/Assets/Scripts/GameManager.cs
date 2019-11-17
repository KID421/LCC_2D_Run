using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 引用 場景管理 API
using System.Collections;

public class GameManager : MonoBehaviour
{
    public Text textLoading;
    public Image imageLoading;
    public GameObject tip;

    /// <summary>
    /// 重新開始
    /// </summary>
    /// <param name="scene">要重新開始的場景名稱</param>
    public void Replay(string scene)
    {
        // 場景管理.載入場景("場景名稱")
        SceneManager.LoadScene(scene);
    }

    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void Quit()
    {
        // 應用程式.離開
        Application.Quit();
    }

    /// <summary>
    /// 開始載入場景
    /// </summary>
    public void StartLoading()
    {
        StartCoroutine(Loading());
    }

    public IEnumerator Loading()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync("關卡1");       // 取得載入場景的資料
        ao.allowSceneActivation = false;                                // 取消載入

        while (ao.isDone == false)                                      // 當 場景尚未載入完成
        {
            textLoading.text = ao.progress / 0.9f * 100 + " / 100";     // 更新文字介面
            imageLoading.fillAmount = ao.progress / 0.9f;               // 更新吧條
            yield return null;                                          // 等待

            if (ao.progress == 0.9f)                                    // 如果 進度 == 0.9 
            {
                tip.SetActive(true);                                    // 顯示提示文字

                if (Input.anyKey) ao.allowSceneActivation = true;       // 玩家按下任意鍵 開啟載入
            }
        }
    }
}
