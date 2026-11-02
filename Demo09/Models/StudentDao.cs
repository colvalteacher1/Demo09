namespace Demo09.Models
{
    public class StudentDao
    {
        public List<Student> Students { get; set; } = new();

        public StudentDao()
        {
            init();
        }

        private void init()
        {
            Students.AddRange(
                new Student() { Id = 1, Name = "William Leroux"},
                new Student() { Id = 2, Name = "Samuel Bédard" },
                new Student() { Id = 3, Name = "Alain Proulx" },
                new Student() { Id = 4, Name = "Annie Desrochers" }
                );
        }
    }
}
