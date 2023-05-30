using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;
namespace GameSystems
{
    public class LevelManager 
    {
        public Player player;
        public int currentLevel;
        public List<LevelExit> exits;

        public LevelExit GetExit(int number)
        {
            foreach (LevelExit ex in exits)
            {
                if (ex.entrance == number)
                    return ex;
            }
            throw new System.Exception("invalid entrance ID");
        }
    }
}