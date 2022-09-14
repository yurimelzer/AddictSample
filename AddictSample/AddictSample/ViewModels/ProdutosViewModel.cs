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

            produtosCollection = produtosRepository.LoadProdutosPai();
        }

        private void GetApiData()
        {
            ProdutosService produtoService = new ProdutosService();

            var listaApi = produtoService.GetProdutos(out string msgErro);
            var listaDispositivo = produtosRepository.Load();

            produtosRepository.InsertAll(listaApi.Except(listaDispositivo).ToList());
        }
    }
}
