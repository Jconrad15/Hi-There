using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class ReactionManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject reactionPrefab;

        [SerializeField]
        private Sprite helloSprite;

        [SerializeField]
        private Sprite grumpySprite;

        private float radius = 0.5f;
        
        public void CreateReaction(CharacterClickResult ccr, int amount, Vector2 location)
        {
            Vector2 placementLocation = location;

            // Create number of reactions for amount
            for (int i = 0; i < amount; i++)
            {
                GameObject reaction_go = Instantiate(reactionPrefab, transform);
                Reaction r = reaction_go.GetComponent<Reaction>();

                r.SetStartData(placementLocation, GetReactionSprite(ccr));

                // Determine next placement location
                placementLocation = DetermineNextPos(amount, i, placementLocation);
            }
        }

        private Vector2 DetermineNextPos(int amount, int k, Vector2 placementLocation)
        {
            Vector2 center = placementLocation;
            //center.y -= 0.5f;

            float angle = (360f / amount) * k;
            float rad = angle * Mathf.PI / 180;
            float xk = center.x + (radius * Mathf.Cos(rad));
            float yk = center.y + (radius * Mathf.Sin(rad));

            return new Vector2(xk, yk);
        }

        private Sprite GetReactionSprite(CharacterClickResult ccr)
        {
            switch (ccr)
            {
                case CharacterClickResult.HELLO:
                    return helloSprite;

                case CharacterClickResult.GRUMPY:
                    return grumpySprite;

                default:
                    Debug.LogError("Why is there no enum for CharacterClickResult?");
                    return null;
            }
        }
    }
}