using APIDesafio.Application.DTOs;
using APIDesafio.Application.Interfaces.Mappers;
using APIDesafio.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafio.Infrastructure.Application.Mappers
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDTOToEntity(ProdutoDTO ProdutoDTO)
        {
            var Produto = new Produto()
            {
                Id = ProdutoDTO.Id,
                Descricao = ProdutoDTO.Descricao,
                Valor = ProdutoDTO.Valor,
                Quantidade = ProdutoDTO.Quantidade,
                CategoriaId = ProdutoDTO.CategoriaId,
                Categoria = ProdutoDTO.Categoria
            };

            return Produto;
        }

        public ProdutoDTO MapperEntityToDTO(Produto produto)
        {
            var ProdutoDTO = new ProdutoDTO()
            {
                Id = produto.Id,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                Quantidade = produto.Quantidade,
                CategoriaId = produto.CategoriaId,
                Categoria = produto.Categoria
            };

            return ProdutoDTO;
        }

        public IEnumerable<ProdutoDTO> MapperListProdutosDTO(IEnumerable<Produto> produtos)
        {
            var ProdutosDTO = produtos.Select(x => new ProdutoDTO { Id = x.Id, 
                                                                    Descricao = x.Descricao,
                                                                    Valor = x.Valor,
                                                                    Quantidade = x.Quantidade,
                                                                    CategoriaId = x.CategoriaId,
                                                                    Categoria = x.Categoria                                                                  
                                                                  });
            return ProdutosDTO;
        }
    }
}
