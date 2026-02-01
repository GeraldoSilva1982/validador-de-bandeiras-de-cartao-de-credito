# Gerador / Validador de Números de Cartão (Regex + Luhn)

Projeto em .NET 8 que fornece:

- Um pequeno executável que detecta a bandeira (brand) de um número de cartão (`Program.cs`).
- Utilitários reutilizáveis: `Luhn` (validação e cálculo do dígito de verificação) e `CardGenerator` (geração de números que obedecem a uma regex e passam no Luhn).

**Requisitos**

- .NET 8 SDK

**Compilar**

	dotnet build

**Uso (detecção de bandeira)**

Você pode executar o projeto passando o número do cartão como primeiro argumento ou executá-lo sem argumentos e informar pelo prompt:

	dotnet run -- 4242424242424242

Saída esperada (exemplo):

	Número: 4242424242424242
	Bandeira: Visa

Se executado sem argumentos, o programa solicita a entrada pelo terminal.

**APIs úteis (para uso em código)**

- `CardBrandDetector.Detect(string input)` — retorna a bandeira como `string` (ex.: "Visa", "Mastercard", "American Express", "Discover", "JCB", "Diners Club", ou "Unknown").
- `Luhn.IsValid(string number)` — valida um número por Luhn, retorna `bool`.
- `Luhn.CalculateCheckDigit(string partialNumber)` — calcula o dígito de verificação Luhn para um número sem o dígito final.
- `CardGenerator.Generate(string regexPattern, int length, int count, string? prefix = null)` — gera uma sequência de números que batem com a `regexPattern`, têm o `length` especificado e passam na validação Luhn. Lança `InvalidOperationException` se não conseguir gerar após muitas tentativas.


Contribuições, issues e sugestões são bem-vindas.
