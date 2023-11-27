using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECommerceMVC.Data.Models;

namespace ECommerceMVC.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public OrderItemsController(IOrderItemService orderItemService, IOrderService orderService, IProductService productService)
        {
            _orderItemService = orderItemService ?? throw new ArgumentNullException(nameof(orderItemService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public async Task<IActionResult> Index()
        {
            var orderItems = await _orderItemService.GetAllOrderItemsAsync();
            return View(orderItems);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_orderItemService.OrderItemExists(id.Value))
            {
                return NotFound();
            }

            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id.Value);
            return View(orderItem);
        }

        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_orderService.GetAllOrdersAsync().Result, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_productService.GetAllProductsAsync().Result, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                await _orderItemService.CreateOrderItemAsync(orderItem);
                return RedirectToAction(nameof(Index));
            }

            ViewData["OrderId"] = new SelectList(await _orderService.GetAllOrdersAsync(), "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new SelectList(await _productService.GetAllProductsAsync(), "Id", "Id", orderItem.ProductId);
            return View(orderItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_orderItemService.OrderItemExists(id.Value))
            {
                return NotFound();
            }

            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id.Value);
            ViewData["OrderId"] = new SelectList(await _orderService.GetAllOrdersAsync(), "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new SelectList(await _productService.GetAllProductsAsync(), "Id", "Id", orderItem.ProductId);
            return View(orderItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,Quantity")] OrderItem orderItem)
        {
            if (id != orderItem.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderItemService.UpdateOrderItemAsync(orderItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_orderItemService.OrderItemExists(orderItem.OrderId))
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

            ViewData["OrderId"] = new SelectList(await _orderService.GetAllOrdersAsync(), "Id", "Id", orderItem.OrderId);
            ViewData["ProductId"] = new SelectList(await _productService.GetAllProductsAsync(), "Id", "Id", orderItem.ProductId);
            return View(orderItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_orderItemService.OrderItemExists(id.Value))
            {
                return NotFound();
            }

            var orderItem = await _orderItemService.GetOrderItemByIdAsync(id.Value);
            return View(orderItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderItemService.DeleteOrderItemAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
