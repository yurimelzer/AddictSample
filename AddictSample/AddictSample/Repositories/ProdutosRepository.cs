using AddictSample.Models;
using AddictSample.PlatformServices;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AddictSample.Repositories
{
    public class ProdutosRepository
    {
        private SQLiteConnection sqlConnection;

        public ProdutosRepository()
        {
            this.sqlConnection = DependencyService.Get<IDatabaseConnection>().DbConnection();
            this.sqlConnection.CreateTable<Produto>();
        }

        public List<Produto> Load()
        {
            return (from produto in sqlConnection.Table<Produto>() orderby produto.dataInclusao select produto).ToList();
        }

        public List<Produto> LoadProdutosPai()
        {
            return (from produto in sqlConnection.Table<Produto>() orderby produto.dataInclusao where produto.isProdutoPai select produto).ToList();
        }

        public Produto Get(long id)
        {
            return sqlConnection.Get<Produto>(id);
        }

        public void InsertAll(List<Produto> produtosList)
        { 
            sqlConnection.InsertAll(produtosList);
        }

        public void Insert(Produto produto)
        {
            sqlConnection.Insert(produto);
        }

        public void Update(Produto produto)
        {
            sqlConnection.Update(produto);
        }

        public void Delete(Produto produto)
        {
            sqlConnection.Delete(produto);
        }

        public void DeleteAll()
        {
            sqlConnection.DeleteAll<Produto>();
        }
    }
}
