using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes{
    internal class Curso{
        private int codCurso, qtdVagas;
        private string nome;
        private List<Candidato> listaSelecionados;
        private Fila filadeEspera;
        private double notaDeCorte;
        private int tamanhoEspera = 10;

        public Curso(int codCurso, string nome, int qtdVagas){
            this.codCurso = codCurso;
            this.qtdVagas = qtdVagas;
            this.nome = nome;
            this.listaSelecionados = new List<Candidato>();
            this.filadeEspera = new Fila(tamanhoEspera);
            this.notaDeCorte = 0.0;
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
        public double NotaDeCorte
        {
            get { return notaDeCorte; }
            set { notaDeCorte = value; }
        }

        public List<Candidato> ListaSelecionados
        {
            get { return listaSelecionados; }
        }

        public Fila FilaDeEspera
        {
            get { return filadeEspera; }
        }

        public bool EstaCheio()
        {
            return listaSelecionados.Count >= qtdVagas;
        }

        public void InserirCandidato(Candidato candidato)
        {
            if (!EstaCheio())
            {
                listaSelecionados.Add(candidato);
                AtualizarNotaDeCorte();
            }
            else
            {
                filadeEspera.Inserir(candidato);
            }
        }

        public void AtualizarNotaDeCorte()
        {
            if (listaSelecionados.Count > 0)
            {
                double menorNota = listaSelecionados[0].NotaMedia;

                foreach (var candidato in listaSelecionados)
                {
                    if (candidato.NotaMedia < menorNota)
                    {
                        menorNota = candidato.NotaMedia;
                    }
                }
                notaDeCorte = menorNota;
            }
            else
            {
                notaDeCorte = 0.0;
            }
        }

        public void ProcessarFilaDeEspera()
        {
            while (!filadeEspera.EstaVazia() && !EstaCheio())
            {
                Candidato candidato = filadeEspera.Remover();
                listaSelecionados.Add(candidato);
                AtualizarNotaDeCorte();
            }
        }

        public void Mergesort(int[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                Intercalar(array, esq, meio, dir);
            }
        }
        public void Intercalar(int[] array, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;
            int[] arrayEsq = new int[nEsq + 1];
            int[] arrayDir = new int[nDir + 1];
            arrayEsq[nEsq] = int.MaxValue;
            arrayDir[nDir] = int.MaxValue;
            int iEsq, iDir, i;
            for (iEsq = 0; iEsq < nEsq; iEsq++)
            {
                arrayEsq[iEsq] = array[esq + iEsq];
            }
            for (iDir = 0; iDir < nDir; iDir++)
            {
                arrayDir[iDir] = array[(meio + 1) + iDir];
            }
            for (iEsq = 0, iDir = 0, i = esq; i <= dir; i++)
            {
                array[i] = (arrayEsq[iEsq] <= arrayDir[iDir]) ? arrayEsq[iEsq++] : arrayDir[iDir++];
            }
        }

    }
}
