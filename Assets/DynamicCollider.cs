using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]
public class DynamicCollider : MonoBehaviour
{
    private PolygonCollider2D polygonCollider;

    void Start()
    {
        polygonCollider = GetComponent<PolygonCollider2D>();
        AdjustCollider();
    }

    void AdjustCollider()
    {
        // 这里你需要根据实际Sprite的边缘来计算和设置顶点
        // 以下代码仅为示例，可能需要根据你的具体需求调整
        Vector2[] points = new Vector2[] {
            new Vector2(-0.5f, -0.5f),
            new Vector2(0.5f, -0.5f),
            new Vector2(0.5f, 0.5f),
            new Vector2(-0.5f, 0.5f)
        };

        polygonCollider.SetPath(0, points);
    }
}
