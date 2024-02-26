using UnityEngine;
using UnityEngine.SceneManagement; // 引入场景管理命名空间

public class LoadSceneButton : MonoBehaviour
{
    public void LoadTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // 加载指定名称的场景
    }
}
