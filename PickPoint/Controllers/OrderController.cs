using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickPoint.DataBase;
using PickPoint.Models;
using PickPoint.Models.DTO;
using PickPoint.Models.Entity;
using System.Linq;

namespace PickPoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly PickPointContext _context;

        public OrderController(PickPointContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDTO> Get(int id)
        {
            var order = _context.Orders.Find(id);

            if (order == null)
                return NotFound();

            var result = Mapper.Map<Order, OrderDTO>(order);

            var goods = _context.Goods.Where(x => x.OrderId == result.Id).Include(x => x.Product).ToList();
            result.Goods = goods.Select(x => x.Product.ProductName).ToArray();

            result.Status = _context.OrderStatus.Find(result.StatusId).Status;

            return result;
        }

        [HttpPost]
        public ActionResult Create(OrderDTO _order)
        {
            var check = CheckRequest(_order);
            if (check != null)
                return check;

            var order = Mapper.Map<OrderDTO, Order>(_order);
            _context.Orders.Add(order);
            _context.SaveChanges();
            _order.Id = order.Id;

            foreach (var prodact in _order.Goods)
            {
                var _protact = _context.Products.Where(x => x.ProductName.Contains(prodact)).FirstOrDefault();
                if (_protact == null)
                {
                    _protact = new Product() { ProductName = prodact };
                    _context.Products.Add(_protact);
                    _context.SaveChanges();
                }
                var goods = new Goods() { OrderId = _order.Id, ProductId = _protact.Id };
                _context.Goods.Add(goods);
            }
            _context.SaveChanges();

            _order.Status = _context.OrderStatus.Find(_order.StatusId).Status;
            return CreatedAtAction(nameof(Create), new {id = _order.Id}, _order);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, OrderDTO _order)
        {
            var order = _context.Orders.Find(id);

            if(order == null || id != _order.Id)
                return BadRequest();

            var check = CheckRequest(_order);
            if (check != null)
                return check;

            order.PhoneNumber = _order.PhoneNumber;
            order.RecipientName = _order.RecipientName;
            order.Check = _order.Check;

            var goodsFromBD = _context.Goods
                .Where(x => x.OrderId == order.Id)
                .Include(x => x.Product)
                .Select(x => x.Product.ProductName)
                .ToList();

            foreach (var prodact in _order.Goods)
            {
                var protactFromBD = _context.Products.Where(x => x.ProductName.Contains(prodact)).FirstOrDefault();
                if(protactFromBD == null)
                {
                    protactFromBD = new Product() { ProductName = prodact };
                    _context.Products.Add(protactFromBD);
                    _context.SaveChanges();
                }
                if(!goodsFromBD.Contains(prodact))
                {
                    var goods = new Goods() { OrderId = _order.Id, ProductId = protactFromBD.Id };
                    _context.Goods.Add(goods);
                }
                    goodsFromBD.Remove(prodact);
            }
            if (goodsFromBD.Any())
            {
                foreach(var prodact in goodsFromBD)
                {
                    var idProdact = _context.Products.FirstOrDefault(x => x.ProductName.Contains(prodact)).Id;
                    var goods = _context.Goods.FirstOrDefault(x => x.ProductId == idProdact && x.OrderId == id);
                    _context.Goods.Remove(goods);
                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null)
                return NotFound();
            order.OrderStatusId = 6;
            _context.SaveChanges();
            return NoContent();
        }

        public ActionResult CheckRequest(OrderDTO _order)
        {
            if (_order.Goods.Length > 10
                || Validate.IsBadPhoneNumber(_order.PhoneNumber)
                || Validate.IsBadPostamatNumber(_order.PostamatNumber))
                return BadRequest();

            var postamat = _context.Postamats.Find(_order.PostamatNumber);
            if (postamat == null)
                return NotFound();

            if (!postamat.Status)
                return Forbid();

            return null;
        }
    }
}
