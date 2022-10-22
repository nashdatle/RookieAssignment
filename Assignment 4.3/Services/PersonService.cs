using Assignment4_3.Models;

namespace Assignment4_3.Services
{
    public class PersonService : IPersonService
    {
        private static List<MembersModel> listMember = new List<MembersModel>
        {
            new MembersModel
            {
                FirstName = "Le",
                LastName = "Thanh Dat",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 5, 19),
                BirthPlace = "Nghe An",
                PhoneNumber = "0123456789",
                IsGraduated = false
            },

            new MembersModel
            {
                FirstName = "Tran",
                LastName = "Thuy Trang",
                Gender = "Female",
                DateOfBirth = new DateTime(1997, 9, 8),
                BirthPlace = "Ha Noi",
                PhoneNumber = "0123456789",
                IsGraduated = true
            },

            new MembersModel
            {
                FirstName = "Le",
                LastName = "Do",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 12, 1),
                BirthPlace = "Ha Noi",
                PhoneNumber = "0123456789",
                IsGraduated = false
            }
        };

        public List<MembersModel> GetAll()
        {
            return listMember;
        }

        public MembersModel? GetOne(int index)
        {
            if (index >= 0 && index < listMember.Count)
            {
                return listMember[index];
            }
            return null;
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