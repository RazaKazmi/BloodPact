using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameInformation
{

    public class staticVars
    {
        public static MapController mapControl;
        public static GameObject currentRoom;
        public static int currentfloor = 1;
        public static int maxFloor = 1;
        public static float souls = 0.0f;
    }

    public class entities
    {
        public static GameObject player;
    }
    public class Upgrades
    {
        //In Order
        //MaxHP
        //MaxMP
        //Melee
        //Mana
        //Cost
        //Resist
        public static int[] statcount = new int[6] { 1, 1, 1, 1, 1, 1};

    }
}
