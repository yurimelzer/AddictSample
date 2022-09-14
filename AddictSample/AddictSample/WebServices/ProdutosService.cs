using AddictSample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace AddictSample.WebServices
{
    public class ProdutosService
    {
        public List<Produto> GetProdutos(out string msgErro)
        {
            List<Produto> listaProduto = new List<Produto>();

            msgErro = string.Empty;
            string resultContent = string.Empty;

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://bling.com.br/Api/v2/");

                string url = "produtos/json&apikey=bcdb35e619750e6d70b5c04ec25eddb8e562c9895dd619701c3070423d3bf10aa99f6a44";
                HttpResponseMessage response = client.GetAsync(url).Result;
                resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                JObject jsonObject = JObject.Parse(resultContent);

                JArray jsonProdutos = JArray.Parse(jsonObject["retorno"]["produtos"].ToString());

                foreach (var item in jsonProdutos)
                {
                    JObject jsonProduto = item.ToObject<JObject>();
                    string strJson = jsonProduto.ToString();

                    jsonProduto = JObject.Parse(jsonProduto["produto"].ToString());

                    listaProduto.Add(JsonToProduto(jsonProduto));
                }
            }
            catch (Exception ex)
            {
                msgErro = ex.Message;
            }

            return listaProduto;
        }

        private Produto JsonToProduto(JObject jsonProduto)
        {
            Produto objProduto = new Produto();

            objProduto.id = long.Parse(jsonProduto["id"].ToString());
            objProduto.codigo = jsonProduto["codigo"].ToString();
            objProduto.descricao = jsonProduto["descricao"].ToString();
            objProduto.tipo = jsonProduto["tipo"].ToString();
            objProduto.situacao = jsonProduto["situacao"].ToString();
            objProduto.unidade = jsonProduto["unidade"].ToString();
            objProduto.preco = double.Parse(jsonProduto["preco"].ToString());
            objProduto.precoCusto = double.Parse(jsonProduto["precoCusto"].ToString());
            objProduto.descricaoCurta = jsonProduto["descricaoCurta"].ToString();
            objProduto.descricaoComplementar = jsonProduto["descricaoComplementar"].ToString();
            objProduto.dataInclusao = DateTime.Parse(jsonProduto["dataInclusao"].ToString());
            objProduto.dataAlteracao = DateTime.Parse(jsonProduto["dataAlteracao"].ToString());
            objProduto.imageThumbnail = jsonProduto["imageThumbnail"].ToString();
            objProduto.urlVideo = jsonProduto["urlVideo"].ToString();
            objProduto.nomeFornecedor = jsonProduto["nomeFornecedor"].ToString();
            objProduto.codigoFabricante = jsonProduto["codigoFabricante"].ToString();
            objProduto.marca = jsonProduto["marca"].ToString();
            objProduto.origem = int.Parse(jsonProduto["origem"].ToString());
            objProduto.idGrupoProduto = int.Parse(jsonProduto["idGrupoProduto"].ToString());
            objProduto.linkExterno = jsonProduto["linkExterno"].ToString();
            objProduto.observacoes = jsonProduto["observacoes"].ToString();
            objProduto.grupoProduto = jsonProduto["grupoProduto"].ToString();
            objProduto.garantia = int.Parse(jsonProduto["garantia"].ToString());
            objProduto.descricaoFornecedor = jsonProduto["descricaoFornecedor"].ToString();

            long idFabricante = 0;
            long.TryParse(jsonProduto["idFabricante"].ToString(), out idFabricante);
            objProduto.idFabricante = idFabricante;

            objProduto.idCategoria = long.Parse(jsonProduto["categoria"]["id"].ToString());
            objProduto.pesoLiq = double.Parse(jsonProduto["pesoLiq"].ToString());
            objProduto.pesoBruto = double.Parse(jsonProduto["pesoBruto"].ToString());
            objProduto.estoqueMinimo = double.Parse(jsonProduto["estoqueMinimo"].ToString());
            objProduto.estoqueMaximo = double.Parse(jsonProduto["estoqueMaximo"].ToString());
            objProduto.larguraProduto = int.Parse(jsonProduto["larguraProduto"].ToString());
            objProduto.alturaProduto = int.Parse(jsonProduto["alturaProduto"].ToString());
            objProduto.profundidadeProduto = int.Parse(jsonProduto["profundidadeProduto"].ToString());
            objProduto.unidadeMedida = jsonProduto["unidadeMedida"].ToString();
            objProduto.itensPorCaixa = int.Parse(jsonProduto["itensPorCaixa"].ToString());
            objProduto.volumes = int.Parse(jsonProduto["volumes"].ToString());
            objProduto.localizacao = jsonProduto["localizacao"].ToString();
            objProduto.crossdocking = int.Parse(jsonProduto["crossdocking"].ToString());
            objProduto.condicao = jsonProduto["condicao"].ToString();

            if (jsonProduto["freteGratis"].ToString() == "S")
                objProduto.freteGratis = true;
            else
                objProduto.freteGratis = false;

            objProduto.producao = jsonProduto["producao"].ToString();

            DateTime dataValidade = DateTime.MaxValue;
            DateTime.TryParse(jsonProduto["dataValidade"].ToString(), out dataValidade);
            objProduto.dataValidade = dataValidade;

            objProduto.isProdutoPai = true;
            if (jsonProduto["codigoPai"] != null)
            {
                objProduto.codigoPai = jsonProduto["codigoPai"].ToString();
                objProduto.isProdutoPai = false;
            }

            return objProduto;
        }
    }
}
