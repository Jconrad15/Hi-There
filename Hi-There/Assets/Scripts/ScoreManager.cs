using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public enum EndCondition { WIN, LOSE };

    public class ScoreManager : MonoBehaviour
    {
        private int helloScore;
        private int grumpyScore;

        [SerializeField]
        private ScoreDisplay scoreDisplay;

        private readonly int winCondition = 10;
        private readonly int loseCondition = 20;

        private Action<EndCondition> cbEndGame;

        // Start is called before the first frame update
        void Start()
        {
            helloScore = 0;
            grumpyScore = 0;
        }

        public void AddScore(CharacterClickResult ccr, int amount, Vector2 location)
        {
            if (ccr == CharacterClickResult.HELLO)
            {
                AddHelloScore(amount);
            }
            else
            {
                AddGrumpyScore(amount);
            }
        }

        private void AddHelloScore(int amount)
        {
            helloScore += amount;
            scoreDisplay.SetHelloScore(helloScore);

            // Check win condition
            if (helloScore >= winCondition) { Win(); }
        }

        private void AddGrumpyScore(int amount)
        {
            grumpyScore += amount;
            scoreDisplay.SetGrumpinessScore(grumpyScore);

            if (grumpyScore >= loseCondition) { Lose(); }
        }

        private void Win()
        {
            cbEndGame.Invoke(EndCondition.WIN);
        }

        private void Lose()
        {
            cbEndGame.Invoke(EndCondition.LOSE);
        }

        public void RegisterOnEndGame(Action<EndCondition> callbackFunc)
        {
            cbEndGame += callbackFunc;
        }

        public void UnregisterOnEndGame(Action<EndCondition> callbackFunc)
        {
            cbEndGame -= callbackFunc;
        }

    }
}