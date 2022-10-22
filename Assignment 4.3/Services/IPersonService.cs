using Assignment4_3.Models;

namespace Assignment4_3.Services
{
    public interface IPersonService
    {
        List<MembersModel> GetAll();

        MembersModel? GetOne(int index);

        MembersModel Create(MembersModel model);

        MembersModel? Update(int index, MembersModel model);

        MembersModel? Delete(int index);
    }
}