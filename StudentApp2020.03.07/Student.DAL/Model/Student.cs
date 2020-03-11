using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Student_DAL.Model
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime EntranceDate { get; set; }

        public string Email { get; set; }

        public int PhoneNumber { get; set; }

        public ObservableCollection<Book> Books { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address StudentAddress { get; set; }
    }
}