# AppLocaliza

Projeto criado para o Desafio.


Projeto Localiza.Base ( Models e Context EntityFrameWork.Sqlite ) -> no Arquivo DataBaseContext.cs Linha 30 Alterar o Data Source para o diretório local do Banco de Dados "Data Source=SEUDIRETORIO\\database.db".

Projeto Localiza.Repository ( Contém interface genérica para os ações no bd ) como inclusão, edição, exclusão ), cada classe contém sua interface responsável pela suas ações na tabela X.

Projeto Localiza.Service ( Contém as regras de negócio e ações especificas de cada Controller )

Projeto AppLocaliza Api com os Controllers e suas definidas ações.

Foi incluido no projeto Authenticate utilizando Cookies do navegador com prazo de expiração de 1hora, para realiza o cadastro de um usuário é importante definir 

  "usuario": "string",
  "senha": "string",
  "tipo": "string", -> Administrador, Operador, Cliente

deve ser utilizado um dos níveis de acesso, lembrando que o Administrador permite tudo no projeto, alguns tem limitações como apenas visualização ou não permitir a exclusão, sobre cada método nos controllers tem a role de permissão. 

        [HttpGet("{id}")]
        [AuthorizeUser("Administrador, Operador")]
        public ActionResult<PesCliente> GetCliente(int id)
        {
            var user = _user.GetByIndex(id);

            if (user == null)
                return NotFound();

            return _user.GetByIndex(id);
        }


