using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionTestApp.Models
{
    public class SortImage
    {
        public FileInfo FileInfo { get; set; }

        private string Path
        {
            get
            {
                return FileInfo.FullName;
            }
        }
        private long Length
        {
            get
            {
                return FileInfo.Length;
            }
        }
    }

    public class Temp : IEquatable<Temp>
    {
        public string Name { get; set; }
        public long Length { get; set; }



        public bool Equals(Temp temp)
        {
            if (temp == null)
            {
                return false;
            }
            else
            {
                return temp.Name == Name && temp.Length == Length;
            }
        }
    }
}
