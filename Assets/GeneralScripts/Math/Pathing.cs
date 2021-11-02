using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.GeneralScripts.Math
{
    static class Pathing
    {

        public static float PathLength(List<Vector3> points)
        {
            float pathLength = 0;
            Debug.Log(points.Count);
            for(int i = 1; i<points.Count; i++)
            {
                pathLength += (points[i] - points[i-1]).magnitude;
            }

            return pathLength;
        }
    }
}
