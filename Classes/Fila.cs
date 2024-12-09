using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes {
    internal class Fila {
        private Candidato[] fila;
        private int inicio, fim, tamanhoAtual, capacidade;

        public Fila(int capacidade) {
            this.capacidade = capacidade;
            fila = new Candidato[capacidade];
            inicio = 0;
            fim = -1;
            tamanhoAtual = 0;
        }

        public void Inserir(Candidato candidato)
        {
            if (EstaCheia()) { return; }

            fim = (fim + 1) % capacidade;
            fila[fim] = candidato;
            tamanhoAtual++;
        }

        public void Remover()
        {
            if (EstaVazia()) { return; }

            Candidato candidato = fila[inicio];
            inicio = (inicio + 1) % capacidade;
            tamanhoAtual--;
        }

        public bool EstaCheia()
        {
            if (tamanhoAtual == capacidade) { return true; }
        }

        public bool EstaVazia()
        {
            if (tamanhoAtual == 0) { return true; }
        }

        public int TamanhoAtual()
        {
            return tamanhoAtual;
        }
    }
}
