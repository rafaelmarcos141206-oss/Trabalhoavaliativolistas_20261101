# Gerador de confrontos: Java, C# e Rust

Trabalho avaliativo de **Algoritmos e Programação** (Prof. Alexandre de Oliveira, Montanha). O mesmo algoritmo de geração de partidas foi implementado com um array em Java, uma `List<string>` em C# e um `Vec<String>` em Rust.

## Autor

| Nome completo | RA |
|---|---|
| Rafael Marcos Santos Baiao | 1252211620727 |

## Conteúdo do repositório

| Caminho | O que contém |
|---|---|
| `RELATORIO.md` | Respostas, tabelas, teste de mesa, evidências e referências |
| `java/GeradorConfrontos.java` | Versão Java (array de String) |
| `csharp/` | Versão C# (`List<string>`): `Program.cs` e `GeradorConfrontos.csproj` |
| `rust/` | Versão Rust (`Vec<String>`): `src/main.rs` e `Cargo.toml` |
| `evidencias/` | Prints das execuções |

## Como executar

Todos os comandos partem da raiz do repositório.

**Java** (JDK 8 ou superior):

```bash
cd java
javac -encoding UTF-8 GeradorConfrontos.java
java GeradorConfrontos
```

**C#** (SDK do .NET 8 ou superior):

```bash
cd csharp
dotnet run
```

**Rust** (Rust e Cargo instalados pelo rustup):

```bash
cd rust
cargo run
```

Cada programa executa três etapas: os quatro clubes iniciais, a coleção depois da inclusão do Tombense e os três clubes usados no teste de mesa.

## Observações

- As pastas de compilação (`bin`, `obj`, `target`) e os arquivos `.class` estão no `.gitignore` e não são enviados.
- Se os acentos aparecerem trocados no terminal do Windows ao rodar o Java, execute `chcp 65001` antes e rode `java "-Dfile.encoding=UTF-8" "-Dstdout.encoding=UTF-8" GeradorConfrontos`. No PowerShell, as aspas são necessárias porque, sem elas, o argumento é dividido no ponto.
