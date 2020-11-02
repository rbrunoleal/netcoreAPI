using APIDesafio.Application.DTOs;
using System.Collections.Generic;

namespace APIDesafio.Application.Interfaces
{
    public interface IApplicationServiceCategoria
    {
        void Add(CategoriaDTO categoriaDTO);

        void Update(CategoriaDTO categoriaDTO);

        void Remove(CategoriaDTO categoriaDTO);

        IEnumerable<CategoriaDTO> Get();

        CategoriaDTO GetById(int id);
    }
}
