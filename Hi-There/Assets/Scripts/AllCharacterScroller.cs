using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HiThere
{
    public class AllCharacterScroller : MonoBehaviour
    {
        private Image image;
        private RectTransform rectTransform;

        private float startY;
        private float speed = 50f;

        void OnEnable()
        {
            image = gameObject.GetComponent<Image>();
            rectTransform = gameObject.GetComponent<RectTransform>();

            startY = rectTransform.anchoredPosition.y;
            Debug.Log(startY);
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 position = rectTransform.anchoredPosition;
            position.y -= speed * Time.deltaTime;

            rectTransform.anchoredPosition = position;

            // Check if at end, then loop
            if (position.y <= -startY)
            {
                position.y = startY;
                rectTransform.anchoredPosition = position;
            }

        }
    }
}