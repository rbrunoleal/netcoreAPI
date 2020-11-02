using APIDesafio.Application.DTOs;
using APIDesafio.Domain.Entity;
using System.Collections.Generic;

namespace APIDesafio.Application.Interfaces.Mappers
{
    public interface IMapperProduto
    {
        Produto MapperDTOToEntity(ProdutoDTO ProdutoDTO);

        IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> Produtos);

        ProdutoDTO MapperEntityToDTO(Produto Produto);
    }
}
