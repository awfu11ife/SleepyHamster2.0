using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveData
{
    [System.Serializable]
    public class SoundsData
    {
        public bool IsButtonMute;

        public SoundsData()
        {
            IsButtonMute = false;
        }
    }
}

