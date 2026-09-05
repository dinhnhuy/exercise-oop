
using System;

namespace OOP_Prog.session_04.dice_game
{
    public class Die
    {
        //data fields
        private byte face;

        public byte Face
        {
            get { return face; }
        }


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Die d = (Die)obj;
            return this.face == d.face;
        }
        public override int GetHashCode()
        {
            return this.face.GetHashCode();
        }

        public Die()
        {
            roll();
        }

        public void roll()
        {
            //miền giá trị của thuộc tinh Face 1-6
            Random rnd = new Random();
            face = (byte)rnd.Next(1, 7);
            //face = (byte)(rnd.Next(6) + 1);
        }

        public override string ToString()
        {
            string s = "";
            switch (face)
            {
                case 1: s = "Nhất"; break;
                case 2: s = "Nhị"; break;
                case 3: s = "Tam"; break;
                case 4: s = "Tứ"; break;
                case 5: s = "Ngũ"; break;
                case 6: s = "Lục"; break;
            }
            return s;
        }

    }



    class Test
    {
        /* public static void Main(string[] args)
         {
             Console.OutputEncoding = Encoding.UTF8;
             Die d = new Die();
             Console.WriteLine(d);
         }*/
    }
}
