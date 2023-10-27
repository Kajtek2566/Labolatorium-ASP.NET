using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Models
{
    public class Birth
    {
       public string Name { get; set; }
       public DateTime DateOfBirth { get; set; }

    

        public bool isValid()
        {
            return Name != null & DateOfBirth < DateTime.Now;
        }

        public int CalculateAge(DateTime birthDate)
        {
           
            DateTime currentDate = DateTime.Now;

            
            TimeSpan difference = currentDate - DateOfBirth;

            
            int age = (int)(difference.TotalDays / 365.25);

            return age;
        }
    }
}
