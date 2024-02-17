using Business.Abstract;
using Entities.Concrete;
using MernisServiceReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IApplicantService
    {
        public void ApplyForMask(Person person)
        {

        }

        public List<Person> GetList(List<Person> list)
        {

            foreach (Person item in list)
            {
                Console.WriteLine(item.NationalIdentity + " " + item.FirstName + " " + item.LastName + " " + item.DateofBirthYear + " " + item.LastGiveDate);
            }
            return list;

        }
        public bool CheckPerson(Person person)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            return client.TCKimlikNoDogrulaAsync(
                new TCKimlikNoDogrulaRequest
                (new TCKimlikNoDogrulaRequestBody(person.NationalIdentity, person.FirstName, person.LastName, person.DateofBirthYear)))
                .Result.Body.TCKimlikNoDogrulaResult;

        }
        


        public List<Person> AddList(Person person, List<Person> list)
        {
            PharmacyManager pharmacyManager = new PharmacyManager(new PersonManager());
            pharmacyManager.GiveMask(person);

            list.Add(new Person()
            {
                NationalIdentity = person.NationalIdentity,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateofBirthYear = person.DateofBirthYear,
                LastGiveDate = DateTime.Today
            });

            return list;
        }

        public bool CheckPersoninList(Person person, List<Person> list)
        {
            int i = 0;

            foreach (var item in list)
            {
               if(item.NationalIdentity == person.NationalIdentity)
               {
                    i++;

               }
            }
            if(i == 0)
            {
                return false;

            }
            else
            {
                return true;
            }
        }
    }
    }
