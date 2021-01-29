using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Assign27Jan
{
    [Serializable]
    class BinSerialize

    {
        public int birthyear;


        public BinSerialize(int year)
            {
                birthyear = year;
            }

            public int CalculateAge()
            {
                return (int)DateTime.Now.Year - birthyear;
            }
        }
class program
        {
            static void Main(String[] args)
            {
                Console.WriteLine("Enter Your Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Your Birth Year(YYYY):");
                var inYear = Convert.ToInt32(Console.ReadLine());


                BinSerialize bs = new BinSerialize(inYear);
                FileStream fs = new FileStream(@"E:\Age.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, bs);
                fs.Seek(0, SeekOrigin.Begin);
                var res = (BinSerialize)bf.Deserialize(fs);
                Console.WriteLine("The Age of {1} Person is :{0}", res.CalculateAge(), name);



            }
        }
    }






        