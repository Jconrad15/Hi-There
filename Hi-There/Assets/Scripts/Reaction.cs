using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class Reaction : MonoBehaviour
    {
        private SpriteRenderer sr;

        private float speed;
        private float xVariation = 1f;
        private float xStartPos;
        private readonly float ageMax = 2f;
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

            currentPosition.y += speed * Time.deltaTime;

            float xChange = Mathf.PingPong(Time.deltaTime, xVariation) - (xVariation / 2);
            currentPosition.x  = xStartPos + xChange;
        }

        public void SetStartData(Vector2 location, Sprite s)
        {
            transform.position = location;

            sr = GetComponent<SpriteRenderer>();
            sr.sprite = s;

            speed = Random.Range(0.6f, 0.8f);

            xStartPos = location.x;
            ageCurrent = 0f;
        }

    }
}