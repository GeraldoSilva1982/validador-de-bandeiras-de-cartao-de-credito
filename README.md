# Gerador / Validador de Números de Cartão (Regex + Luhn)

Este é um utilitário simples em .NET 8 que gera e valida números de cartão de crédito usando expressões regulares e o algoritmo de Luhn.

Uso básico:

- Gerar: `dotnet run -- --generate --regex '^4\\d{15}$' --length 16 --count 5`
- Validar: `dotnet run -- --validate --number 4242424242424242 --regex '^4\\d{15}$'`

Opções relevantes:
- `--generate` : modo geração
- `--validate` : modo validação
- `--regex <pattern>` : expressão regular usada para filtrar números gerados / validar formato
- `--length <n>` : comprimento (em dígitos) do número (padrão 16)
- `--count <n>` : quantos números gerar (padrão 1)
- `--prefix <digits>` : prefixo fixo para os números gerados

Observações:
- O gerador produz números aleatórios e os filtra pela regex e pela validade Luhn. Se a regex for muito restritiva pode falhar — ajuste `--prefix`/`--length` ou a regex.
