# GamerProfile

![C#](https://img.shields.io/badge/C%23-.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![xUnit](https://img.shields.io/badge/xUnit-Testes%20Unit%C3%A1rios-5E2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![Git](https://img.shields.io/badge/Git-Versionamento-orange?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-Reposit%C3%B3rio-black?style=for-the-badge&logo=github&logoColor=white)
![License](https://img.shields.io/badge/Licen%C3%A7a-MIT-blue?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Conclu%C3%ADdo-brightgreen?style=for-the-badge)

Projeto desenvolvido para a disciplina de **Garantia da Qualidade de Software**, com foco na prática de **testes unitários com xUnit** em uma solução **.NET 10** criada inteiramente pela linha de comando (**.NET CLI**).

A atividade simula a implementação de um **serviço de cadastro de jogadores**, com métodos que retornam diferentes tipos de dados (`string`, `int` e `bool`), todos cobertos por testes automatizados.

Além da implementação do serviço, o principal objetivo da atividade é compreender como testes unitários ajudam a validar o comportamento esperado do código antes de ele ser entregue.

## ▸ Conceito da atividade

A atividade consiste na criação de um repositório chamado `gamer-profile-xunit` e na implementação de uma solução composta por dois projetos:

Cada projeto possui uma responsabilidade específica dentro da solução.

O projeto `GamerProfile.App` contém a classe `PerfilJogadorService`, com as regras de negócio. O projeto `GamerProfile.Tests` referencia o projeto da aplicação e valida cada uma dessas regras por meio de testes automatizados.

Essa separação simula a estrutura utilizada em projetos reais, onde o código de produção e o código de teste ficam isolados, mas conectados por uma referência.

## ▸ Camadas da solução

### `GamerProfile.App` - Código de Produção

O projeto `GamerProfile.App` é uma aplicação de console que reúne a lógica do serviço de jogadores.

Neste projeto são implementados:

- A classe `PerfilJogadorService`;
- As regras de geração de tag, cálculo de XP e elegibilidade;
- Métodos com retornos dos tipos `string`, `int` e `bool`.

É a camada que representa o comportamento real do sistema.

### `GamerProfile.Tests` - Testes Unitários

O projeto `GamerProfile.Tests` representa o ambiente de **validação automatizada**.

Neste projeto ocorre:

- A criação de testes com o atributo `[Fact]`;
- A verificação dos retornos esperados com `Assert.Equal`, `Assert.True` e `Assert.False`;
- A garantia de que as regras de negócio continuam corretas após qualquer alteração.

Os testes funcionam como uma camada de segurança entre o código escrito e a confiança de que ele se comporta como esperado.

## ▸ Serviço de Perfil do Jogador

A classe `PerfilJogadorService` é responsável por centralizar as regras relacionadas ao perfil de cada jogador.

| Método                              | Retorno  | Regra                                                         |
| ----------------------------------- | -------- | ------------------------------------------------------------- |
| `GerarTagUsuario(nickname, codigo)` | `string` | Concatena o nickname e o código com `#` (ex.: `Aragorn#1042`) |
| `CalcularXPTotal(xpFase1, xpFase2)` | `int`    | Soma o XP das duas fases e aplica um bônus fixo de 100 pontos |
| `EEligivelParaRanked(nivelJogador)` | `bool`   | Retorna `true` se o nível for maior ou igual a 15             |

**Exemplos:**

```text
GerarTagUsuario("Aragorn", "1042")  →  "Aragorn#1042"
CalcularXPTotal(200, 300)           →  600   (200 + 300 + 100)
EEligivelParaRanked(15)             →  true
EEligivelParaRanked(14)             →  false
```

## ▸ Testes unitários realizados

Foram escritos três testes na classe `PerfilJogadorServiceTests`, um para cada tipo de retorno.

| Tipo       | Método testado        | Asserção utilizada                         | O que valida                                   |
| ---------- | --------------------- | ------------------------------------------ | ---------------------------------------------- |
| **string** | `GerarTagUsuario`     | `Assert.Equal("Nickname#0000", resultado)` | Formatação correta da tag do usuário           |
| **int**    | `CalcularXPTotal`     | `Assert.Equal(valorEsperado, resultado)`   | Soma das fases e aplicação correta do bônus    |
| **bool**   | `EEligivelParaRanked` | `Assert.True(...)` e `Assert.False(...)`   | Elegibilidade para ranked a partir do nível 15 |

### Teste 1 - string

Valida se a tag é gerada no formato `Nickname#0000`, garantindo que o nickname e o código sejam unidos pelo caractere `#`.

### Teste 2 - int

Valida se o XP total é calculado corretamente, somando as duas fases e aplicando o bônus fixo de 100 pontos.

### Teste 3 - bool

Valida as regras de elegibilidade para partidas ranqueadas:

- `Assert.True(...)` para níveis a partir de 15;
- `Assert.False(...)` para níveis abaixo de 15.

## ▸ Versionamento e qualidade de software

A atividade foi desenvolvida com foco na aplicação prática de conceitos relacionados a **testes automatizados** e **versionamento de código**.

Durante o desenvolvimento, foram utilizados conceitos importantes:

| Conceito           | Aplicação no projeto                                        |
| ------------------ | ----------------------------------------------------------- |
| **Solução (.sln)** | Agrupa os projetos de aplicação e de testes                 |
| **Teste unitário** | Valida individualmente cada método do serviço               |
| **xUnit**          | Framework utilizado para escrever e executar os testes      |
| **`[Fact]`**       | Atributo que identifica um método como teste                |
| **Assert**         | Verificação do resultado obtido contra o resultado esperado |
| **Repositório**    | Armazenamento do código e da documentação do projeto        |
| **Commit**         | Registro das alterações realizadas                          |
| **Push**           | Envio das alterações para o repositório remoto              |
| **`.gitignore`**   | Evita o versionamento de arquivos gerados (`bin/`, `obj/`)  |
| **Licença MIT**    | Define as regras de uso e distribuição do código            |

A utilização dessas práticas permite acompanhar a evolução do projeto e garantir a confiabilidade do código entregue.

## ▸ Configuração via .NET CLI

Comandos utilizados para criar a estrutura da solução:

```bash
# 1. Cria a solução
dotnet new sln -n GamerProfile

# 2. Cria o projeto da aplicação (código de produção)
dotnet new console -n GamerProfile.App -f net10.0

# 3. Cria o projeto de testes unitários com xUnit
dotnet new xunit -n GamerProfile.Tests -f net10.0

# 4. Adiciona ambos os projetos à solução
dotnet sln add GamerProfile.App/GamerProfile.App.csproj
dotnet sln add GamerProfile.Tests/GamerProfile.Tests.csproj

# 5. Adiciona a referência do projeto de produção no projeto de testes
dotnet add GamerProfile.Tests/GamerProfile.Tests.csproj reference GamerProfile.App/GamerProfile.App.csproj
```

## ▸ Como executar

**Pré-requisito:** possuir o [SDK do .NET 10](https://dotnet.microsoft.com/download) instalado na máquina.

1. Clone o repositório:

```bash
git clone https://github.com/miguelalchaar/gamer-profile-xunit.git
```

2. Acesse a pasta do projeto:

```bash
cd gamer-profile-xunit
```

3. Execute os testes unitários:

```bash
dotnet test
```

**Resultado esperado:**

```text
Passed!  - Failed: 0, Passed: 3, Skipped: 0, Total: 3
```

## ▸ Licença

Este projeto está licenciado sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.

## ▸ Autor

Projeto desenvolvido pelos responsáveis pela implementação e manutenção do serviço:

- **miguelalchaar** - Desenvolvedor
