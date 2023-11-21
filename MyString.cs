using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAA_Lab_2
{
    internal abstract class MyString
    {
        abstract public int Length { get; }
        abstract public char this[int index] { get; }
    }
}
