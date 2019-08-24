using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste.Models
{

    [Table("produto")]
    public partial class Produto {
       
        [Column("COD_GTIN")]
        public string CodGtin { get; set; }
        [Column("DAT_EMISSAO")]
        public string DataEmissao { get; set; }
        [Column("COD_TIPO_PAGAMENTO")]
        public string CodTipoPagamento { get; set; }
        [Column("COD_PRODUTO")]
        public int CodProduto { get; set; }
        [Column("COD_NCM")]
        public int CodNcm { get; set; }
        [Column("COD_UNIDADE")]
        public string CodUnidade { get; set; }
        [Column("DSC_PRODUTO")]
        public string DscProduto { get; set; }
        [Column("VLR_UNITARIO")]
        public float VlrUnitario { get; set; }
        [Column("ID_ESTABELECIMENTO")]
        public int IdEstabelecimento { get; set; }
        [Column("NME_ESTABELECIMENTO")]
        public string NmeEstabelecimento { get; set; }
        [Column("NME_LOGRADOURO")]
        public string NmeLogradouro { get; set; }
        [Column("COD_NUMERO_LOGRADOURO")]
        public int CodNumeroLogradouro { get; set; }
        [Column("NME_COMPLEMENTO")]
        public string NmeComplemento { get; set; }
        [Column("NME_BAIRRO")]
        public string NmeBairro { get; set; }
        [Column("COD_MUNICIPIO_IBGE")]
        public int CodMunicipioIbge { get; set; }
        [Column("NME_MUNICIPIO")]
        public string NmeMunicipio { get; set; }
        [Column("NME_SIGLA_UF")]
        public string NmeSigleUf { get; set; }
        [Column("COD_CEP")]
        public int CodCep { get; set; }
        [Column("NUM_LATITUDE")]
        public string NumLatitude { get; set; }
        [Column("NUM_LONGITUDE")]
        public string NumLongitude { get; set; }
        [Column("ID")]
        public int Id { get; set; }

    }
}
