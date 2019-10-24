# lambda-complexity-simulation

Este repositório trata-se de duas aplicações simulando 3 algoritmos distintos, com implementações distintas para análise de impacto em termos de complexidade de tempo e memória.

Problema:
- Dado 2 vetores um vetor V de tamanho N, do tipo char sem duplicatas e outro vetor K de tamanho M, também do tipo char, mas com duplicatas. Como contabilizar de forma eficiente, entre a escolha do algoritmo e estrutura de dados mais eficiente.

Exemplo:

V = ['A', 'C', 'D', 'K', 'I', 'U'] e K = ['A', 'E, 'C', 'X', 'Z', 'A','I', 'O', 'N', 'I', 'B', 'U']

Output:
A = 2
C = 1
D = 0
K = 0
I = 2
U = 1

A ideia principal é experimentar um algoritmo quadrático O(n^2) e dois com estratégias lineares O(n), porém estes dois últimos utilizam estruturas de dados distintas, um utiliza um vetor para mapeamento da aparição de cada elemento (estratégia baseada no Counting Sort) e outro através de um Hashtable.

A aula onde estes códigos foram utilizados podem ser encontradas em: https://youtu.be/zvK-8x2PtV8
