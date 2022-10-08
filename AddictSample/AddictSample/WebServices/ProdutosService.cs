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
        private string resultContent;
        public ProdutosService()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("https://api.tiendanube.com/v1/");
                client.DefaultRequestHeaders.Add("Authentication", "bearer c702a62983ee8b062e5cbdf78ef4d4d93df0b469");
                client.DefaultRequestHeaders.Add("User-Agent", "Bruno");

                string url = "1573374/products";
                HttpResponseMessage response = client.GetAsync(url).Result;
                resultContent = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Produto> GetProdutos(out List<Variant> listVariants)
        {
            List<Produto> listaProduto = new List<Produto>();

            listVariants = new List<Variant>();

            try
            {
                JArray jsonProdutos = JArray.Parse(resultContent);

                foreach (JObject item in jsonProdutos)
                {
                    listaProduto.Add(JsonToProduto(item));
                    JArray jsonVariants = JArray.Parse(item["variants"].ToString());
                    foreach (JObject variant in jsonVariants)
                    {
                        listVariants.Add(JsonToVariant(variant));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaProduto;
        }

        //private List<Variant> GetVariants()
        //{
        //    List<Variant> listaVariants = new List<Variant>();

        //    try
        //    {
        //        foreach (JObject item in jsonProdutos)
        //        {
        //            JArray jsonVariants = JArray.Parse(item["variants"].ToString());
        //            foreach(JObject variant in jsonVariants)
        //            {
        //                listaVariants.Add(JsonToVariant(variant));
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //    return listaVariants;
        //}
        private Produto JsonToProduto(JObject jsonProduto)
        {
            Produto objProduto = new Produto();

            JArray jsonVariants = JArray.Parse(jsonProduto["variants"].ToString());

            objProduto.id = long.Parse(jsonProduto["id"].ToString());
            objProduto.name = jsonProduto["name"]["pt"].ToString();
            objProduto.description = jsonProduto["description"].ToString();

            int stock = 0;

            foreach (JObject variant in jsonVariants)
            {
                stock += int.Parse(variant["stock"].ToString());
            }

            objProduto.stock = stock;
            objProduto.specification = jsonProduto["seo_description"]["pt"].ToString();
            objProduto.brand = jsonProduto["brand"].ToString();
            objProduto.freeShipping = bool.Parse(jsonProduto["free_shipping"].ToString());
            objProduto.createdAt = DateTime.Parse(jsonProduto["created_at"].ToString());
            objProduto.updatedAt = DateTime.Parse(jsonProduto["updated_at"].ToString());
            objProduto.tags = jsonProduto["tags"].ToString();

            return objProduto;
        }

        private Variant JsonToVariant(JObject jsonVariant)
        {
            Variant objVariant = new Variant();

            objVariant.id = long.Parse(jsonVariant["id"].ToString());
            objVariant.produtctId = long.Parse(jsonVariant["product_id"].ToString());
            objVariant.position = int.Parse(jsonVariant["position"].ToString());

            double.TryParse(jsonVariant["price"].ToString(), out double result);
            objVariant.price = result;

            double.TryParse(jsonVariant["promotional_price"].ToString(), out  result);
            objVariant.promotionalPrice = result;

            objVariant.stock = int.Parse(jsonVariant["stock"].ToString());

            double.TryParse(jsonVariant["weight"].ToString(), out  result);
            objVariant.weight = result;
            
            double.TryParse(jsonVariant["width"].ToString(), out  result);
            objVariant.width = result;

            double.TryParse(jsonVariant["height"].ToString(), out  result);
            objVariant.height = result;

            double.TryParse(jsonVariant["depth"].ToString(), out  result);
            objVariant.depth = result;

            objVariant.color = jsonVariant["values"][0]["pt"].ToString();
            objVariant.size = jsonVariant["values"][1]["pt"].ToString();
            objVariant.gender = jsonVariant["gender"].ToString();
            objVariant.barcode = jsonVariant["barcode"].ToString();

            objVariant.createdAt = DateTime.Parse(jsonVariant["created_at"].ToString());
            objVariant.updatedAt = DateTime.Parse(jsonVariant["updated_at"].ToString());

            return objVariant;
        }

    }
}
