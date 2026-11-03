// Gerador de confrontos - versão Rust
// Coleção obrigatória: Vec<String>
//
// Autor: Rafael Marcos Santos Baiao (RA 1252211620727)
//
// Execução (dentro da pasta rust): cargo run

fn main() {
    // Clubes definidos no código, na ordem pedida pelo enunciado.
    // "mut" permite alterar o vetor na seção 4.
    let mut clubes: Vec<String> = vec![
        String::from("Atlético-MG"),
        String::from("Cruzeiro"),
        String::from("América-MG"),
        String::from("Villa Nova"),
    ];
    processar_campeonato("Etapa 1: coleção inicial", &clubes);

    // Seção 4: o vetor cresce com push
    // len = clubes guardados | capacity = espaço reservado na memória
    println!(">> Inclusão do Tombense");
    println!("   antes do push:  len = {}, capacity = {}", clubes.len(), clubes.capacity());
    clubes.push(String::from("Tombense"));
    println!("   depois do push: len = {}, capacity = {}", clubes.len(), clubes.capacity());
    println!();
    processar_campeonato("Etapa 2: após incluir o Tombense", &clubes);

    // Seção 6: os três clubes usados no teste de mesa
    let clubes_teste_de_mesa: Vec<String> = vec![
        String::from("Atlético-MG"),
        String::from("Cruzeiro"),
        String::from("América-MG"),
    ];
    processar_campeonato("Etapa 3: teste de mesa", &clubes_teste_de_mesa);
}

// Executa os requisitos RF-01 a RF-06 para o vetor recebido
fn processar_campeonato(titulo: &str, clubes: &Vec<String>) {
    println!("==== {} ({} clubes) ====", titulo, clubes.len());
    listar_clubes(clubes);
    let ida_volta = montar_ida_volta(clubes);
    let turno_unico = montar_turno_unico(clubes);
    println!(
        "Resumo: {} clubes | ida e volta: {} | turno único: {}",
        clubes.len(),
        ida_volta,
        turno_unico
    );
    println!();
}

// RF-01: percorre o vetor mostrando o índice de cada clube
fn listar_clubes(clubes: &Vec<String>) {
    println!("[RF-01] Clubes e seus índices:");
    for posicao in 0..clubes.len() {
        println!("  índice {}: {}", posicao, clubes[posicao]);
    }
}

// RF-02: o laço externo escolhe o mandante e o interno, o visitante
// RF-03: a condição descarta o clube jogando contra ele mesmo
// RF-04: o contador só aumenta quando a partida é exibida
fn montar_ida_volta(clubes: &Vec<String>) -> usize {
    println!("[RF-02] Tabela de ida e volta (mandante x visitante):");
    let mut pares_analisados = 0;
    let mut partidas = 0;
    for mandante in 0..clubes.len() {
        for visitante in 0..clubes.len() {
            pares_analisados += 1;
            if mandante != visitante {
                partidas += 1;
                println!("  Partida {} -> {} x {}", partidas, clubes[mandante], clubes[visitante]);
            }
        }
    }
    println!("  Pares analisados: {}", pares_analisados);
    println!("[RF-04] Total de partidas de ida e volta: {}", partidas);
    partidas
}

// RF-05: só passa o par em que o índice do mandante é menor que o do
//        visitante; assim cada confronto aparece uma única vez
// RF-06: contador próprio do turno único
fn montar_turno_unico(clubes: &Vec<String>) -> usize {
    println!("[RF-05] Tabela em turno único:");
    let mut pares_analisados = 0;
    let mut partidas = 0;
    for mandante in 0..clubes.len() {
        for visitante in 0..clubes.len() {
            pares_analisados += 1;
            if mandante < visitante {
                partidas += 1;
                println!("  Partida {} -> {} x {}", partidas, clubes[mandante], clubes[visitante]);
            }
        }
    }
    println!("  Pares analisados: {}", pares_analisados);
    println!("[RF-06] Total de partidas em turno único: {}", partidas);
    partidas
}
