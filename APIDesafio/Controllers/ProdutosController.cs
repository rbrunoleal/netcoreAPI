using APIDesafio.Application.DTOs;
using APIDesafio.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIDesafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto applicationServiceProduto)
        {
            this.applicationServiceProduto = applicationServiceProduto;
        }

        // GET api/Produtos
        /// <summary>
        /// Retorna todos os Produtos.
        /// </summary>
        /// <returns>Produtos</returns>
        /// <response code="200">Retorna uma lista de produtos cadastrados na aplicação.</response>
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDTO>> Get()
        {
            return Ok(applicationServiceProduto.Get());            
        }

        // GET api/Produtos/:id
        /// <summary>
        /// Retorna um Produto.
        /// </summary>
        /// <returns>Produtos</returns>
        /// <response code="200">Retorna o produto cadastrado na aplicação com base no id da requisição</response>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //Get Object Simples, sem referência(Desempenho)
            //return Ok(applicationServiceProduto.GetById(id));
            //Get Object com referência
            return Ok(applicationServiceProduto.GetByIdIncludeCategoria(id));
        }


        // POST api/Produtos
        /// <summary>
        /// Cria um Produto.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/Produtos
        ///     {        
        ///         "descricao": "Computador",
        ///         "valor": 1000,
        ///         "quantidade": 10,
        ///         "categoriaId": 1               
        ///     }
        ///     
        ///     OU
        ///     
        ///     POST api/Produtos
        ///     {        
        ///         "descricao": "Computador",
        ///         "valor": 1000,
        ///         "quantidade": 10,        
        ///         "categoria": {
        ///              "descricao": "Informática"
        ///         }
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Produto</returns>
        /// <response code="200">Retorna o novo produto criado</response>
        /// <response code="400">Se o produto não for criado</response>         
        [HttpPost]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                applicationServiceProduto.Add(produtoDTO);
                return Ok("Produto cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                //return StatusCode(500, ex.Message);
            }
        }

        // PUT api/Produtos
        /// <summary>
        /// Edita um Produto.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT api/Produtos
        ///    {        
        ///         "id": 2,
        ///         "descricao": "Computador",
        ///         "valor": 1000,
        ///         "quantidade": 15,        
        ///         "categoriaId": 1
        ///    }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Produto</returns>
        /// <response code="200">Retorna o item editado.</response>
        /// <response code="400">Item não foi editado</response>     
        [HttpPut]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                applicationServiceProduto.Update(produtoDTO);
                return Ok("Produto atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/Produtos   
        /// <summary>
        /// Deleta um Produto.
        /// </summary>
        /// /// <remarks>
        /// Exemplo:
        ///
        ///     PUT api/Produtos
        ///    {        
        ///         "id": 2,
        ///         "descricao": "Computador",
        ///         "valor": 1000,
        ///         "quantidade": 15,        
        ///         "categoriaId": 1
        ///    }
        ///
        /// </remarks>
        /// <returns>Produtos</returns>
        /// <response code="200">Se o produto foi excluído</response>
        [HttpDelete()]
        public ActionResult Delete([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                applicationServiceProduto.Remove(produtoDTO);
                return Ok("Produto removido com sucesso!");

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
