using PWA_trabalho_2b.Models.Parametros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWA_trabalho_2b.ViewModels.Parametro
{
    public class ParametroViewModel
    {
        public List<ParametroEntity> Parametros { get; set; } = new List<ParametroEntity>();
        public ParametroEntity Parametro { get; set; }
        public string MensagemSucesso { get; set; }
        public string MensagemErro { get; set; }

    }

   
}
