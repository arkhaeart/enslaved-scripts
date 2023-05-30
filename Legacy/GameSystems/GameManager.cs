using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameSystems
{
    public class GameManager 
    {
        //public List<string> interactableTags = new List<string>();




        public void ChangeLevel(LevelExit exit)
        {

            SceneManager.LoadScene(exit.levelTo, LoadSceneMode.Single);
        }
    }
}