using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class Character : MonoBehaviour
    {
        private int clickCount;
        private Vector3 startPosition;
        private Vector3 endPosition;

        private float speed;

        private readonly float minSpeed = 0.6f;
        private readonly float maxSpeed = 2f;

        public CharacterCreator cc;
        public ScoreManager sm;

        private SpriteRenderer spriteRenderer;

        void OnEnable()
        {
            clickCount = 0;

            DeterminePositions();
            speed = Random.Range(minSpeed, maxSpeed);

            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        /// <summary>
        /// Determines the start and end positions of the character.
        /// </summary>
        private void DeterminePositions()
        {
            // First choose start and end positions
            World.Side startSide = Utility.GetRandomEnum<World.Side>();
            World.Side endSide = World.GetOppositeSide(startSide);

            startPosition = SideToPos(startSide);
            endPosition = SideToPos(endSide);

            // Set current posititon to start position
            transform.position = startPosition;
        }

        /// <summary>
        /// Returns a random position along the provided side.
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        private Vector3 SideToPos(World.Side side)
        {
            switch (side)
            {
                case World.Side.Up:
                    return new Vector3(
                        Random.Range(-World.halfWidth, World.halfWidth), World.halfHeight, 0);

                case World.Side.Down:
                    return new Vector3(
                        Random.Range(-World.halfWidth, World.halfWidth), -World.halfHeight, 0);

                case World.Side.Left:
                    return new Vector3(
                        -World.halfWidth, Random.Range(-World.halfHeight, World.halfHeight), 0);

                case World.Side.Right:
                    return new Vector3(
                        World.halfWidth, Random.Range(-World.halfHeight, World.halfHeight), 0);

                default:
                    Debug.LogError("Why is there no startSide?");
                    return new Vector3(0, 0, 0);
            }
        }

        void Update()
        {
            Move();
        }

        /// <summary>
        /// Move the character.
        /// </summary>
        private void Move()
        {
            // Get current position
            Vector3 currentPos = transform.position;

            Vector3 newPos = speed * Time.deltaTime * Vector3.Normalize(endPosition - currentPos);

            // Set new position
            transform.position = newPos + currentPos;

            // If the character reaches the endposition
            if ((endPosition - currentPos).magnitude < 0.05)
            {
                RemoveCharacter();
            }
        }

        private void OnMouseDown()
        {
            // If click count is still zero, then this is the first time saying hello!
            // Add score
            if (clickCount == 0)
            {
                sm.AddHelloScore(1);
            }
            else
            {
                // Add grumpy score since you said hello too many times
                sm.AddGrumpyScore(clickCount);
            }
            
            // Increase click count
            clickCount += 1;
        }

        public void SetSprite(Sprite s)
        {
            spriteRenderer.sprite = s;
        }

        private void RemoveCharacter()
        {
            if (cc == null)
            {
                Destroy(gameObject);
                Debug.LogError(this.name.ToString() + " had no cc." );
            }

            cc.RemoveCharacter(gameObject);
        }
    }
}