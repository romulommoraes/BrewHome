using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHome.Classes.Services
{
    public static class DICibu
    {
        public static float DefIBU30(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >=5 && tempo < 10)
            {
                return 0.055f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.1f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.137f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.167f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.192f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.212f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.229f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.242f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.253f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.263f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.270f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.276f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.285f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.291f;
            }
            else
            {
                return 0.295f;
            }
        }


        public static float DefIBU40(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.05f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.091f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.125f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.153f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.175f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.194f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.209f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.221f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.232f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.240f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.247f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.252f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.261f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.266f;
            }
            else
            {
                return 0.270f;
            }
        }

        public static float DefIBU50(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.046f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.084f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.114f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.14f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.16f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.177f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.191f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.202f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.212f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.219f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.226f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.231f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.238f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.243f;
            }
            else
            {
                return 0.247f;
            }
        }

        public static float DefIBU60(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.042f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.076f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.105f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.128f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.147f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.162f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.175f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.185f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.194f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.200f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.206f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.211f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.218f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.222f;
            }
            else
            {
                return 0.226f;
            }
        }
        public static float DefIBU70(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.038f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.070f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.096f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.117f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.134f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.148f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.160f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.169f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.177f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.183f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.188f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.193f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.199f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.203f;
            }
            else
            {
                return 0.206f;
            }
        }
        public static float DefIBU80(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.035f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.064f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.087f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.107f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.122f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.135f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.146f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.155f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.162f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.168f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.172f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.176f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.182f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.186f;
            }
            else
            {
                return 0.188f;
            }
        }

        public static float DefIBU90high(double tempo)
        {
            if (tempo < 5)
            {
                return 0.01f;
            }
            else if (tempo >= 5 && tempo < 10)
            {
                return 0.032f;
            }
            else if (tempo >= 10 && tempo < 15)
            {
                return 0.058f;
            }
            else if (tempo >= 15 && tempo < 20)
            {
                return 0.080f;
            }
            else if (tempo >= 20 && tempo < 25)
            {
                return 0.098f;
            }
            else if (tempo >= 25 && tempo < 30)
            {
                return 0.112f;
            }
            else if (tempo >= 30 && tempo < 35)
            {
                return 0.124f;
            }
            else if (tempo >= 35 && tempo < 40)
            {
                return 0.133f;
            }
            else if (tempo >= 40 && tempo < 45)
            {
                return 0.141f;
            }
            else if (tempo >= 45 && tempo < 50)
            {
                return 0.148f;
            }
            else if (tempo >= 50 && tempo < 55)
            {
                return 0.153f;
            }
            else if (tempo >= 55 && tempo < 60)
            {
                return 0.157f;
            }
            else if (tempo >= 60 && tempo < 70)
            {
                return 0.161f;
            }
            else if (tempo >= 70 && tempo < 80)
            {
                return 0.166f;
            }
            else if (tempo >= 80 && tempo < 90)
            {
                return 0.170f;
            }
            else
            {
                return 0.172f;
            }
        }


    }
}
