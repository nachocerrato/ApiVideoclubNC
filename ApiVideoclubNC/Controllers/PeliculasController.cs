using ApiVideoclubNC.Models;
using ApiVideoclubNC.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [Route("[action]/{idcliente}")]
        public Cliente Cliente(int idcliente)
        {
            return this.repo.FindCliente(idcliente);
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
        [Route("[action]")]
        public List<ClientesPeliculasPedido> PedidosCliente()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Cliente cliente =
                JsonConvert.DeserializeObject<Cliente>(json);
            return this.repo.GetClientesPeliculasPedidos(cliente.IdCliente);
            //return this.repo.GetClientesPeliculasPedidos(id);
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public List<ClientesPeliculasPedido> Pedidos()
        {
            return this.repo.GetPedidos();
        }

        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public Cliente PerfilCliente()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;
            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(json);
            return cliente;
        }

        [Authorize]
        [HttpPost]
        [Route("[action]")]
        public void AddPedido(Pedido pedido)
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            string json = claims.SingleOrDefault(x => x.Type == "UserData").Value;

            Cliente cliente =
                JsonConvert.DeserializeObject<Cliente>(json);
            this.repo.AddPedido
                (cliente.IdCliente, pedido.IdPelicula, pedido.Cantidad, pedido.Fecha, pedido.Precio);
        }
    }
}
