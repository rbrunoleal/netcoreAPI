using APIDesafio.Application.DTOs;
using APIDesafio.Application.Interfaces.Mappers;
using APIDesafio.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace APIDesafio.Infrastructure.Application.Mappers
{
    public class MapperCategoria : IMapperCategoria
    {
        public Categoria MapperDTOToEntity(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria()
            {
                Id = categoriaDTO.Id,
                Descricao = categoriaDTO.Descricao
            };

            return categoria;
        }

        public CategoriaDTO MapperEntityToDTO(Categoria categoria)
        {
            var categoriaDTO = new CategoriaDTO()
            {
                Id = categoria.Id,
                Descricao = categoria.Descricao
            };

            return categoriaDTO;
        }

        public IEnumerable<CategoriaDTO> MapperListCategoriasDTO(IEnumerable<Categoria> categorias)
        {
            var CategoriasDTO = categorias.Select(x => new CategoriaDTO { Id = x.Id, Descricao = x.Descricao });
            return CategoriasDTO;
        }
    }
}
