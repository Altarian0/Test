using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTestApp.Models
{
    public class Volunteer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string CountryCode { get; set; }
        public string Gender { get; set; }

        static Volunteer ParseRow(string row)
        {
            var columns = row.Split(new char[] { ',' });
            return new Volunteer
            {
                Id = int.Parse(columns[0]),
                Name = columns[1],
                LastName = columns[2],
                CountryCode = columns[3],
                Gender = columns[4]
            };
        }

        public static List<Volunteer> ParseVolunteer(string path)
        {
            return File.ReadAllLines(path).Skip(1).Where(n=>n.Length > 0).Select(Volunteer.ParseRow).ToList();
        }
    }
}
