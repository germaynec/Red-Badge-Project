using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrdersController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            return View(orders);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_orderService.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            return View(order);
        }

        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_userService.GetAllUsersAsync().Result, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Status,CreatedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                await _orderService.CreateOrderAsync(order);
                return RedirectToAction(nameof(Index));
            }

            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", order.UserId);
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_orderService.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", order.UserId);
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Status,CreatedAt")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _orderService.UpdateOrderAsync(order);
                }
                catch (Exception)
                {
                    if (!_orderService.OrderExists(order.Id))
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

            ViewData["UserId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", order.UserId);
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_orderService.OrderExists(id.Value))
            {
                return NotFound();
            }

            var order = await _orderService.GetOrderByIdAsync(id.Value);
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _orderService.DeleteOrderAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
