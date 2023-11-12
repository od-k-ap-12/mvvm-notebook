using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace mvvm_notebook.models
{
    [Serializable]
    [DataContract]
    internal class Person
    {
        [DataMember]
        public string FullName {  get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string Phone {  get; set; }
        public Person(string _FullName, string _Address, string _Phone)
        {
            FullName = _FullName;
            Address = _Address;
            Phone = _Phone;
        }
    }
}
