using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komponenten.ET
{
    public class Admin : Benutzer
    {
        public String Name { get; set; }

        public Admin(String passwort, String name) : base(passwort)
        {
            Name = name;
        }

        public Admin()
        { }

    }
}
