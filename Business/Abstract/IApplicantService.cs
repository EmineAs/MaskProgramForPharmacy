using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApplicantService
    {
        void ApplyForMask(Person person);

        List<Person> GetList(List<Person> list);
        List<Person> AddList(Person person, List<Person> list);
        bool CheckPersoninList(Person person, List<Person> list);

        bool CheckPerson(Person person);

    }
}
