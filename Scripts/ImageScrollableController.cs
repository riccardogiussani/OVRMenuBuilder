using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ImageScrollableController : MonoBehaviour
{
    float spacing = 8f;

    int currentImage = 0;
    int numImages;

    [SerializeField] GameObject next;
    [SerializeField] GameObject prev;
    [SerializeField] GameObject container;


    // Start is called before the first frame update
    void Start()
    {
        numImages = container.GetComponentsInChildren<Transform>().Length - 2;
        prev.SetActive(false);
        SetImage(0);
    }

    public void OnNext()
    {
        currentImage += 1;

        prev.SetActive(true);
        if (currentImage >= numImages)
            next.SetActive(false);

        SetImage(+1);
    }

    public void OnPrev()
    {
        currentImage -= 1;

        next.SetActive(true);
        if (currentImage <= 0)
            prev.SetActive(false);

        SetImage(-1);
    }

    private void SetImage(int direction)
    {
        var imageAnimation = StartCoroutine(SetImageCo(direction));
    }

    private IEnumerator SetImageCo(int direction)
    {
        float duration = 3f;
        int steps = 20;
        float stepDuration = duration / steps;
        float moveAmount = - direction * (spacing / steps);

        RectTransform rectTransform = container.GetComponent<RectTransform>();

        for (int i = 0; i < steps; i++)
        {
            Vector2 offsetMin = rectTransform.offsetMin;
            Vector2 offsetMax = rectTransform.offsetMax;

            offsetMin.x += moveAmount;
            offsetMax.x += moveAmount;

            rectTransform.offsetMin = offsetMin;
            rectTransform.offsetMax = offsetMax;

            yield return new WaitForSeconds(stepDuration);
        }
    }
}
