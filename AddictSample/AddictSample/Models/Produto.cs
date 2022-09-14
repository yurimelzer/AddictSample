using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddictSample.Models
{
    public class Produto
    {
        [PrimaryKey]
        public long id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string tipo { get; set; }
        public string situacao { get; set; }
        public string unidade { get; set; }
        public double preco { get; set; }
        public double precoCusto { get; set; }
        public string descricaoCurta { get; set; }
        public string descricaoComplementar { get; set; }
        public DateTime? dataInclusao { get; set; }
        public DateTime? dataAlteracao { get; set; }
        public string imageThumbnail { get; set; }
        public string urlVideo { get; set; }
        public string nomeFornecedor { get; set; }
        public string codigoFabricante { get; set; }
        public string marca { get; set; }
        public int origem { get; set; }
        public int idGrupoProduto { get; set; }
        public string linkExterno { get; set; }
        public string observacoes { get; set; }
        public string grupoProduto { get; set; }
        public int garantia { get; set; }
        public string descricaoFornecedor { get; set; }
        public long idFabricante { get; set; }
        public long idCategoria { get; set; }
        public double pesoLiq { get; set; }
        public double pesoBruto { get; set; }
        public double estoqueMinimo { get; set; }
        public double estoqueMaximo { get; set; }
        public int larguraProduto { get; set; }
        public int alturaProduto { get; set; }
        public int profundidadeProduto { get; set; }
        public string unidadeMedida { get; set; }
        public int itensPorCaixa { get; set; }
        public int volumes { get; set; }
        public string localizacao { get; set; }
        public int crossdocking { get; set; }
        public string condicao { get; set; }
        public bool freteGratis { get; set; }
        public string producao { get; set; }
        public DateTime? dataValidade { get; set; }
        public string codigoPai { get; set; }
        public bool isProdutoPai { get; set; }
    }
}
