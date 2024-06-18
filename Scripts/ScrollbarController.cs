using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollbarController : MonoBehaviour
{
    [SerializeField] RectTransform text;
    [SerializeField] RectTransform container;
    Vector3 prevPos;

    private void Start()
    {
        prevPos = transform.localPosition;

        ResetPos();
    }

    public void LateUpdate()
    {
        if (transform.localPosition == prevPos)
            return;
        
        float height = 0f;
        if (text != null)
            height = text.rect.height - 440f;

        if (height > 0f)
        {
            float y = height * (transform.localPosition.y / -14.75f);

            if(container != null)
            {
                Vector2 newPosition = container.anchoredPosition;
                newPosition.y = y;
                container.anchoredPosition = newPosition;
            }
        }

        prevPos = transform.localPosition;
    }

    public void ResetPos()
    {
        transform.localPosition = Vector3.zero;
        if(container != null)
        {
            Vector2 newPosition = container.anchoredPosition;
            newPosition.y = 0f;
            container.anchoredPosition = newPosition;
        }
    }
}
