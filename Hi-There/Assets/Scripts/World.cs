using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HiThere
{
    public static class World
    {
        public static float height = 11f;
        public static float width = 11f;

        public static float halfHeight = height / 2;
        public static float halfWidth = width / 2;

        public enum Side { Up, Down, Left, Right };

        public static Side GetOppositeSide(Side sideA)
        {
            switch (sideA)
            {
                case Side.Up:
                    return Side.Down;

                case Side.Down:
                    return Side.Up;

                case Side.Left:
                    return Side.Right;

                case Side.Right:
                    return Side.Left;

                default:
                    Debug.LogError("Why is there no opposite side?");
                    return Side.Up;
            }
        }

    }
}