using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Model;

namespace ServerMock
{
    class Program
    {   

        static void Main(string[] args)
        {
            Helpers helper = new Helpers();

            try{

                List<PersonnelModel> personnel = await helper.LoadPersonnelInfoAsync();
                List<LoginModel> loginInfo = await helper.LoadLoginInfoAsync();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error was thrown");
            }
        }

    }
}
