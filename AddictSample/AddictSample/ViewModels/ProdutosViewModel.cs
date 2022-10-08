using AddictSample.Models;
using AddictSample.Repositories;
using AddictSample.WebServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AddictSample.ViewModels
{
    public class ProdutosViewModel : BindableObject
    {
        readonly ProdutosRepository produtosRepository;

        public List<Produto> produtosCollection { get; private set; }

        public ProdutosViewModel()
        {
            produtosRepository = new ProdutosRepository();

            this.GetApiData();

            produtosCollection = produtosRepository.Load();
        }

        private void GetApiData()
        {
            try
            {
                ProdutosService produtoService = new ProdutosService();

                produtosRepository.DeleteAll();

                var listaApi = produtoService.GetProdutos(out List<Variant> listVariants);
                var listaDispositivo = produtosRepository.Load();

                produtosRepository.InsertAll(listaApi.Except(listaDispositivo).ToList());

            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
