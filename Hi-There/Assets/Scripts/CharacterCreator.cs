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

        private List<GameObject> currentCharacters;

        private float timeCounter;
        private float timeThreshold = 2;

        [SerializeField]
        private Sprite[] allCharacterSprites;
        private List<Sprite> availableCharacterSprites;

        private static readonly int currentCharacterLimit = 10;

        void Awake()
        {
            currentCharacters = new List<GameObject>();

            LoadSprites();

            timeCounter = 0;
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

            c.cc = this;
            c.sm = sm;

            // Determine and set character sprite
            c.SetSprite(DetermineSprite());

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