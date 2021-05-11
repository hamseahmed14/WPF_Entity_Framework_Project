using System;

namespace LibraryBusiness
{
    class Program
    {
        static void Main(string[] args)
        {

            var m = new MemberCRUDManager();

            m.CreateMember("Hamse","Ahmed","hamse-27@hotmail.com","21A","London Road","leicester","LE8 0SU");
        }
    }
}
