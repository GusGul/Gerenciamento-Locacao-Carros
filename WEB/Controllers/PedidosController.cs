using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using WEB.Contexto;
using WEB.Models;
using WEB.ModelViews;

namespace WEB.Controllers
{
    public class PedidosController : Controller
    {
        private readonly DbContexto _context;

        public PedidosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            // Link to sql
            var pedidos = await Task.FromResult(from ped in _context.Pedidos
                                join cli in _context.Clientes on ped.ClienteRefId equals cli.Id
                                join car in _context.Carros on ped.CarroRefId equals car.Id
                                join mar in _context.Marcas on car.MarcaRefId equals mar.Id
                                select new PedidoResumido
                                {
                                    PedidoId = ped.Id,
                                    NomeCliente = cli.Nome,
                                    NomeCarro = car.Nome,
                                    NomeMarca = mar.Nome,
                                    DataLocacaoPedido = ped.DataLocacao,
                                    DataEntregaPedido = ped.DataEntrega
                                });

            /* Join que salva processamento do BD, nativo do entity.
            var pedidos = await _context.Pedidos.Join
            (
                _context.Clientes,
                ped => ped.ClienteRefId,
                cli => cli.Id,
                (ped, cli) => new
                {
                    PedidoId = ped.Id,
                    DataLocacaoPedido = ped.DataLocacao,
                    DataEntregaPedido = ped.DataEntrega,
                    NomeCliente = cli.Nome,
                    CarroId = ped.CarroRefId
                }
            ).Join
            (
                _context.Carros,
                pedCli => pedCli.CarroId,
                car => car.Id,
                (pedCli, car) => new PedidoResumido
                {
                    PedidoId = pedCli.PedidoId,
                    NomeCliente = pedCli.NomeCliente,
                    NomeCarro = car.Nome,
                    DataLocacaoPedido = pedCli.DataLocacaoPedido,
                    DataEntregaPedido = pedCli.DataEntregaPedido,
                }
            ).ToListAsync();
            */

            ViewBag.pedidos = pedidos;
            return View();
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Carro)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["CarroRefId"] = new SelectList(_context.Carros, "Id", "Nome");
            ViewData["ClienteRefId"] = new SelectList(_context.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteRefId,CarroRefId,DataLocacao")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                var config = _context.Configuracoes.FirstOrDefault();
                var dias = config is not null ? config.DiaDeLocacao : 1;
                pedido.DataEntrega = pedido.DataLocacao.AddDays(dias);
                _context.Add(pedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroRefId"] = new SelectList(_context.Carros, "Id", "Nome", pedido.CarroRefId);
            ViewData["ClienteRefId"] = new SelectList(_context.Clientes, "Id", "Nome", pedido.ClienteRefId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["CarroRefId"] = new SelectList(_context.Carros, "Id", "Nome", pedido.CarroRefId);
            ViewData["ClienteRefId"] = new SelectList(_context.Clientes, "Id", "Nome", pedido.ClienteRefId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteRefId,CarroRefId,DataLocacao,DataEntrega")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarroRefId"] = new SelectList(_context.Carros, "Id", "Nome", pedido.CarroRefId);
            ViewData["ClienteRefId"] = new SelectList(_context.Clientes, "Id", "Nome", pedido.ClienteRefId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Carro)
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'DbContexto.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
          return (_context.Pedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
