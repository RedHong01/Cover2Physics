using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TriggerAreaStay : MonoBehaviour
{
    public string targetTag = "Player"; // 触发事件的对象标签
    public GameObject objectToActivate; // 在Inspector中指定要激活的GameObject
    public string sceneToLoad = "NextScene"; // 要加载的场景名称
    public float requiredStayTime = 3f; // 必需的停留时间
    public float waitTime = 2.0f; // 在Inspector中设置等待时间


    private float stayTimer = 0f; // 跟踪停留时间
    private bool isInsideTrigger = false; // 标记对象是否处于触发区域内

    void Update()
    {
        // 如果对象仍然在触发区内，增加计时器
        if (isInsideTrigger)
        {
            stayTimer += Time.deltaTime;
            if (stayTimer >= requiredStayTime)
            {
                StartCoroutine(WaitAndLoadScene(waitTime)); // 等待指定的时间然后加载场景
                objectToActivate.SetActive(true); // 激活指定的GameObject

                // 避免重复加载场景
                isInsideTrigger = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInsideTrigger = true; // 对象进入触发区域
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            isInsideTrigger = false; // 对象离开触发区域
            stayTimer = 0f; // 重置计时器
        }
    }
    IEnumerator WaitAndLoadScene(float waitTime)
    {
        yield return new WaitForSeconds(waitTime); // 等待
        SceneManager.LoadScene(sceneToLoad); // 加载场景
    }
}
