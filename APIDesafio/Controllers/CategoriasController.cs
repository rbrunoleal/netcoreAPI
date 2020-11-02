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
    public class CategoriasController : ControllerBase
    {
        private readonly IApplicationServiceCategoria applicationServiceCategoria;

        public CategoriasController(IApplicationServiceCategoria applicationServiceCategoria)
        {
            this.applicationServiceCategoria = applicationServiceCategoria;
        }

        // GET api/Categorias
        /// <summary>
        /// Retorna todas as Categorias.
        /// </summary>
        /// <returns>Categorias</returns>
        /// <response code="200">Retorna uma lista de categorias cadastradas na aplicação.</response>
        [HttpGet] 
        public ActionResult<IEnumerable<CategoriaDTO>> Get()
        {
            return Ok(applicationServiceCategoria.Get());
        }

        // GET api/Categorias/:id
        /// <summary>
        /// Retorna uma Categoria.
        /// </summary>
        /// <returns>Categoria</returns>
        /// <response code="200">Retorna a categoria cadastrada na aplicação com base no id da requisição</response>
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(applicationServiceCategoria.GetById(id));
        }

        // POST api/Categorias
        /// <summary>
        /// Cria uma Categoria.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST api/Categorias
        ///     {        
        ///         "descricao": "Categoria1"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Categoria</returns>
        /// <response code="200">Retorna a nova categoria criada</response>
        /// <response code="400">Se a categoria não for criada</response>         
        [HttpPost]
        public ActionResult Post([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaDTO == null)
                    return NotFound();

                applicationServiceCategoria.Add(categoriaDTO);
                return Ok("Categoria cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/Categorias
        /// <summary>
        /// Edita uma Categoria.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     PUT api/Categorias
        ///     {    
        ///         "id": 1,
        ///         "descricao": "Categoria2"
        ///     }
        ///
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>Categoria</returns>
        /// <response code="200">Retorna o item editado.</response>
        /// <response code="400">Item não foi editado</response>   
        [HttpPut]
        public ActionResult Put([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaDTO == null)
                    return NotFound();

                applicationServiceCategoria.Update(categoriaDTO);
                return Ok("Categoria atualizada com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/Categorias
        /// <summary>
        /// Deleta uma Categoria.
        /// </summary>
        /// /// <remarks>
        /// Exemplo:
        ///
        ///     DELETE api/Categorias
        ///     {    
        ///         "id": 1,
        ///         "descricao": "Categoria"
        ///     }
        ///
        /// </remarks>
        /// <returns>Categorias</returns>
        /// <response code="200">Se a categoria foi excluída</response>
        [HttpDelete()]
        public ActionResult Delete([FromBody] CategoriaDTO categoriaDTO)
        {
            try
            {
                if (categoriaDTO == null)
                    return NotFound();

                applicationServiceCategoria.Remove(categoriaDTO);
                return Ok("Categoria removida com sucesso!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
