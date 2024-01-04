using UnityEngine;

public static class RectTransformExtensions {

    public static void SetHeight(this RectTransform transform, float height)
    {
        transform.sizeDelta = new Vector2(transform.rect.width, height);
    }

    public static float GetHeight(this RectTransform transform) => transform.rect.height;

    public static void SetWidth(this RectTransform transform, float width)
    {
        transform.sizeDelta = new Vector2(width, transform.rect.height);
    }

}