using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingStraight : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 100f;
    [Range(-1, 1)]
    [SerializeField] private float direction = -1;

    void Update()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition -= new Vector2(0f, direction * moveSpeed * Time.deltaTime);
    }
}
