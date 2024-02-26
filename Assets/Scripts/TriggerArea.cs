using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerArea : MonoBehaviour
{
    public string targetTag = "Player"; // 在Inspector中设置期望触发的GameObject的标签
    public GameObject objectToActivate; // 在Inspector中指定要激活的GameObject
    public float waitTime = 2.0f; // 在Inspector中设置等待时间
    public string sceneToLoad = "NextScene"; // 在Inspector中设置要加载的场景名称

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检查进入触发区的对象是否具有指定的标签
        if (other.CompareTag(targetTag))
        {
            objectToActivate.SetActive(true); // 激活指定的GameObject
            StartCoroutine(WaitAndLoadScene(waitTime)); // 等待指定的时间然后加载场景
        }
    }

    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 等待
        SceneManager.LoadScene(sceneToLoad); // 加载场景
    }
}
