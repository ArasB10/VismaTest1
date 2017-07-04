using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.Models;

namespace test1.Services
{
    interface IDataGetter
    {
        Contact AddContact(Contact contact);

        Contact GetContact(int index);

        IDictionary<int, Contact> GetContacts();

    }
}
