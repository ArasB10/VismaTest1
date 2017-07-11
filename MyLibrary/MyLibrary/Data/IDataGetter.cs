using MyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Data
{
    public interface IDataGetter
    {
        Contact AddContact(Contact contact);

        Contact GetContact(int index);

        void Remove(int index);

        void Update(int id, Contact contact);

        IDictionary<int, Contact> GetContacts();

    }
}
