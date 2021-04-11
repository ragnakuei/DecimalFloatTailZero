using System;
using DecimalFloatTailZero.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            ViewBag.OrderJson = new OrderDto
                                {
                                    Details = new OrderDetailDto[]
                                                   {
                                                       new OrderDetailDto()
                                                   }
                                }.ToJson();

            ViewBag.EmptyOrderDetailJson = new OrderDetailDto().ToJson();

            return View();
        }

        [HttpPost, Route("api/[Controller]/[Action]")]
        public IActionResult PostCreate([FromBody]OrderDto vm)
        {
            _orderService.Create(vm);

            return Ok(vm);
        }

        [HttpGet, Route("[Controller]/[Action]/{orderGuid:guid}")]
        public IActionResult Edit(Guid? orderGuid)
        {
            var order = _orderService.GetOrder(orderGuid);

            ViewBag.OrderJson = order.ToJson();

            ViewBag.EmptyOrderDetailJson = new OrderDetailDto().ToJson();

            return View();
        }

        // [HttpPost, Route("api/[Controller]/[Action]")]
        // public IActionResult PostEdit([FromBody]OrderDto vm)
        // {
        //     _orderService.Edit(vm);
        //
        //     return Ok(vm);
        // }

        [HttpPost, Route("api/[Controller]/[Action]")]
        public IActionResult ReCalculate([FromBody]OrderDto vm)
        {
            _orderCalculateService.ReCalculate(vm);

            return Ok(vm);
        }
    }
}
