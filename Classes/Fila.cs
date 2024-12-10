using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED.Classes
{
    internal class Fila
    {
        private Candidato[] fila;
        private int inicio, fim;

        public Fila(int capacidade)
        {
            fila = new Candidato[capacidade + 1];
            inicio = fim = 0;
        }
        public void Inserir(Candidato candidato)
        {
            if (((fim + 1) % fila.Length) == inicio)
            {
                return;
            }
            fila[fim] = candidato;
            fim = (fim + 1) % fila.Length;
        }
        /*public Candidato Remover()
        {
            if (inicio == fim)
            {
                return null;
            }
            inicio = (inicio + 1) % fila.Length;
        }*/
        public bool EstaVazia()
        {
            if (inicio == fim)
            {
                return true;
            }
            return false;
        }
    }
}
