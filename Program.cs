using ProjetoAED.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAED{
    internal class Program{
        static void Main(string[] args){

            try { 
                using(StreamReader arqEntrada = new StreamReader("entrada.txt", Encoding.UTF8)){
                    string linha;

                    linha = arqEntrada.ReadLine();
                    int qtdCursos = int.Parse(linha.Split(';')[0]), qtdCandidatos = int.Parse(linha.Split(';')[1]);
                    Curso[] cursos = new Curso[qtdCursos];
                    Candidato[] candidatos = new Candidato[qtdCandidatos];

                    for (int i = 0; i < qtdCursos; i++){ 
                        linha = arqEntrada.ReadLine();
                        cursos[i] = new Curso(int.Parse(linha.Split(';')[0]), linha.Split(';')[1], int.Parse(linha.Split(';')[2]));
                    }

                    for(int i = 0; i < qtdCandidatos; i++){
                        linha = arqEntrada.ReadLine();
                        candidatos[i] = new Candidato(linha.Split(';')[0], double.Parse(linha.Split(';')[1]), double.Parse(linha.Split(';')[2]), double.Parse(linha.Split(';')[3]), int.Parse(linha.Split(';')[4]), int.Parse(linha.Split(';')[5]));
                    }

                    arqEntrada.Close();
                    StreamWriter arqSaida = new StreamWriter("saida.txt", false, Encoding.UTF8);
                    for(int i = 0;i < qtdCandidatos;i++){
                        arqSaida.WriteLine("Nome: " + candidatos[i].Nome + " // Nota Média: " + candidatos[i].NotaMedia);
                    }
                    arqSaida.Close();
                }
            }
            catch(Exception e){
                Console.WriteLine("O arquivo não pode ser lido:\n" + e.Message);
            }
        }
    }
}
