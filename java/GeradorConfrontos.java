/*
 * Gerador de confrontos - versão Java
 * Coleção obrigatória: array de String (String[])
 *
 * Autor: Rafael Marcos Santos Baiao (RA 1252211620727)
 *
 * Execução (dentro da pasta java):
 *   javac -encoding UTF-8 GeradorConfrontos.java
 *   java GeradorConfrontos
 */
public class GeradorConfrontos {

    public static void main(String[] args) {
        // Clubes definidos no código, na ordem pedida pelo enunciado
        String[] clubes = {"Atlético-MG", "Cruzeiro", "América-MG", "Villa Nova"};
        processarCampeonato("Etapa 1: coleção inicial", clubes);

        // Seção 4: um array não muda de tamanho, então outro array é criado
        System.out.println(">> Inclusão do Tombense");
        System.out.println("   array original: length = " + clubes.length);
        clubes = acrescentarClube(clubes, "Tombense");
        System.out.println("   array novo:     length = " + clubes.length);
        System.out.println();
        processarCampeonato("Etapa 2: após incluir o Tombense", clubes);

        // Seção 6: os três clubes usados no teste de mesa
        String[] clubesTesteDeMesa = {"Atlético-MG", "Cruzeiro", "América-MG"};
        processarCampeonato("Etapa 3: teste de mesa", clubesTesteDeMesa);
    }

    // Cria um array com uma posição a mais, copia os clubes com um laço
    // e grava o novo clube na última posição
    static String[] acrescentarClube(String[] origem, String novoClube) {
        String[] destino = new String[origem.length + 1];
        for (int posicao = 0; posicao < origem.length; posicao++) {
            destino[posicao] = origem[posicao];
        }
        destino[origem.length] = novoClube;
        return destino;
    }

    // Executa os requisitos RF-01 a RF-06 para a coleção recebida
    static void processarCampeonato(String titulo, String[] clubes) {
        System.out.println("==== " + titulo + " (" + clubes.length + " clubes) ====");
        listarClubes(clubes);
        int idaVolta = montarIdaVolta(clubes);
        int turnoUnico = montarTurnoUnico(clubes);
        System.out.println("Resumo: " + clubes.length + " clubes | ida e volta: " + idaVolta
                + " | turno único: " + turnoUnico);
        System.out.println();
    }

    // RF-01: percorre o array mostrando o índice de cada clube
    static void listarClubes(String[] clubes) {
        System.out.println("[RF-01] Clubes e seus índices:");
        for (int posicao = 0; posicao < clubes.length; posicao++) {
            System.out.println("  índice " + posicao + ": " + clubes[posicao]);
        }
    }

    // RF-02: o laço externo escolhe o mandante e o interno, o visitante
    // RF-03: a condição descarta o clube jogando contra ele mesmo
    // RF-04: o contador só aumenta quando a partida é exibida
    static int montarIdaVolta(String[] clubes) {
        System.out.println("[RF-02] Tabela de ida e volta (mandante x visitante):");
        int paresAnalisados = 0;
        int partidas = 0;
        for (int mandante = 0; mandante < clubes.length; mandante++) {
            for (int visitante = 0; visitante < clubes.length; visitante++) {
                paresAnalisados++;
                if (mandante != visitante) {
                    partidas++;
                    System.out.println("  Partida " + partidas + " -> "
                            + clubes[mandante] + " x " + clubes[visitante]);
                }
            }
        }
        System.out.println("  Pares analisados: " + paresAnalisados);
        System.out.println("[RF-04] Total de partidas de ida e volta: " + partidas);
        return partidas;
    }

    // RF-05: só passa o par em que o índice do mandante é menor que o do
    //        visitante; assim cada confronto aparece uma única vez
    // RF-06: contador próprio do turno único
    static int montarTurnoUnico(String[] clubes) {
        System.out.println("[RF-05] Tabela em turno único:");
        int paresAnalisados = 0;
        int partidas = 0;
        for (int mandante = 0; mandante < clubes.length; mandante++) {
            for (int visitante = 0; visitante < clubes.length; visitante++) {
                paresAnalisados++;
                if (mandante < visitante) {
                    partidas++;
                    System.out.println("  Partida " + partidas + " -> "
                            + clubes[mandante] + " x " + clubes[visitante]);
                }
            }
        }
        System.out.println("  Pares analisados: " + paresAnalisados);
        System.out.println("[RF-06] Total de partidas em turno único: " + partidas);
        return partidas;
    }
}
