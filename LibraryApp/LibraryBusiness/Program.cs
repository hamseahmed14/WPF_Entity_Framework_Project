using LibraryApp;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryBusiness
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Run this to create an Admin account
            // CRUDManager _crudManger = new CRUDManager();
            //_crudManger.CreateMember("Admin", "Admin", "Admin", "Test@Test.com", "000000", "0", "Test", "Test", "Test", $"{Crypto.Encrypt("password")}");


            ///Populate Books
            ////
            //Book book1 = new Book() 
            //{
            //    AuthorId = 1,
            //    Title = "Harry Potter and the Order of the Phoenix",
            //    Genre = "Fantasy",
            //    Description = "Harry is in his fifth year at Hogwarts School as the adventures continue. There is a door at the end of a silent corridor. And it's haunting Harry Potter's dreams. Why else would he be waking in the middle of the night, screaming in terror? Harry has a lot on his mind for this, his fifth year at Hogwarts: a Defence Against the Dark Arts teacher with a personality like poisoned honey; a big surprise on the Gryffindor Quidditch team; and the looming terror of the Ordinary Wizarding Level exams.    But all these things pale next to the growing threat of He-Who-Must-Not-Be-Named, one that neither the magical government nor the authorities at Hogwarts can stop. As the grasp of darkness tightens, Harry must discover the true depth and strength of his friends, the importance of boundless loyalty, and the shocking price of unbearable sacrifice. His fate depends on them all.    The book that took the world by storm. In his fifth year at Hogwarts, Harry faces challenges at every turn, from the dark threat of He-Who-Must-Not-Be-Named and the unreliability of the government of the magical world to the rise of Ron Weasley as the Keeper of the Gryffindor Quidditch Team. Along the way he learns about the strength of his friends, the fierceness of his enemies, and the meaning of sacrifice.",
            //    Available = 5,
            //    Quantity = 5,
            //    ImageSrc = "Book_Images/HarryPotterOrderOfPhoenixImage.jpg"
            //};

            //_crudManger.CreateBook(book1);

            //Book book2 = new Book()
            //{
            //    AuthorId = 1,
            //    Title = "Harry Potter and the Goblet of Fire",
            //    Genre = "Fantasy",
            //    Description = "Harry Potter is in his fourth year at Hogwarts. Harry wants to get away from the pernicious Dursleys and go to the Quidditch World Cup with Hermione, Ron, and the Weasleys. He wants to find out about the mysterious event to take place at Hogwarts this year, an event involving two other rival schools of magic, and a competition that hasn't happened for hundreds of years. He wants to be a normal, fourteen-year-old wizard. But unfortunately for Harry Potter, he's not normal - not even by Wizarding standards. And in his case, different can be deadly.",
            //    Available = 3,
            //    Quantity = 3,
            //    ImageSrc = "Book_Images/HarryPotterAndGobletOfFireImage.jpg"
            //};
            //_crudManger.CreateBook(book2);

            //Book book3 = new Book()
            //{
            //    AuthorId = 1,
            //    Title = "Harry Potter and the Goblet of Fire",
            //    Genre = "Fantasy",
            //    Description = "Harry Potter has never played a sport while flying on a broomstick. He's never worn a Cloak of Invisibility, befriended a half-giant, or helped hatch a dragon. All Harry knows is a miserable life with the Dursleys: his horrible aunt and uncle and their abominable son, Dudley. Harry's room is a tiny Cupboard Under the Stairs, he hasn't had a birthday party in ten years, and his birthday present is his uncle's old socks.    But all that is about to change when a mysterious letter arrives by owl messenger. A letter with an invitation to a wonderful place he never dreamed existed. There he finds not only friends, aerial sports, and magic around every corner, but a great destiny that's been waiting for him... if Harry can survive the encounter."   + "Until now there's been no magic for Harry Potter. He lives with the miserable Dursleys and their abominable son, Dudley. Harry''s room is a tiny closet beneath the stairs,and he hasn't had a birthday party in ten years. Then a mysterious letter arrives by owl messenger. A letter with an invitation to an incredible place called Hogwarts School of Witchcraft and Wizardry. There he finds not only friends, flying sports on broomsticks, and magic in everything from classes to meals.    Harry Potter thinks he is an ordinary boy - until he is rescued by a beetle-eyed giant of a man, enrols at Hogwarts School of Witchcraft and Wizardry, learns to play Quidditch, and does battle in a deadly duel. The Reason, Harry Potter is a wizard!"  +  "Plot",
            //    Available = 10,
            //    Quantity = 10,
            //    ImageSrc = "Book_Images/HarryPotterPhilosoperStoneNewImage.jpg"
            //};
            //_crudManger.CreateBook(book3);


            //Book book4 = new Book()
            //{
            //    AuthorId = 4,
            //    Title = "A Scandal in Bohemia",
            //    Genre = "Mystery",
            //    Description = "On 20 March 1888, Dr. Watson is visiting Sherlock Holmes when a masked gentleman arrives at 221B Baker Street. Initially introducing himself as Count von Kramm, he reveals himself as Wilhelm Gottsreich Sigismond von Ormstein, Grand Duke of Cassel-Felstein and hereditary King of Bohemia, after Holmes deduces his true identity. The King explains that, five years earlier, he engaged in a secret relationship with American opera singer Irene Adler, who has since retired and now lives in London. He is set to marry a young Scandinavian princess but worries that her strictly principled family will call the marriage off should they learn of this impropriety.    The King further explains that he seeks to regain a photograph of Adler and himself together which he gave to her as a token. His agents have failed to recover the photograph through various means, and an offer to pay for it was also refused. With Adler now threatening to send the photograph to his fiancée's family, the King requests Holmes and Watson's help in recovering it.",
            //    Available = 3,
            //    Quantity = 3,
            //    ImageSrc = "Book_Images/ScandalInBohemia.jpg"
            //};
            //_crudManger.CreateBook(book4);


        }
    }
}
