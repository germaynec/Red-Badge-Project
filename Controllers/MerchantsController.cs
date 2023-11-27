using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class MerchantsController : Controller
    {
        private readonly IMerchantService _merchantService;
        private readonly IUserService _userService;

        public MerchantsController(IMerchantService merchantService, IUserService userService)
        {
            _merchantService = merchantService ?? throw new ArgumentNullException(nameof(merchantService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        public async Task<IActionResult> Index()
        {
            var merchants = await _merchantService.GetAllMerchantsAsync();
            return View(merchants);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || !_merchantService.MerchantExists(id.Value))
            {
                return NotFound();
            }

            var merchant = await _merchantService.GetMerchantByIdAsync(id.Value);
            return View(merchant);
        }

        public IActionResult Create()
        {
            ViewData["AdminId"] = new SelectList(_userService.GetAllUsersAsync().Result, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdminId,MerchantName,CreatedAt")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                await _merchantService.CreateMerchantAsync(merchant);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AdminId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", merchant.AdminId);
            return View(merchant);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || !_merchantService.MerchantExists(id.Value))
            {
                return NotFound();
            }

            var merchant = await _merchantService.GetMerchantByIdAsync(id.Value);
            ViewData["AdminId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", merchant.AdminId);
            return View(merchant);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdminId,MerchantName,CreatedAt")] Merchant merchant)
        {
            if (id != merchant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _merchantService.UpdateMerchantAsync(merchant);
                return RedirectToAction(nameof(Index));
            }

            ViewData["AdminId"] = new SelectList(await _userService.GetAllUsersAsync(), "Id", "Id", merchant.AdminId);
            return View(merchant);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || !_merchantService.MerchantExists(id.Value))
            {
                return NotFound();
            }

            var merchant = await _merchantService.GetMerchantByIdAsync(id.Value);
            return View(merchant);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _merchantService.DeleteMerchantAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
