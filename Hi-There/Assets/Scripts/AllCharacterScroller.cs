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
        private readonly float scrollSpeed = 50f;
        private readonly float colorSpeed = 0.8f;

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
            Move();
            ChangeColor();
        }

        /// <summary>
        ///  Moves the character sheet down across the screen 
        /// </summary>
        private void Move()
        {
            Vector2 position = rectTransform.anchoredPosition;
            position.y -= scrollSpeed * Time.deltaTime;

            rectTransform.anchoredPosition = position;

            // Check if at end, then loop
            if (position.y <= -startY)
            {
                position.y = startY;
                rectTransform.anchoredPosition = position;
            }
        }

        private void ChangeColor()
        {
            Color32 currentColor = image.color;

            currentColor = Utility.HueShift(currentColor, colorSpeed * Time.deltaTime);

            image.color = currentColor;
        }
    }
}