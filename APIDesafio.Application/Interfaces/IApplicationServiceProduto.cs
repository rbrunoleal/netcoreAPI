using APIDesafio.Application.DTOs;
using System.Collections.Generic;

namespace APIDesafio.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO produtoDTO);

        void Update(ProdutoDTO produtoDTO);

        void Remove(ProdutoDTO produtoDTO);      

        IEnumerable<ProdutoDTO> Get();

        ProdutoDTO GetById(int id);

        ProdutoDTO GetByIdIncludeCategoria(int id);
    }
}
