using Assignment4_3.Models;

namespace Assignment4_3.Services
{
    public class PersonServiceExtended
    {
        private static List<MembersModel> listMember = new List<MembersModel>
        {
            new MembersModel
            {
                FirstName = "Dung",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 8, 21),
                BirthPlace = "Ha Noi",
                PhoneNumber = "24254535633",
                IsGraduated = false
            },

            new MembersModel
            {
                FirstName = "Long",
                LastName = "Le",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 9, 8),
                BirthPlace = "Hai Phong",
                PhoneNumber = "35646567",
                IsGraduated = true
            },

            new MembersModel
            {
                FirstName = "Linh",
                LastName = "Tai",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 12, 1),
                BirthPlace = "Ha Noi",
                PhoneNumber = "476470942",
                IsGraduated = false
            },

            new MembersModel
            {
                FirstName = "Quynh",
                LastName = "Do",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 9, 4),
                BirthPlace = "Ha Noi",
                PhoneNumber = "5324676879",
                IsGraduated = false
            }
        };

        public List<MembersModel> GetAll()
        {
            return listMember;
        }

        public MembersModel? GetOne(int index)
        {
            throw new NotImplementedException();
        }

        public MembersModel Create(MembersModel model)
        {
            listMember.Add(model);
            return model;
        }

        public MembersModel? Update(int index, MembersModel model)
        {
            if (index >= 0 && index < listMember.Count)
            {
                listMember[index] = model;
                return model;
            }
            return null;
        }

        public MembersModel? Delete(int index)
        {
            if (index >= 0 && index < listMember.Count)
            {
                var person = listMember[index];
                listMember.RemoveAt(index);
                return person;
            }
            return null;
        }
    }
}