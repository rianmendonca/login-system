## Descrição

Sistema de login feito em ASP.NET MVC.

## Requisitos

Para iniciar, certifique-se de ter os seguintes requisitos instalados em seu ambiente de desenvolvimento:

- **Visual Studio**
- **SQL Server**
- **SQL Server Management Studio (SSMS)**

## Configuração

1. Clone o projeto em sua máquina:
   
    ```bash
    git clone https://github.com/rianmendonca/login-system.git    
    ```
    
2. Abra o arquivo `appsettings.json` no seu projeto.

3. Configure a string de conexão de acordo com o método desejado:

    - **Autenticação via Windows:**
    
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Server=NomeDoSeuServidorSQL; Database=Users; Trusted_Connection=True; TrustServerCertificate=True;"
      }
      ```

    - **Autenticação via usuário e senha:**
    
      ```json
      "ConnectionStrings": {
        "DefaultConnection":" Server=NomeDoSeuServidorSQL; Database=Users; UserId=SeuId; Password=SuaSenha; Trusted_Connection=True; TrustServerCertificate=True;"
      }
      ```

      > Certifique-se de substituir os marcadores de posição (por exemplo, "NomeDoSeuServidorSQL", "SeuId", "SuaSenha") pelos valores específicos do seu ambiente.

3. No Console do NuGet, insira o seguinte comando para aplicar as migrações e atualizar o banco de dados:

    ```bash
    update-database
    ```
