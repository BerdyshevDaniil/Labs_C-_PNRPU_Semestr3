using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using System.Xml;

namespace FunctionalCompleteness_Lab4
{
    public class Function
    {
        static int maxLength = 8;
        static int minLength = 2;
        List<int> values;
        public List<int> Values
        {
            get { return values; }
            set { if (value.Count <= 8)
                    values = value; }
        }
        public Function() 
        { 
            Values = new List<int>();
        }
        public Function(List<int> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                values.Add(l[i]);
            }
        }

        public bool IsT0()
        {
            if (Values[0] == 0)
                return true;
            return false;
        }
        public bool IsT1()
        {
            if (Values[Values.Count - 1] == 1)
                return true;
            return false;
        }
        public bool IsTSelfDual()
        {
            for (int i = 0; i < Values.Count / 2; i++)
            {
                if (Values[i] == Values[Values.Count - i - 1])
                    return false;
            }
            return true;
        }
        public bool IsTMonotonous()
        {
            for (int i = 0; i < Values.Count - 1; i++)
            {
                if (Values[i] > Values[i + 1])
                    return false;
            }
            return true;
        }
        public bool IsTLinear()
        {
            int C0 = Values[0], Cx, Cy, Cz, Cxy, Cxz, Cyz, Cxyz;
            if (Values.Count == 2)
            {
                return true;
            }
            if (Values.Count == 4)
            {
                int iX = Values[2];
                int iY = Values[1];
                int iXY = Values[3];
                Cx = Mod2(C0, iX);
                Cy = Mod2(C0, iY);
                Cxy = Mod2(Mod2(Mod2(C0, Cx), Cy), iXY);
                if (Cxy == 1)
                    return false;
            }
            if (Values.Count == 8)
            {
                int iX = Values[4];
                int iY = Values[2];
                int iZ = Values[1];
                int iYZ = Values[3];
                int iXZ = Values[5];
                int iXY = Values[6];
                int iXYZ = Values[7];
                Cx = Mod2(C0, iX);
                Cy = Mod2(C0, iY);
                Cz = Mod2(C0, iZ);
                Cxy = Mod2(Mod2(Mod2(C0, Cx), Cy), iXY);
                Cxz = Mod2(Mod2(Mod2(C0, Cx), Cz), iXZ);
                Cyz = Mod2(Mod2(Mod2(C0, Cy), Cz), iYZ);
                Cxyz = Mod2(Mod2(Mod2(Mod2(Mod2(Mod2(Mod2(C0, Cx), Cy), Cz), Cxy), Cxz), Cyz), iXYZ);
                if (Cxy == 1 || Cxz == 1 || Cyz == 1 || Cxyz == 1)
                    return false;
            }
            return true;
        }
        int Mod2(int x, int y)
        {
            if (x == y)
                return 0;
            return 1;
        }
    }
}
