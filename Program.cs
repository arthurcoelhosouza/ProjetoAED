using ProjetoAED.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED{
    internal class Program
    {
        static void Main(string[] args)
        {
            // TESTE
            try
            {
                using (StreamReader arqEntrada = new StreamReader("entrada.txt", Encoding.UTF8))
                {
                    string linha;

                    linha = arqEntrada.ReadLine();
                    int qtdCursos = int.Parse(linha.Split(';')[0]), qtdCandidatos = int.Parse(linha.Split(';')[1]);
                    Curso[] cursos = new Curso[qtdCursos];
                    Candidato[] candidatos = new Candidato[qtdCandidatos];

                    for (int i = 0; i < qtdCursos; i++)
                    {
                        linha = arqEntrada.ReadLine();
                        cursos[i] = new Curso(int.Parse(linha.Split(';')[0]), linha.Split(';')[1], int.Parse(linha.Split(';')[2]));
                    }

                    for (int i = 0; i < qtdCandidatos; i++)
                    {
                        linha = arqEntrada.ReadLine();
                        candidatos[i] = new Candidato(linha.Split(';')[0], double.Parse(linha.Split(';')[1]), double.Parse(linha.Split(';')[2]), double.Parse(linha.Split(';')[3]), int.Parse(linha.Split(';')[4]), int.Parse(linha.Split(';')[5]));
                    }

                    arqEntrada.Close();
                    StreamWriter arqSaida = new StreamWriter("saida.txt", false, Encoding.UTF8);

                    arqSaida.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("O arquivo não pode ser lido:\n" + e.Message);
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
