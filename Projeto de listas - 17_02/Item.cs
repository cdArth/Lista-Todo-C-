using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_de_listas___17_02
{
    public class Item
    {
        //        Atributos: 

        //Id to tipo inteiro
        //Titulo do tipo string
        //Descricao do tipo String
        //Feito do tipo boolean

        public int id { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public Boolean feito { get; set; }

        //Construtor
        //Que recebe uma string e já atribui ao Titulo e seta Feito para false. 

        public Item(string t)
        {
            titulo = t;
            feito = false;
        }




    }

}
