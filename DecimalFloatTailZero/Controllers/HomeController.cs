using DecimalFloatTailZero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DecimalFloatTailZero.Extensions;
using DecimalFloatTailZero.Services;

namespace DecimalFloatTailZero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly OrderService            _orderService;
        private readonly OrderCalculateService   _orderCalculateService;

        public HomeController(ILogger<HomeController> logger,
                              OrderService            orderService,
                              OrderCalculateService   orderCalculateService)
        {
            _logger                = logger;
            _orderService          = orderService;
            _orderCalculateService = orderCalculateService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _orderService.GetOrders();

            ViewBag.OrdersJson = orders.ToJson();

            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, Route("api/[Controller]")]
        public IActionResult PostCreate([FromBody]OrderDto vm)
        {
            return Ok(vm);
        }

        [HttpPost, Route("api/[Controller]")]
        public IActionResult Calculate([FromBody]OrderDto vm)
        {
            return Ok(vm);
        }
    }
}
