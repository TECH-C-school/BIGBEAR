using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Game07
{
    public class Bomb : FallItemBase, IScoreItem
    {
        public int GetScore()
        {
            return -10;
        }
    }
}