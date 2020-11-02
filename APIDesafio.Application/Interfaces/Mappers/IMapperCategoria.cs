using APIDesafio.Application.DTOs;
using APIDesafio.Domain.Entity;
using System.Collections.Generic;

namespace APIDesafio.Application.Interfaces.Mappers 
{ 
    public interface IMapperCategoria
    {
        Categoria MapperDTOToEntity(CategoriaDTO categoriaDTO);

        IEnumerable<CategoriaDTO> MapperListCategoriasDTO(IEnumerable<Categoria> categorias);

        CategoriaDTO MapperEntityToDTO(Categoria categoria);
    }
}
