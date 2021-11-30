using System;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allNames;
        private string allEmails;
        private string allElements;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public string Firstname { get; set; }
        
        public string Lastname { get; set; }

        public string Middlename { get; set; }

        public string Nickname { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }
       
        public string Email2 { get; set; }
        
        public string Email3 { get; set; }

        public string HomePage { get; set; }

        public string Birthday { get; set; }

        public string Anniversary { get; set; }

        public string SecondaryAddress { get; set; }

        public string Home { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }

        public string AllPhones
        {
            get {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(Mobile)).Trim();
                }
            }
            set { 
               allPhones = value;
            }
        }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    var result = "";
                    if (!string.IsNullOrEmpty(Email))
                    {
                        result += Email;
                    }

                    if (!string.IsNullOrEmpty(Email2))
                    {
                        result += " " + Email2;
                    }

                    if (!string.IsNullOrEmpty(Email3))
                    {
                        result += " " + Email3;
                    }

                    return result;
                }
            }
            set
            {
                allEmails = value;
            }
        }
        public string AllNames
        {
            get
            {
                if (allNames != null)
                {
                    return allNames;
                }
                else
                {
                    return Firstname + " " + Middlename + " " + Lastname;
                }
            }
            set
            {
                allNames = value;
            }
        }

        public string AllElements
        {
            get
            {
                if (allElements != null)
                {
                    return allElements;
                }
                else
                {
                    var result = Firstname;
                    if (!string.IsNullOrEmpty(Middlename))
                    {
                        result += " " + Middlename;
                    }

                    if (!string.IsNullOrEmpty(Lastname))
                    {
                        result += " " + Lastname;
                    }

                    result += "\r\n";

                    if (!string.IsNullOrEmpty(Nickname))
                    {
                        result += Nickname + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Title))
                    {
                        result += Title + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Company))
                    {
                        result += Company + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Address))
                    {
                        result += Address + "\r\n";
                    }

                    result += "\r\n";

                    if (!string.IsNullOrEmpty(HomePhone))
                    {
                        result += "H: " + HomePhone + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Mobile))
                    {
                        result += "M: " + Mobile + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Work))
                    {
                        result += "W: " + Work + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Fax))
                    {
                        result += "F: " + Fax + "\r\n";
                    }

                    result += "\r\n";

                    if (!string.IsNullOrEmpty(Email))
                    {
                        result += Email + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Email2))
                    {
                        result += Email2 + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Email3))
                    {
                        result += Email3 + "\r\n";
                    }


                    if (!string.IsNullOrEmpty(HomePage))
                    {
                        result += "Homepage:  " + HomePage + "\r\n";
                    }


                    if (!string.IsNullOrEmpty(Birthday))
                    {
                        result += "Birthday: " + Birthday + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Anniversary))
                    {
                        result += "Anniversary: " + Anniversary + "\r\n";
                    }

                    result += "\r\n";

                    if (!string.IsNullOrEmpty(SecondaryAddress))
                    {
                        result += SecondaryAddress + "\r\n";
                    }

                    result += "\r\n";

                    if (!string.IsNullOrEmpty(Home))
                    {
                        result += "P: " + Home + "\r\n";
                    }

                    if (!string.IsNullOrEmpty(Notes))
                    {
                        result += Notes;
                    }

                    return result;
                }
            }
            set
            {
                allElements = value;
            }
        }

        private string CleanUp(string phone)
        {
            if(phone == null || phone == "")
            {
                return "";
            }

            return  Regex.Replace(phone, "[  ()-]", "") + "\r\n";
        }

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
            return "lastname=" + Lastname + "\nfirstname=" + Firstname + "\nmiddlename=" + Middlename + "\ntitle=" + Title
                + "\nnickname=" + Nickname + "\naddress=" + Address + "\nhomePhone=" + HomePhone + "\nnotes=" + Notes
                + "\nmobile=" + Mobile + "\nemail=" + Email + "\nemail2=" + Email2 + "\nemail3=" + Email3; 
        }
    }
}