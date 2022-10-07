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
                client.BaseAddress = new Uri("https://api.tiendanube.com/v1/");
                client.DefaultRequestHeaders.Add("Authentication", "bearer c702a62983ee8b062e5cbdf78ef4d4d93df0b469");
                client.DefaultRequestHeaders.Add("User-Agent", "Bruno");

                string url = "1573374/products";
                HttpResponseMessage response = client.GetAsync(url).Result;
                resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                //JObject jsonObject = JObject.Parse(resultContent);

                //JArray jsonProdutos = JArray.Parse(jsonObject["retorno"]["produtos"].ToString());
                JArray jsonProdutos = JArray.Parse(resultContent);

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


            return objProduto;
        }
    }
}
