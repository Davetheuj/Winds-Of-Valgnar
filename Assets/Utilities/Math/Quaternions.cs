using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Utilities.Math
{
    class Quaternions
    {
        public static Quaternion FromVector4(Vector4 vector)
        {
            return new Quaternion(vector.x, vector.y, vector.z, vector.w);
        }
    }
}
