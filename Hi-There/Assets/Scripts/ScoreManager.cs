using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class ScoreManager : MonoBehaviour
    {
        private int helloScore;
        private int grumpyScore;

        [SerializeField]
        private ScoreDisplay scoreDisplay;

        // Start is called before the first frame update
        void Start()
        {
            helloScore = 0;
            grumpyScore = 0;
        }

        public void AddHelloScore(int amount)
        {
            helloScore += amount;
            scoreDisplay.SetHelloScore(helloScore);
        }

        public void AddGrumpyScore(int amount)
        {
            grumpyScore += amount;
            scoreDisplay.SetGrumpinessScore(grumpyScore);
        }

    }
}