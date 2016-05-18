using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3._1.Models
{
    public abstract class Media
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Patch { get; set; }

        public short TamanoWidth { get; set; }

        public short TamanoHeight { get; set; }

        public virtual string Medida
        {
            get
            {
                return $"{TamanoWidth}x{TamanoHeight}";
            }
        }
    }
}
