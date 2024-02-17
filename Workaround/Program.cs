
using Business.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Workaround
{
    class Program
    {
        static void Main(string[] args)
        {

            bool b;
            TimeSpan timeSpan;

            List<Person> list = new List<Person>();

            Console.WriteLine("****************************************");
            Console.WriteLine("* Maske Takip Programına Hoşgeldiniz...*");
            Console.WriteLine("****************************************");


            list.Add(new Person()
            {
                NationalIdentity=123,
                FirstName="Ayşe",
                LastName="yılmaz",
                DateofBirthYear=1980,
                LastGiveDate=new DateTime(2024,02,15)

            });



            Person person = new Person();
            person.NationalIdentity = 11786610796;
            

            PersonManager personManager = new PersonManager();
            b= personManager.CheckPersoninList(person,list);

            if(b) 
            {
                Console.WriteLine("Bu Kişi daha önce sisteme girilmiş...");

                int index = list.FindIndex(x => x.NationalIdentity==person.NationalIdentity);

                timeSpan = DateTime.Today- list[index].LastGiveDate;

                if (timeSpan.Days > 7)
                {
                    Console.WriteLine("Yeni Maske verilebilir. Maske verme tarihi güncelleniyor...");
                    list[index].LastGiveDate=DateTime.Today;    
                }
                else
                {
                    Console.WriteLine("Maske alalı " + timeSpan.Days + " gün olmuş. Maske verilemez...");
                }

            }
            else
            {
                person.FirstName = "Emine";
                person.LastName = "Aşçı";
                person.DateofBirthYear = 1979;
                list = personManager.AddList(person, list);
            }



            personManager.GetList(list);
            





        }
    }






}


