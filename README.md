<div align="center">

# DESAFIO TÉCNICO

### 𝗧𝗔𝗥𝗚𝗘𝗧 𝗦𝗜𝗦𝗧𝗘𝗠𝗔𝗦

`C#` &nbsp;·&nbsp; `.NET` &nbsp;·&nbsp; `JSON`

</div>

<br>

```text
┌──────────────────────────────────────────────┐
│                                              │
│   Questão 1  ·  Comissão de Vendedores       │
│   Questão 2  ·  Controle de Estoque          │
│   Questão 3  ·  Cálculo de Juros             │
│                                              │
└──────────────────────────────────────────────┘
```

<br>

## 𝗤𝗨𝗘𝗦𝗧Ã𝗢 𝟭 | 𝗖𝗢𝗠𝗜𝗦𝗦Ã𝗢 𝗗𝗘 𝗩𝗘𝗡𝗗𝗘𝗗𝗢𝗥𝗘𝗦

A primeira questão parte dos registros de `vendas.json` para calcular a comissão acumulada de cada vendedor.

Cada venda passa por uma das três faixas:

```text
Valor da venda            Comissão
----------------------------------
Abaixo de R$ 100             0%
De R$ 100 a R$ 499,99        1%
A partir de R$ 500           5%
```

Depois do cálculo individual das vendas, as comissões são agrupadas por vendedor.

<details>
<summary><b>Ver resultado</b></summary>

<br>

```text
========================================
          COMISSÃO DE VENDEDORES
========================================

Vendedor                        Comissão
----------------------------------------
João Silva                R$     495,68
Maria Souza               R$     465,95
Carlos Oliveira           R$     379,37
Ana Lima                  R$     404,98
========================================
```

</details>

<br>

## 𝗤𝗨𝗘𝗦𝗧Ã𝗢 𝟮 | 𝗖𝗢𝗡𝗧𝗥𝗢𝗟𝗘 𝗗𝗘 𝗘𝗦𝗧𝗢𝗤𝗨𝗘

Na segunda questão, os produtos disponíveis são carregados de `estoque.json` e a movimentação é feita pelo próprio console.

```text
                         PRODUTO
                            │
                ┌───────────┴───────────┐
                │                       │
           [E] ENTRADA              [S] SAÍDA
                │                       │
                └───────────┬───────────┘
                            │
                            ▼
                     ESTOQUE FINAL
```

O código do produto, o tipo de movimentação e a quantidade são informados durante a execução.

Antes de concluir uma saída, o programa verifica se existe estoque suficiente para a quantidade solicitada.

<details>
<summary><b>Ver exemplo de movimentação</b></summary>

<br>

```text
================================================
            MOVIMENTAÇÃO CONCLUÍDA
================================================
ID:               <gerado na execução>
Produto:          Caneta Azul
Movimentação:     Entrada de estoque
Quantidade:       10
Estoque anterior: 150
Estoque final:    160
================================================
```

</details>

<sub>O arquivo JSON representa o estoque inicial. A quantidade final é calculada durante a execução, sem alterar o arquivo original.</sub>

<br>

## 𝗤𝗨𝗘𝗦𝗧Ã𝗢 𝟯 | 𝗖Á𝗟𝗖𝗨𝗟𝗢 𝗗𝗘 𝗝𝗨𝗥𝗢𝗦

A terceira questão recebe um valor e uma data de vencimento para calcular os juros correspondentes aos dias de atraso.

A lógica pode ser resumida assim:

```text
 VALOR
   │
   ├────── × 2,5% ao dia
   │
   ├────── × dias em atraso
   │
   ▼
 JUROS
```

O cálculo utilizado é:

```text
juros = valor × 0,025 × dias em atraso
```

Como o enunciado não especifica capitalização, foi considerado o cálculo simples de **2,5% ao dia**.

Se o vencimento for igual ou posterior à data da execução, o atraso é considerado zero.

<details>
<summary><b>Ver exemplo de cálculo</b></summary>

<br>

```text
------------------------------------------------
               RESUMO DO CÁLCULO
------------------------------------------------
Valor original:      R$      1000,00
Vencimento:          01/10/2026
Dias em atraso:      2
Taxa diária:         2,5%
Juros calculados:    R$        50,00
Valor com juros:     R$      1050,00
================================================
```

</details>

<br>

## 𝗘𝗦𝗧𝗥𝗨𝗧𝗨𝗥𝗔 𝗗𝗢 𝗣𝗥𝗢𝗝𝗘𝗧𝗢

```text
desafio-target/
│
├── questao1/
│   ├── Program.cs
│   ├── questao1.csproj
│   └── vendas.json
│
├── questao2/
│   ├── Program.cs
│   ├── questao2.csproj
│   └── estoque.json
│
├── questao3/
│   ├── Program.cs
│   └── questao3.csproj
│
└── README.md
```

<br>

## 𝗖𝗢𝗠𝗢 𝗘𝗫𝗘𝗖𝗨𝗧𝗔𝗥

Com o **.NET SDK** instalado, entre na pasta da questão que deseja testar:

```bash
cd questao1
dotnet run
```

Para executar as outras soluções, basta entrar em `questao2` ou `questao3` e usar o mesmo comando:

```bash
dotnet run
```

Os arquivos `vendas.json` e `estoque.json` devem permanecer nas pastas de suas respectivas questões.

<br>

---

<div align="center">

**Gabriela Carla Coelho Rodrigues**

<sub>Desafio Técnico · Target Sistemas · 2026</sub>

</div>