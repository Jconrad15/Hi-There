using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace HiThere
{
    public class ScoreDisplay : MonoBehaviour
    {

        [SerializeField]
        TextMeshProUGUI helloScore;

        [SerializeField]
        TextMeshProUGUI grumpinessScore;

        // Start is called before the first frame update
        void Start()
        {
            SetScoresToZero();
        }

        public void SetScoresToZero()
        {
            helloScore.SetText("Zero");
            grumpinessScore.SetText("Zero");
        }

        public void SetGrumpinessScore(int gScore)
        {
            grumpinessScore.SetText(gScore.ToString());
        }

        public void SetHelloScore(int hScore)
        {
            helloScore.SetText(hScore.ToString());
        }

    }
}