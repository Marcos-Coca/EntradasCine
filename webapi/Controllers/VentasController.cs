using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.DB;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
       

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(NewVenta newVenta)
        {

            using var db = new CineContext();
            var venta = new Venta
            {
                CodigoPelicula = newVenta.CodigoPelicula,
                Titulo = newVenta.Titulo,
                Clasificacion = newVenta.Clasificacion,
                Asiento = newVenta.Asiento
            };
            db.Ventas.Add(venta);
            await db.SaveChangesAsync();

            var soldTickets = db.Ventas.Count();
            return Ok(soldTickets);
        }

    }
}
