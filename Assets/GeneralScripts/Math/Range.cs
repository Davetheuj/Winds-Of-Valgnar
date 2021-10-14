using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.GeneralScripts.Math
{
    class Range : IEnumerable
    {
        public float min;
        public float max;

        public Range(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool isInRange(float number, bool inclusive)
        {
            if(inclusive && (number>=min && number <= max)){
                return true;
            }
            else if(!inclusive && (number>min && number<max))
            {
                return true;
            }
            
            return false;

        }
    }
}
