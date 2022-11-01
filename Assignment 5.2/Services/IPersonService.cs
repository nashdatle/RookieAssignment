using Assignment_5_2.Models;

namespace Assignment_5_2.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();

        PersonModel? GetOne(Guid id);

        PersonModel Create(PersonModel model);

        PersonModel? Update(Guid id, PersonModel model);

        PersonModel? Delete(Guid id);
    }
}