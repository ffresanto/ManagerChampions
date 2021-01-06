using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerChampions.Models
{
    public class PremiosIndividuais
    {
        public int IdPremioIndividual { get; set; }
        public string Descricao { get; set; }
        public PremiosIndividuais()
        {
            IdPremioIndividual = 0;
            Descricao = "";
        }
    }
}