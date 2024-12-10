using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes
{
    internal class Candidato
    {
        private string nome;
        private double notaMedia, notaRedacao, notaMatematica, notaLinguagens;
        private int codCurso1, codCurso2;
        private bool aprovado1, aprovado2;

        public Candidato(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int codCurso1, int codCurso2)
        {
            this.nome = nome;
            this.notaRedacao = notaRedacao;
            this.notaMatematica = notaMatematica;
            this.notaLinguagens = notaLinguagens;
            this.codCurso1 = codCurso1;
            this.codCurso2 = codCurso2;
            this.notaMedia = (notaRedacao + notaMatematica + notaLinguagens) / 3;
        }
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        public double NotaMedia
        {
            get { return notaMedia; }
            set { notaMedia = value; }
        }
        public double NotaRedacao
        {
            get { return notaRedacao; }
            set { notaRedacao = value; }
        }
        public double NotaMatematica
        {
            get { return notaMatematica; }
            set { notaMatematica = value; }
        }
        public double NotaLinguagens
        {
            get { return notaLinguagens; }
            set { notaLinguagens = value; }
        }
        public int CodCurso1
        {
            get { return CodCurso1; }
            set { CodCurso1 = value; }
        }
        public int CodCurso2
        {
            get { return CodCurso2; }
            set { CodCurso2 = value; }
        }
        public bool Aprovado1
        {
            get { return aprovado1; }
            set { aprovado1 = value; }
        }
        public bool Aprovado2
        {
            get { return aprovado2; }
            set { aprovado2 = value; }
        }
    }
}
