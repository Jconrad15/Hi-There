using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class Reaction : MonoBehaviour
    {
        private SpriteRenderer sr;

        private float ySpeed;
        private float yOffset = 0.5f;

        private float xVariation = 0.4f;
        private float xStartPos;

        private readonly float ageMax = 1f;
        private float ageCurrent;

        // Update is called once per frame
        void Update()
        {
            Move();
            Age();
        }

        private void Age()
        {
            ageCurrent += Time.deltaTime;

            if (ageCurrent >= ageMax)
            {
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            Vector2 currentPosition = transform.position;

            currentPosition.y += ySpeed * Time.deltaTime;

            float xChange = Mathf.PingPong(Time.unscaledTime, xVariation) - (xVariation / 2);
            currentPosition.x = xStartPos + xChange;

            transform.position = currentPosition;
        }

        public void SetStartData(Vector2 location, Sprite s)
        {
            // Offset starting Y position upwards
            location.y += yOffset;

            transform.position = location;

            sr = GetComponent<SpriteRenderer>();
            sr.sprite = s;

            ySpeed = Random.Range(0.6f, 0.8f);

            xStartPos = location.x;
            ageCurrent = 0f;
        }

    }
}