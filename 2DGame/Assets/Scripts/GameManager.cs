using UnityEngine;
using UnityEngine.SceneManagement;  // 引用 場景管理 API

public class GameManager : MonoBehaviour
{
    public void Replay()
    {
        // 場景管理.載入場景("場景名稱")
        SceneManager.LoadScene("關卡1");
    }

    public void Quit()
    {
        // 應用程式.離開
        Application.Quit();
    }
}
