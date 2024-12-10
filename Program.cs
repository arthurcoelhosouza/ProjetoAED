using ProjetoAED.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (StreamReader arqEntrada = new StreamReader("entrada.txt", Encoding.UTF8))
                {
                    string linha;

                    linha = arqEntrada.ReadLine();
                    int qtdCursos = int.Parse(linha.Split(';')[0]), qtdCandidatos = int.Parse(linha.Split(';')[1]);
                    Dictionary<int, Curso> dicionario_curso = new Dictionary<int, Curso>();
                    Curso cursos;
                    Candidato[] candidatos = new Candidato[qtdCandidatos];

                    for (int i = 0; i < qtdCursos; i++)
                    {
                        linha = arqEntrada.ReadLine();
                        cursos = new Curso(int.Parse(linha.Split(';')[0]), linha.Split(';')[1], int.Parse(linha.Split(';')[2]));
                        dicionario_curso.Add(cursos.CodCurso, cursos);
                    }

                    for (int i = 0; i < qtdCandidatos; i++)
                    {
                        linha = arqEntrada.ReadLine();
                        candidatos[i] = new Candidato(linha.Split(';')[0], double.Parse(linha.Split(';')[1]), double.Parse(linha.Split(';')[2]), double.Parse(linha.Split(';')[3]), int.Parse(linha.Split(';')[4]), int.Parse(linha.Split(';')[5]));
                    }

                    Mergesort(candidatos, 0, candidatos.Length - 1);
                    for (int i = candidatos.Length - 1; i >= 0; i--)
                    {
                        if (dicionario_curso.TryGetValue(candidatos[i].CodCurso1, out Curso c1))
                        {
                            c1.InserirCandidato(1, candidatos[i]);
                        }
                        else if (dicionario_curso.TryGetValue(candidatos[i].CodCurso2, out Curso c2))
                        {
                            c2.InserirCandidato(2, candidatos[i]);
                        }

                        if (!candidatos[i].Aprovado1 && !candidatos[i].Aprovado2)
                        {
                            dicionario_curso.TryGetValue(candidatos[i].CodCurso1, out Curso f1);
                            dicionario_curso.TryGetValue(candidatos[i].CodCurso1, out Curso f2);
                            f1.FilaDeEspera.Inserir(candidatos[i]);
                            f2.FilaDeEspera.Inserir(candidatos[i]);
                        }
                        else if (!candidatos[i].Aprovado1 && candidatos[i].Aprovado2)
                        {
                            dicionario_curso.TryGetValue(candidatos[i].CodCurso1, out Curso f1);
                            f1.FilaDeEspera.Inserir(candidatos[i]);
                        }
                    }

                    arqEntrada.Close();

                    StreamWriter arqSaida = new StreamWriter("saida.txt", false, Encoding.UTF8);
                    foreach (Curso curso in dicionario_curso.Values)
                    {
                        arqSaida.WriteLine($"{curso.Nome} {curso.NotaDeCorte:F2}");

                        arqSaida.WriteLine("Selecionados");
                        foreach (var candidato in curso.ListaSelecionados)
                        {
                            arqSaida.WriteLine($"{candidato.Nome} {candidato.NotaMedia:F2} {candidato.NotaRedacao} {candidato.NotaMatematica} {candidato.NotaLinguagens}");
                        }

                        arqSaida.WriteLine("Fila de Espera");
                        curso.FilaDeEspera.Imprimir(arqSaida);
                        arqSaida.WriteLine();
                    }
                    arqSaida.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("O arquivo não pode ser lido:\n" + e.Message);
            }
        }
        static public void Mergesort(Candidato[] array, int esq, int dir)
        {
            if (esq < dir)
            {
                int meio = (esq + dir) / 2;
                Mergesort(array, esq, meio);
                Mergesort(array, meio + 1, dir);
                Intercalar(array, esq, meio, dir);
            }
        }
        static public void Intercalar(Candidato[] array, int esq, int meio, int dir)
        {
            int nEsq = meio - esq + 1;
            int nDir = dir - meio;

            Candidato[] arrayEsq = new Candidato[nEsq + 1];
            Candidato[] arrayDir = new Candidato[nDir + 1];

            arrayEsq[nEsq] = new Candidato("", double.MaxValue, 0, 0, 0, 0);
            arrayDir[nDir] = new Candidato("", double.MaxValue, 0, 0, 0, 0);

            for (int i = 0; i < nEsq; i++)
                arrayEsq[i] = array[esq + i];

            for (int j = 0; j < nDir; j++)
                arrayDir[j] = array[meio + 1 + j];

            int iEsq = 0, iDir = 0;
            for (int k = esq; k <= dir; k++)
            {
                if (arrayEsq[iEsq].NotaMedia < arrayDir[iDir].NotaMedia)
                {
                    array[k] = arrayEsq[iEsq++];
                }
                else if (arrayEsq[iEsq].NotaMedia > arrayDir[iDir].NotaMedia)
                {
                    array[k] = arrayDir[iDir++];
                }
                else
                {
                    if (arrayEsq[iEsq].NotaRedacao < arrayDir[iDir].NotaRedacao)
                    {
                        array[k] = arrayEsq[iEsq++];
                    }
                    else if (arrayEsq[iEsq].NotaRedacao > arrayDir[iDir].NotaRedacao)
                    {
                        array[k] = arrayDir[iDir++];
                    }
                    else
                    {
                        if (arrayEsq[iEsq].NotaMatematica <= arrayDir[iDir].NotaMatematica)
                        {
                            array[k] = arrayEsq[iEsq++];
                        }
                        else if (arrayEsq[iEsq].NotaMatematica >= arrayDir[iDir].NotaMatematica)
                        {
                            array[k] = arrayDir[iDir++];
                        }
                    }
                }
            }
        }
    }
}