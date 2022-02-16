using ApiVideoclubNC.Models;
using ApiVideoclubNC.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        public List<Pelicula> Peliculas()
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
        public List<Genero> Generos()
        {
            return this.repo.GetGeneros();
        }

        [HttpGet]
        [Route("[action]/{id}")]
        public List<Pelicula> PeliculasGenero(int id)
        {
            return this.repo.GetPeliculasGenero(id);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public List<Cliente> Clientes()
        {
            return this.repo.GetClientes();
        }
        
        [Authorize]
        [HttpGet]
        [Route("[action]/{id}")]
        public List<ClientesPeliculasPedido> PedidosCliente(int id)
        {
            return this.repo.GetClientesPeliculasPedidos(id);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public List<ClientesPeliculasPedido> Pedidos()
        {
            return this.repo.GetPedidos();
        }

    }
}
