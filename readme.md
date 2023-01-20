# 🏁 PROJETO CONCLUÍDO 🏁

O projeto foi desenvolvido utilizando o .NET 7 com a persistência dos dados no banco de dados PostgreSQL e com a ajuda do Nuget, foram instalados os seguintes pacotes: 

* Microsoft.EntityFrameworkCore
* Microsoft.EntityFrameworkCore.Tools
* Npgsql
* Npgsql.EntityFrameworkCore.PostgreSQL

> **Oberservação:** caso deseje ser utilizado outro banco de dados, basta fazer a instalação dos pacotes do Entity Framework do banco de dados que será utilizado.

---

## Instruções de uso

1. Faça a instalação dos pacotes do banco de dados do PostgreSQL, fazendo o download no site oficial;

2. Após a instalação e configuração do PostgreSQL, abra a projeto no editor de texto desejado: VSCode ou Microsoft Visual Studio, por exemplo;

3. Antes de executar o programa, é necessário alterar a String de conexão com o banco, basta abrir o arquivo `appsettings.json` e substituir os campos `User ID`, `Senha` e `Database` pelo usuário, senha e nome do banco, respectivamente, criados na instalação;

4. Agora é necessário realizar as `Migrations` para a criação automática das tabelas e as relações de acordo com o modelo da API, os `Models`. Para isso, execute os seguintes comandos:

```
> Add-Migration "Inicial"

> Update-Database
```

5. Com as tabelas criadas, basta executar o programa com o comando `dotnet run` no VSCode ou apertando as teclas `Ctrl` + `F5` do Microsoft Visual Studio;
   
6. Para acessar a interface/documentação do Swagger, com o navegador, basta acessar o endereço: `https://localhost:7097/swagger/index.html` e pronto.

---

## Regras de negócio e Evidências de Funcionamento

✅ Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";

![](/imagens/img1.png)

✅ Buscar venda: Busca pelo Id da venda;

![](/imagens/img14.png)

✅ Atualizar venda: Permite que seja atualizado o status da venda.

**Observação para possíveis status:**
* Pagamento Aprovado
* Enviado para Transportadora
* Entregue
* Cancelado

![](/imagens/img15.png)

✅ Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;

![](/imagens/img1.png)

✅ O vendedor deve possuir id, cpf, nome, e-mail e telefone;

![](/imagens/img2.png)

✅ A inclusão de uma venda deve possuir pelo menos 1 item;

![](/imagens/img3.png)

✅ A atualização de status deve permitir somente as seguintes transições:
* **De:** Aguardando pagamento  **Para:** Pagamento Aprovado
* **De:** Aguardando pagamento   **Para:** Cancelada
* **De:** Pagamento Aprovado    **Para:** Enviado para Transportadora
* **De:** Pagamento Aprovado   **Para:** Cancelada
* **De:** Enviado para Transportador. **Para:** Entregue

![](/imagens/img4.png)

![](/imagens/img5.png)

✅ A API não precisa ter mecanismos de autenticação/autorização;

✅ Dados complementares:

![](/imagens/img7.png) -> 
![](/imagens/img6.png)

> Foi realizado a criação de uma tabela complementar para registrar todos os itens/produtos da compra, assim, a tabela em questão vai ter um identificador único (Chave Primária/Primary Key) e os identificadores da venda e do item daquela venda, então para cada venda com X itens/produtos vai existir a mesma quantidade de X linhas na tabela compra com o id_venda e o id_item para cada item/produto daquela venda.

![](/imagens/img12.png)
![](/imagens/img13.png)

<br>

![](/imagens/img8.png)
![](/imagens/img9.png)
![](/imagens/img10.png)
![](/imagens/img11.png)