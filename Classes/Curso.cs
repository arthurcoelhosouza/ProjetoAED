using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes{
    internal class Curso{
        private int codCurso, qtdVagas;
        private string nome;
        public Curso(int codCurso, string nome, int qtdVagas){
            this.codCurso = codCurso;
            this.qtdVagas = qtdVagas;
            this.nome = nome;
        }
        public int CodCurso{ 
            get { return codCurso; }
            set { codCurso = value; }
        }
        public int QtdVagas{
            get { return qtdVagas; }
            set { qtdVagas = value; }
        }
        public string Nome{
            get { return nome; }
            set { nome = value; }
        }
    }
}
