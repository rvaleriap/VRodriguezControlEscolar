﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Materia
    {
        public int IdMateria { get; set; }
        public string NombreMateria { get; set; }
        public decimal Costo { get; set; }
        public List<Object> Materias { get; set; }
    }
}
