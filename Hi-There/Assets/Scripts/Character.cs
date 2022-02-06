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

        private Queue<Vector3> wayPoints;
        private Vector3 currentDestination;

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

            startPosition = SideToRandomPos(startSide);
            endPosition = SideToRandomPos(endSide);

            // Determine waypoints
            wayPoints = new Queue<Vector3>();
            int points = Random.Range(1, 5);
            for (int i = 0; i < points; i++)
            {
                float x = Random.Range(-World.halfWidth + 1, World.halfWidth - 1);
                float y = Random.Range(-World.halfHeight + 1, World.halfHeight - 1);

                Vector3 waypoint = new Vector3(x, y, 0);

                wayPoints.Enqueue(waypoint);
            }

            // Set current posititon to start position
            transform.position = startPosition;

            // Set first destination 
            currentDestination = wayPoints.Dequeue();
        }

        /// <summary>
        /// Returns a random position along the provided side.
        /// </summary>
        /// <param name="side"></param>
        /// <returns></returns>
        private Vector3 SideToRandomPos(World.Side side)
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
            Vector3 newPos = speed * Time.deltaTime * Vector3.Normalize(currentDestination - currentPos);

            // Set new position
            transform.position = newPos + currentPos;

            // Has character reached current destination
            if ((currentDestination - currentPos).magnitude < 0.05)
            {
                // Check if this is the end position
                if (currentDestination == endPosition)
                {
                    RemoveCharacter();
                }
                else if (wayPoints.Count == 0)
                {
                    // No more waypoints, then set destination to end position
                    currentDestination = endPosition;
                }
                else
                {
                    // Get next waypoint
                    currentDestination = wayPoints.Dequeue();
                }
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