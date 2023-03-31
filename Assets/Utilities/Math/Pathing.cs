using System.Collections.Generic;
using UnityEngine;

namespace Assets.GeneralScripts.Math
{
    static class Pathing
    {

        public static float PathLength(List<Vector3> points)
        {
            float pathLength = 0;
            for(int i = 1; i<points.Count; i++)
            {
                pathLength += (points[i] - points[i-1]).magnitude;
            }

            return pathLength;
        }
    }
}
