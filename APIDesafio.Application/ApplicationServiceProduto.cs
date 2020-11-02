using APIDesafio.Application.DTOs;
using APIDesafio.Application.Interfaces;
using APIDesafio.Application.Interfaces.Mappers;
using APIDesafio.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace APIDesafio.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        private readonly IServiceProduto serviceProduto;
        private readonly IMapperProduto mapperProduto;

        private readonly IApplicationServiceCategoria applicationServiceCategoria;

        public ApplicationServiceProduto(IServiceProduto serviceProduto,
                                        IMapperProduto mapperProduto,
                                        IApplicationServiceCategoria applicationServiceCategoria)
        {
            this.serviceProduto = serviceProduto;
            this.mapperProduto = mapperProduto;
            this.applicationServiceCategoria = applicationServiceCategoria;
        }

        public void Add(ProdutoDTO produtoDTO)
        {
            try
            {                
                if (applicationServiceCategoria.GetById(produtoDTO.CategoriaId) != null)
                {
                    var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
                    serviceProduto.Add(produto);
                }
                else
                {
                    throw new Exception("Categoria não encontrada.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        public IEnumerable<ProdutoDTO> Get()
        {
            //Get Object Simples, sem referência
            //var produtos = serviceProduto.Get();
            //Get Object com referência
            var produtos = serviceProduto.Get("Categoria");
            return mapperProduto.MapperListProdutosDTO(produtos);
        }

        public ProdutoDTO GetById(int id)
        {
            var produto = serviceProduto.GetById(id);
            return mapperProduto.MapperEntityToDTO(produto);
        }

        public ProdutoDTO GetByIdIncludeCategoria(int id)
        {
            var produto = serviceProduto.GetByIdIncludeCategoria(id);
            return mapperProduto.MapperEntityToDTO(produto.Result);
        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
            serviceProduto.Remove(produto);
        }

        public void Update(ProdutoDTO produtoDTO)
        {
            var produto = mapperProduto.MapperDTOToEntity(produtoDTO);
            serviceProduto.Update(produto);
        }
    }
}
