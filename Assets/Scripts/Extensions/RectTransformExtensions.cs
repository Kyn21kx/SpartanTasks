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

    /*
     * #########################
     * ANCHOR STUFF
     * #########################
     */


    public static void UseTopLeftAnchor(this RectTransform uiTransform)
    {
        uiTransform.anchorMin = Vector2.up;
        uiTransform.anchorMax = Vector2.up;
        uiTransform.pivot = Vector2.up;
    }

    public static void UseTopMiddleAnchor(this RectTransform uiTransform)
    {


        uiTransform.anchorMin = new Vector2(0.5f, 1);
        uiTransform.anchorMax = new Vector2(0.5f, 1);
        uiTransform.pivot = new Vector2(0.5f, 1);
    }


    public static void UseTopRightAnchor(this RectTransform uiTransform)
    {
        uiTransform.anchorMin = Vector2.one;
        uiTransform.anchorMax = Vector2.one;
        uiTransform.pivot = Vector2.one;
    }

    //------------Middle-------------------
    public static void UseMiddleLeftAnchor(this RectTransform uiTransform)
    {


        uiTransform.anchorMin = new Vector2(0, 0.5f);
        uiTransform.anchorMax = new Vector2(0, 0.5f);
        uiTransform.pivot = new Vector2(0, 0.5f);
    }

    public static void UseMiddleAnchor(this RectTransform uiTransform)
    {


        uiTransform.anchorMin = new Vector2(0.5f, 0.5f);
        uiTransform.anchorMax = new Vector2(0.5f, 0.5f);
        uiTransform.pivot = new Vector2(0.5f, 0.5f);
    }

    public static void UseMiddleRightAnchor(this RectTransform uiTransform)
    {


        uiTransform.anchorMin = new Vector2(1, 0.5f);
        uiTransform.anchorMax = new Vector2(1, 0.5f);
        uiTransform.pivot = new Vector2(1, 0.5f);
    }

    //------------Bottom-------------------
    public static void UseBottomLeftAnchor(this RectTransform uiTransform)
    {
        uiTransform.anchorMin = Vector2.zero;
        uiTransform.anchorMax = Vector2.zero;
        uiTransform.pivot = Vector2.zero;
    }

    public static void UseBottomMiddleAnchor(this RectTransform uiTransform)
    {


        uiTransform.anchorMin = new Vector2(0.5f, 0);
        uiTransform.anchorMax = new Vector2(0.5f, 0);
        uiTransform.pivot = new Vector2(0.5f, 0);
    }

    public static void UseBottomRightAnchor(this RectTransform uiTransform)
    {
        uiTransform.anchorMin = Vector2.right;
        uiTransform.anchorMax = Vector2.right;
        uiTransform.pivot = Vector2.right;
    }


}