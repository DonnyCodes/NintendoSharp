using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NintendoSharp.Control
{
    public class UserScript
    {
        public string name;
        public string versionID;
        public string author;
        public string description;

        public virtual void Load()
        {

        }
        public virtual void Unload()
        {

        }
        public virtual void Start()
        {

        }
        public virtual void Stop()
        {

        }
        public virtual void GUI()
        {

        }
    }
}
