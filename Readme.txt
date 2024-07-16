


Olá, este é um sistema de Controle de fluxo de caixa, funciona de forma bem simples. existem alguns fluxos :

Fluxo 1 : Fluxo pra adicionar o Produto, vc vai em : Home > Fluxo de caixa > Adicionar  e lá voce tem as opções de adicionar o produto, o valor e a opção de creditar ou debitar.
Fluxo 2 : Fluxo para verificar o balanço do dia, vc vai em : Home > Fluxo de Caixa > Ver Fluxo , e lá você tem o balanço do dia ( obs é sempre do dia atual ) e acrescentei um extra que seria baixar o relatorio em  Excel, uma planinha bonitinha e atualizada dizendo q é cada coisa .

Fiz algumas melhorias visuais como por exemplo, os valores que sao creditados, botei o + na frente para identificar, alem de que tem o tipo né, e tb botei o contrario nos casos de  Debitado ( - ) 

Tudo seguinto arquitetura Limpa, Utilizando Principios Solids, Tudo divido em camadas, responsabilidades separadas, Utilizando Desing Pattern : Singleton, simples porém eficaz e deixa o codigo menos verboso.

Uma Curiosidade : Não Fiz utilizando banco de dados por motivos de ser simples demais, então o "banco de dados" que alimenta e que reproduz os dados são de um arquivo txt ( bloco de notas ) convertido em json,
assim consigo pegar os dados e inseri-los do mesmo padrão; basicamente foi uma simulação de banco de dados e também para evitar salvar coisas em memórias, oq torna a aplicação volátil, então, utilizando bloco de notas
torno fisico e durável os dados que são alimentados e reproduzidos no sistema.


PARA RODAR É MUITO SIMPLES: Baixe o repositório, utilize o visual studio 2022, carregue o projeto e dê build. 

Realizei os testes via XunitTests do proprio .net, fiz um projeto a parte testando os principais meios de transações e verifcações de fluxos.
