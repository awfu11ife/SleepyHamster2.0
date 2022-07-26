using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    [System.Serializable]
    public class LevelProgressData
    {
        public int NumberOfCollectedStars;

        public LevelProgressData()
        {
            NumberOfCollectedStars = 0;
        }
    }
}
