using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class CharacterCreator : MonoBehaviour
    {
        [SerializeField]
        private GameObject characterPrefab;

        [SerializeField]
        private ScoreManager sm;

        [SerializeField]
        private ReactionManager rm;

        [SerializeField]
        private SoundController sc;

        private List<GameObject> currentCharacters;

        private float timeCounter;
        private float timeThreshold = 2f;

        [SerializeField]
        private Sprite[] allCharacterSprites;
        private List<Sprite> availableCharacterSprites;

        private static readonly int currentCharacterLimit = 10;

        void Awake()
        {
            currentCharacters = new List<GameObject>();

            LoadSprites();

            // Start at the threshold so that a character is immediately created
            timeCounter = timeThreshold;
        }

        private void LoadSprites()
        {
            // Add all sprites to available character list
            availableCharacterSprites = new List<Sprite>();
            for (int i = 0; i < allCharacterSprites.Length; i++)
            {
                availableCharacterSprites.Add(allCharacterSprites[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeThreshold && currentCharacters.Count <= currentCharacterLimit)
            {
                CreateCharacter();
                timeCounter -= timeThreshold;
            }
        }

        private void CreateCharacter()
        {
            GameObject char_go = Instantiate(characterPrefab, transform);
            Character c = char_go.GetComponent<Character>();

            Sprite s = DetermineSprite();
            c.SetCharacterData(this, s);

            // Register callbacks for the character
            c.RegisterOnClick(sm.AddScore);
            c.RegisterOnClick(rm.CreateReaction);
            c.RegisterOnClick(sc.OnCharacterClick);

            currentCharacters.Add(char_go);
        }

        private Sprite DetermineSprite()
        {
            if (availableCharacterSprites.Count == 0)
            {
                // Reload the character list
                LoadSprites();
            }

            // Select random sprite
            int selected = Random.Range(0, availableCharacterSprites.Count);
            Sprite s = availableCharacterSprites[selected];

            // Remove selected sprite
            availableCharacterSprites.RemoveAt(selected);

            return s;
        }

        public void RemoveCharacter(GameObject char_go)
        {
            currentCharacters.Remove(char_go);

            // If GO still exists try to destroy it
            if (char_go != null)
            {
                Destroy(char_go);
            }
        }

    }
}