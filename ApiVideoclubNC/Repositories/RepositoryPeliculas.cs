using ApiVideoclubNC.Data;
using ApiVideoclubNC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVideoclubNC.Repositories
{
    public class RepositoryPeliculas
    {
        private PeliculasContext context;

        public RepositoryPeliculas(PeliculasContext context)
        {
            this.context = context;
        }
        public List<Cliente> GetClientes()
        {
            return this.context.Clientes.ToList();
        }

        public Cliente FindCliente(int idcliente)
        {
            return this.context.Clientes.FirstOrDefault<Cliente>(x => x.IdCliente == idcliente);
        }

        public Cliente ExisteCliente(string mail, int idcliente)
        {
            var consulta = from datos in this.context.Clientes
                           where datos.IdCliente == idcliente
                           && datos.Mail == mail
                           select datos;
            return consulta.FirstOrDefault();
        }

        //Añado esto porque he creado un perfil Administrador
        public Administrador ExisteAdmin(string mail, int idadmin)
        {
            var consulta = from datos in this.context.Administradores
                           where datos.IdAdmin == idadmin
                           && datos.Mail == mail
                           select datos;
            return consulta.FirstOrDefault();
        }

        //Al añadir pedido no tengo que añadir un IdPedido, porque se genera en el método 
        //onModelCreating() del Context en base a los campos IdCliente e IdPelicula
        public void AddPedido
            (int idcliente, int idpelicula, int cantidad
            , DateTime fecha, int precio)
        {
            Pedido pedido = new Pedido();
            pedido.IdCliente = idcliente;
            pedido.IdPelicula = idpelicula;
            pedido.Cantidad = cantidad;
            pedido.Fecha = fecha;
            pedido.Precio = precio;

            this.context.Pedidos.Add(pedido);
            this.context.SaveChanges();
        }

        public ClientesPeliculasPedido FindPedido(int idpedido)
        {
            return this.context.PedidosCliente
                .FirstOrDefault<ClientesPeliculasPedido>(x => x.IdPedido == idpedido);
        }

        public List<ClientesPeliculasPedido> GetPedidos()
        {
            return this.context.PedidosCliente.ToList();
        }

        public void DeletePedido(int idpedido)
        {
            ClientesPeliculasPedido pedidoCliente = this.FindPedido(idpedido);
            this.context.PedidosCliente.Remove(pedidoCliente);
            this.context.SaveChanges();
        }
        public List<Genero> GetGeneros()
        {
            return this.context.Generos.ToList();
        }

        public List<Pelicula> GetPeliculas()
        {
            return this.context.Peliculas.ToList();
        }

        public Pelicula FindPelicula(int idpelicula)
        {
            return this.context.Peliculas.FirstOrDefault<Pelicula>(x => x.IdPelicula == idpelicula);
        }

        public List<Pelicula> GetPeliculasGenero(int idgenero)
        {
            var consulta = from datos in this.context.Peliculas
                           where datos.IdGenero == idgenero
                           select datos;
            return consulta.ToList();

        }
        public List<ClientesPeliculasPedido> GetClientesPeliculasPedidos(int idcliente)
        {
            var consulta = from datos in this.context.PedidosCliente
                           where datos.IdCliente == idcliente
                           select datos;
            return consulta.ToList();
        }
    }
}
