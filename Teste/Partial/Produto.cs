using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{
    public partial class Produto
    {
        [NotMapped]
        public string Url
        {
            get
            {
                return $"https://www.google.com/maps/@{NumLatitude},{NumLongitude},15.46z";
            }
        }
    }
}
