using APIDesafio.Application.DTOs;
using APIDesafio.Application.Interfaces;
using APIDesafio.Application.Interfaces.Mappers;
using APIDesafio.Domain.Core.Interfaces.Services;
using System.Collections.Generic;

namespace APIDesafio.Application
{
    public class ApplicationServiceCategoria : IApplicationServiceCategoria
    {
        private readonly IServiceCategoria serviceCategoria;
        private readonly IMapperCategoria mapperCategoria;

        public ApplicationServiceCategoria(IServiceCategoria serviceCategoria
                                         , IMapperCategoria mapperCategoria)
        {
            this.serviceCategoria = serviceCategoria;
            this.mapperCategoria = mapperCategoria;
        }

        public void Add(CategoriaDTO categoriaDTO)
        {
            var categoria = mapperCategoria.MapperDTOToEntity(categoriaDTO);
            serviceCategoria.Add(categoria);
        }

        public IEnumerable<CategoriaDTO> Get()
        {
            var categorias = serviceCategoria.Get();
            return mapperCategoria.MapperListCategoriasDTO(categorias);
        }

        public CategoriaDTO GetById(int id)
        {
            var categoria = serviceCategoria.GetById(id);
            return categoria != null? mapperCategoria.MapperEntityToDTO(categoria) : null;
        }

        public void Remove(CategoriaDTO categoriaDTO)
        {
            var categoria = mapperCategoria.MapperDTOToEntity(categoriaDTO);
            serviceCategoria.Remove(categoria);
        }

        public void Update(CategoriaDTO categoriaDTO)
        {
            var categoria = mapperCategoria.MapperDTOToEntity(categoriaDTO);
            serviceCategoria.Update(categoria);
        }
    }
}
