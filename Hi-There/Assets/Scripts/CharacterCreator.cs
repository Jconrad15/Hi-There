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

        // Start is called before the first frame update
        void Start()
        {
            currentCharacters = new List<GameObject>();

            timeCounter = 0;
        }

        // Update is called once per frame
        void Update()
        {
            timeCounter += Time.deltaTime;

            if (timeCounter >= timeThreshold)
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

            currentCharacters.Add(char_go);
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