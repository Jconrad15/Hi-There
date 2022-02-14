using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public class CreditsMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject creditsPanel;

        public void HideCredits()
        {
            creditsPanel.SetActive(false);
        }

        public void ShowCredits()
        {
            creditsPanel.SetActive(true);
        }

    }
}