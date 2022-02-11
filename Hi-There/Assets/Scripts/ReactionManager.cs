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
                placementLocation = DetermineNextPos(amount, placementLocation);
            }
        }

        private Vector2 DetermineNextPos(int amount, Vector2 placementLocation)
        {
            // TODO

            return placementLocation;
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