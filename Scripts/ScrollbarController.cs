using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollbarController : MonoBehaviour
{
    [SerializeField] RectTransform text;
    Vector3 prevPos;

    private void Start()
    {
        prevPos = transform.localPosition;

        ResetPos();
    }

    private void LateUpdate()
    {
        if (transform.localPosition == prevPos)
            return;

        float delta = transform.localPosition.y - prevPos.y;

        Vector2 newPosition = text.anchoredPosition;
        newPosition.y = text.anchoredPosition.y - delta * 50f;
        text.anchoredPosition = newPosition;

        prevPos = transform.localPosition;
    }

    public void ResetPos()
    {
        transform.localPosition = Vector3.zero;
    }
}
