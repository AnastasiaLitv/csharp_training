﻿using System;
using System.Text;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            
            int result = Firstname.CompareTo(other.Firstname);

            if(result != 0)
            {
                return result;
            }

            return Lastname.CompareTo(other.Lastname);
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + " " + Firstname;
        }
    }
}