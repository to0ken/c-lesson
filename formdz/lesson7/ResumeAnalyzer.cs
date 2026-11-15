namespace ResumeAnalyzer
{
    public class Resume
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int ExperienceYears { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string FilePath { get; set; }

        public override string ToString()
        {
            return $"{Name} | {City} | Опыт: {ExperienceYears} лет | Зарплата: {Salary} руб.";
        }
    }
}
