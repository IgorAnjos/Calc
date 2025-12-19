# 🧮 CalculadoraNet - Console Calculator

![.NET](https://img.shields.io/badge/.NET-8.0-blue)
![C#](https://img.shields.io/badge/C%23-12.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)

## 📖 Sobre o Projeto

**CalculadoraNet** é uma aplicação console desenvolvida em C# que demonstra a implementação dos **4 Pilares da Programação Orientada a Objetos (OOP)**: Encapsulamento, Herança, Polimorfismo e Abstração.

O projeto foi refatorado para seguir as melhores práticas de engenharia de software, oferecendo uma base sólida para aprendizado e extensibilidade.

---

## ✨ Funcionalidades

- ✅ **Adição**: Soma de dois números
- ✅ **Subtração**: Diferença entre dois números
- ✅ **Multiplicação**: Produto de dois números
- ✅ **Divisão**: Quociente ou resto da divisão
- ✅ Suporte a números decimais (double precision)
- ✅ Tratamento robusto de exceções
- ✅ Interface conversacional amigável
- ✅ Validação de entradas

---

## 🏗️ Arquitetura - 4 Pilares da OOP

### 1️⃣ **Abstração**
A classe abstrata `OperacaoBase` define o contrato que todas as operações matemáticas devem seguir:
```csharp
public abstract class OperacaoBase
{
    public abstract double Calcular();
    public virtual string ObterDescricao();
}
```

### 2️⃣ **Herança**
Todas as operações herdam de `OperacaoBase`, reutilizando código e comportamento comum:
```
OperacaoBase
    ├── Adicao
    ├── Subtracao
    ├── Multiplicacao
    └── Divisao
```

### 3️⃣ **Polimorfismo**
Cada operação implementa o método `Calcular()` de forma específica, permitindo comportamentos diferentes através da mesma interface:
```csharp
OperacaoBase operacao = new Adicao();
double resultado = operacao.Calcular(); // Comportamento polimórfico
```

### 4️⃣ **Encapsulamento**
Dados são protegidos com propriedades privadas e acesso controlado através de getters/setters:
```csharp
private double _primeiroNumero;
public double PrimeiroNumero
{
    get { return _primeiroNumero; }
    set { _primeiroNumero = value; }
}
```

---

## 📂 Estrutura do Projeto

```
CalculadoraNet/
│
├── Classe/
│   ├── OperacaoBase.cs       # Classe abstrata base
│   ├── Adicao.cs              # Implementação da adição
│   ├── Subtracao.cs           # Implementação da subtração
│   ├── Multiplicacao.cs       # Implementação da multiplicação
│   ├── Divisao.cs             # Implementação da divisão
│   └── Calculadora.cs         # Gerenciador de operações
│
├── Program.cs                 # Ponto de entrada da aplicação
├── CalculadoraNet.csproj      # Arquivo de projeto
└── CalculadoraNet.sln         # Solução Visual Studio
```

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior
- Visual Studio 2022+ ou Visual Studio Code

### Opção 1: Visual Studio
1. Abra o arquivo `CalculadoraNet.sln`
2. Pressione `F5` ou clique em "Iniciar"

### Opção 2: Linha de Comando
```bash
# Navegue até a pasta do projeto
cd CalculadoraNet

# Compile o projeto
dotnet build

# Execute a aplicação
dotnet run
```

### Opção 3: Executável Compilado
```bash
cd bin/Debug/net8.0
./CalculadoraNet.exe
```

---

## 💡 Exemplo de Uso

```
Antes de começarmos. Defina um nome para a calculadora: 
> MegaCalc

MegaCalc diz: Olá, eu me chamo MegaCalc
MegaCalc diz: E qual é o seu nome?
> João

========== Calculadora MegaCalc em C# ==========
========== Refatorada com os 4 Pilares da OOP ==========

MegaCalc diz: João, digite o primeiro número:
> 15.5

MegaCalc diz: Agora digite o segundo número:
> 3.2

MegaCalc diz: João, escolha uma operação (+, -, *, /):
> +

Adição: 15.5 + 3.2 = 18.7
Resultado: 18.7

MegaCalc diz: Deseja fazer outra operação? (S/N)
```

---

## 🔧 Tecnologias Utilizadas

- **Linguagem**: C# 12.0
- **Framework**: .NET 8.0
- **Paradigma**: Programação Orientada a Objetos
- **IDE**: Visual Studio 2022 / VS Code

---

## 📚 Conceitos Implementados

- ✅ Classes Abstratas
- ✅ Métodos Virtuais e Abstratos
- ✅ Herança de Classes
- ✅ Polimorfismo de Métodos
- ✅ Encapsulamento de Dados
- ✅ Propriedades com Getters/Setters
- ✅ Tratamento de Exceções (Try-Catch)
- ✅ Validação de Dados
- ✅ Type Checking (operador `is`)
- ✅ Coleções Genéricas (Dictionary)

---

## 🎯 Benefícios da Refatoração

| Antes | Depois |
|-------|--------|
| Métodos estáticos | Orientação a objetos completa |
| Código repetitivo | Reutilização através de herança |
| Difícil de estender | Fácil adicionar novas operações |
| Sem validação | Validações robustas |
| Apenas inteiros | Suporte a decimais |
| Tratamento básico de erros | Exceções personalizadas |

---

## 🔄 Extensibilidade

Para adicionar uma nova operação (ex: Potenciação):

1. Crie uma nova classe que herda de `OperacaoBase`:
```csharp
public class Potenciacao : OperacaoBase
{
    public override double Calcular()
    {
        return Math.Pow(PrimeiroNumero, SegundoNumero);
    }
}
```

2. Adicione à classe `Calculadora`:
```csharp
_operacoesDisponiveis.Add("^", new Potenciacao());
```

---

## 📝 Licença

Este projeto está sob a licença MIT. Sinta-se livre para usar, modificar e distribuir.

---

## 👨‍💻 Autor

Desenvolvido como projeto educacional para demonstrar os fundamentos da Programação Orientada a Objetos em C#.

---

## 🤝 Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para:
- Reportar bugs
- Sugerir novas funcionalidades
- Enviar pull requests
- Melhorar a documentação

---

## 📞 Contato

Para dúvidas ou sugestões sobre o projeto, abra uma issue no repositório.

---

**⭐ Se este projeto foi útil para você, considere dar uma estrela!**