using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class EndScreenDisplay : MonoBehaviour
    {
        [SerializeField]
        private ScoreManager sm;

        [SerializeField]
        private GameObject winPanel;

        [SerializeField]
        private GameObject losePanel;

        void OnEnable()
        {
            sm.RegisterOnEndGame(EndGame);
        }

        private void EndGame(EndCondition endCondition)
        {
            switch (endCondition)
            {
                case EndCondition.WIN:
                    winPanel.SetActive(true);
                    losePanel.SetActive(false);
                    return;

                case EndCondition.LOSE:
                    winPanel.SetActive(false);
                    losePanel.SetActive(true);
                    return;
            }
        }


    }
}