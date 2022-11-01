using Assignment_5_2.Models;

namespace Assignment_5_2.Services
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> listMember = new List<PersonModel>
        {
            new PersonModel
            {
                FirstName = "Le",
                LastName = "Thanh Dat",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 8, 21),
                BirthPlace = "Ha Noi",
                PhoneNumber = "24254535633",
                IsGraduated = false
            },
            new PersonModel
            {
                FirstName = "Nguyen",
                LastName = "Thai Duong",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 9, 8),
                BirthPlace = "Hai Phong",
                PhoneNumber = "35646567",
                IsGraduated = true
            },
            new PersonModel
            {
                FirstName = "Nguyen",
                LastName = "Tuan Tai",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 12, 1),
                BirthPlace = "Ha Noi",
                PhoneNumber = "476470942",
                IsGraduated = false
            },
        };

        public List<PersonModel> GetAll()
        {
            return listMember;
        }

        public PersonModel? GetOne(Guid id)
        {
            return listMember.SingleOrDefault(p => p.Id.Equals(id));
        }

        public PersonModel Create(PersonModel model)
        {
            listMember.Add(model);
            return model;
        }

        public PersonModel? Update(Guid id, PersonModel model)
        {
            var index = listMember.FindIndex(p => p.Id.Equals(id));
            if (index >= 0)
            {
                listMember[index] = model;
                return listMember[index];
            }
            return null;
        }

        public PersonModel? Delete(Guid id)
        {
            var index = listMember.FindIndex(p => p.Id.Equals(id));
            if (index >= 0)
            {
                var person = listMember[index];
                listMember.RemoveAt(index);
                return person;
            }
            return null;
        }
    }
}