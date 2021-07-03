using System;
using UnityEngine;

namespace Game
{
    public class Pause : UnityEngine.MonoBehaviour
    {
        public GameObject pauseMenu;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseMenu.active = !pauseMenu.active;
                if (pauseMenu.active)
                {
                    Time.timeScale = 0f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }
        }
        
    }
}