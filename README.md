# FundosInvestimentos
Fundos de Investimentos

arquivo script contém os scritps para criaçã das tabelas fundo e movimento e uma carga da tabela fundo.

no aquivo Dockerfile existem duas variáveis de ambiente:
DB_STRING_CONEXAO de conexão como banco, sendo necessário alterar os parâmetros Server={host}, User ID={usuario} e Password={senha}
EXECUTAR_MIGRATION que inicialmente está como 'false', caso seja alterado para 'true', serve para a criação automática das tabelas por meio do entity framework 
