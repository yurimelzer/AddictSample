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
        public string name { get; set; }
        public string description { get; set; }
        public string attributes { get; set; }
        public string specification { get; set; }
        public string brand { get; set; }
        public DateTime? createdAt { get; set; }
        public DateTime? updatedAt { get; set; }
        public string tags { get; set; }

        public override bool Equals(object obj)
        {
            var produto = obj as Produto;
            return this.id.Equals(produto.id);
        }

        public override int GetHashCode()
        {
            var a = this.id;
            return Convert.ToInt32(this.id/10);
        }
    }
}
