GET /livros
GET /livros/{livroId}
POST /livros
PUT /livros
DELETE /livros/{livroId}

https://livraria/livros
https://livraria/livros/livroId
https://livraria/livros/cadastrar
https://livraria/livros/livroId/atualizar
https://livraria/livroId/excluir

livro{
	isbn: int,
	titulo: string,
	autor: string,
	descrição: string	
}
