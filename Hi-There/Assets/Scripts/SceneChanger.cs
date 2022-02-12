using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HiThere
{
    public class SceneChanger : MonoBehaviour
    {
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void GoToGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}