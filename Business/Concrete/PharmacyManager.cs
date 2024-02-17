using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PharmacyManager
    {
        private IApplicantService _applicantService;

        public PharmacyManager(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        public void GiveMask(Person person)
        {
            if (_applicantService.CheckPerson(person))
            {
                Console.WriteLine(person.FirstName + " "+person.LastName+" Mernisde kayıtlı. Maske verilebilir...");
                

            }
            else
            {
                Console.WriteLine(person.FirstName +" " +person.LastName + " Kimlik bilgileri doğrulanamadı. Verdiğiniz bilgilerin doğru olduğundan emin olunuz... ");
            }

           

        }
    }
}
