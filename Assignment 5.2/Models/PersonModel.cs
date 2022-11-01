namespace Assignment_5_2.Models
{
    public class PersonModel
    {
        private Guid _id;
        public Guid Id
        {
            get
            {
                if (_id == Guid.Empty) _id = Guid.NewGuid();
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public bool IsGraduated { get; set; }
        public int Age
        {
            get
            {
                return DateTime.Now.Year - DateOfBirth.Year;
            }
        }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}