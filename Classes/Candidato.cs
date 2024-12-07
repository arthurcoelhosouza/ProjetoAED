using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes{
    internal class Candidato{
        private string nome;
        private double notaMedia, notaRedacao, notaMatematica, notaLinguagens;
        private int codCurso1, codCurso2;
    
        public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int codCurso1, int codCurso2) { 
            this.nome = nome;
            this.notaRedacao = notaRedacao;
            this.notaMatematica = notaMatematica;
            this.notaLinguagens = notaLinguagens;
            this.codCurso1 = codCurso1;
            this.codCurso2 = codCurso2;
            this.notaMedia = (notaRedacao + notaMatematica + notaLinguagens) / 3;
        }
        public string Nome { 
            get { return nome; } 
            set { nome = value; }
        }
        public double NotaMedia {
            get { return notaMedia; } 
            set {   notaMedia = value; } 
        }  
    }
}
