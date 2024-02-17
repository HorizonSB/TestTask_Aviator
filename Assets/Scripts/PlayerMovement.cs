using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 touchStartPos;
    private bool isDragging = false;

    [SerializeField] private float minXLimit = -100f; 
    [SerializeField] private float maxXLimit = 100f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isDragging = true;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                float horizontalDelta = touch.position.x - touchStartPos.x;

                RectTransform rectTransform = GetComponent<RectTransform>();
                float newXPos = Mathf.Clamp(rectTransform.anchoredPosition.x + horizontalDelta, minXLimit, maxXLimit);
                rectTransform.anchoredPosition = new Vector2(newXPos, rectTransform.anchoredPosition.y);

                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
