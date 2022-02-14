using ApiVideoclubNC.Models;
using ApiVideoclubNC.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private RepositoryPeliculas repo;


        public PeliculasController(RepositoryPeliculas repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        [Route("[action]")]
        public List<Pelicula> GetPeliculas()
        {
            return this.repo.GetPeliculas();
        }

        [HttpGet("{id}")]
        public Pelicula FindPelicula(int id)
        {
            return this.repo.FindPelicula(id);
        }

        [HttpGet]
        [Route("[action]")]
        public List<Genero> GetGeneros()
        {
            return this.repo.GetGeneros();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public List<Pelicula> GetPeliculasGenero(int id)
        {
            return this.repo.GetPeliculasGenero(id);
        }

        [HttpGet]
        [Route("[action]")]
        public List<Cliente> GetClientes()
        {
            return this.repo.GetClientes();
        }
        
        [HttpGet]
        [Route("[action]/{id}")]
        public List<ClientesPeliculasPedido> GetPedidosCliente(int id)
        {
            return this.repo.GetClientesPeliculasPedidos(id);
        }

    }
}
