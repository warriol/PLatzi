﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3_1_MVC.Models
{
    public class Video : Media
    {
        public int Duracion { get; set; }

        public VideoFormato FormatoVideo { get; set; }

        public override string Medida
        {
            get
            {
                return $"{TamanoWidth}@{TamanoHeight}";
            }
        }
    }
}
