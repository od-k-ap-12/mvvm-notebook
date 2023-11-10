using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_notebook.models
{
    internal class Person
    {
        public string FullName {  get; set; }
        public string Address { get; set; }
        public string Phone {  get; set; }
        public Person(string _FullName, string _Address, string _Phone)
        {
            FullName = _FullName;
            Address = _Address;
            Phone = _Phone;
        }
    }
}
