// Gerador de confrontos - versão C#
// Coleção obrigatória: List<string>
//
// Autor: Rafael Marcos Santos Baiao (RA 1252211620727)
//
// Execução (dentro da pasta csharp): dotnet run

using System;
using System.Collections.Generic;

static class Programa
{
    static void Main()
    {
        // Mostra os acentos corretamente no terminal do Windows
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Clubes definidos no código, na ordem pedida pelo enunciado
        List<string> clubes = new List<string> { "Atlético-MG", "Cruzeiro", "América-MG", "Villa Nova" };
        ProcessarCampeonato("Etapa 1: coleção inicial", clubes);

        // Seção 4: a lista cresce com Add
        // Count = clubes guardados | Capacity = tamanho do array interno da lista
        Console.WriteLine(">> Inclusão do Tombense");
        Console.WriteLine($"   antes do Add:  Count = {clubes.Count}, Capacity = {clubes.Capacity}");
        clubes.Add("Tombense");
        Console.WriteLine($"   depois do Add: Count = {clubes.Count}, Capacity = {clubes.Capacity}");
        Console.WriteLine();
        ProcessarCampeonato("Etapa 2: após incluir o Tombense", clubes);

        // Seção 6: os três clubes usados no teste de mesa
        List<string> clubesTesteDeMesa = new List<string> { "Atlético-MG", "Cruzeiro", "América-MG" };
        ProcessarCampeonato("Etapa 3: teste de mesa", clubesTesteDeMesa);
    }

    // Executa os requisitos RF-01 a RF-06 para a lista recebida
    static void ProcessarCampeonato(string titulo, List<string> clubes)
    {
        Console.WriteLine($"==== {titulo} ({clubes.Count} clubes) ====");
        ListarClubes(clubes);
        int idaVolta = MontarIdaVolta(clubes);
        int turnoUnico = MontarTurnoUnico(clubes);
        Console.WriteLine($"Resumo: {clubes.Count} clubes | ida e volta: {idaVolta} | turno único: {turnoUnico}");
        Console.WriteLine();
    }

    // RF-01: percorre a lista mostrando o índice de cada clube
    static void ListarClubes(List<string> clubes)
    {
        Console.WriteLine("[RF-01] Clubes e seus índices:");
        for (int posicao = 0; posicao < clubes.Count; posicao++)
        {
            Console.WriteLine($"  índice {posicao}: {clubes[posicao]}");
        }
    }

    // RF-02: o laço externo escolhe o mandante e o interno, o visitante
    // RF-03: a condição descarta o clube jogando contra ele mesmo
    // RF-04: o contador só aumenta quando a partida é exibida
    static int MontarIdaVolta(List<string> clubes)
    {
        Console.WriteLine("[RF-02] Tabela de ida e volta (mandante x visitante):");
        int paresAnalisados = 0;
        int partidas = 0;
        for (int mandante = 0; mandante < clubes.Count; mandante++)
        {
            for (int visitante = 0; visitante < clubes.Count; visitante++)
            {
                paresAnalisados++;
                if (mandante != visitante)
                {
                    partidas++;
                    Console.WriteLine($"  Partida {partidas} -> {clubes[mandante]} x {clubes[visitante]}");
                }
            }
        }
        Console.WriteLine($"  Pares analisados: {paresAnalisados}");
        Console.WriteLine($"[RF-04] Total de partidas de ida e volta: {partidas}");
        return partidas;
    }

    // RF-05: só passa o par em que o índice do mandante é menor que o do
    //        visitante; assim cada confronto aparece uma única vez
    // RF-06: contador próprio do turno único
    static int MontarTurnoUnico(List<string> clubes)
    {
        Console.WriteLine("[RF-05] Tabela em turno único:");
        int paresAnalisados = 0;
        int partidas = 0;
        for (int mandante = 0; mandante < clubes.Count; mandante++)
        {
            for (int visitante = 0; visitante < clubes.Count; visitante++)
            {
                paresAnalisados++;
                if (mandante < visitante)
                {
                    partidas++;
                    Console.WriteLine($"  Partida {partidas} -> {clubes[mandante]} x {clubes[visitante]}");
                }
            }
        }
        Console.WriteLine($"  Pares analisados: {paresAnalisados}");
        Console.WriteLine($"[RF-06] Total de partidas em turno único: {partidas}");
        return partidas;
    }
}
