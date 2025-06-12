using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Socializer_001.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        CustomerDataService customerDataService;
        CryptoDataService cryptoDataService;
        OrderDataService orderDataService;
        OrderItemsDataService orderItemsDataService;
        public ShoppingController(CustomerDataService cs,
                                    CryptoDataService cr,
                                      OrderDataService or,
                                        OrderItemsDataService oi)
        {
            customerDataService = cs;
            cryptoDataService = cr;
            orderDataService = or;
            orderItemsDataService = oi;
        }
        // CryptoDataService APIs
        [HttpGet("crypto/{id}")]
        public async Task<ActionResult<Crypto>> GetCryptoData(int id)
        {
            try
            {
                var crypto = await cryptoDataService.GetCryptoData(id);
                if (crypto == null) return NotFound();
                return Ok(crypto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("cryptos")]
        public async Task<ActionResult<List<Crypto>>> GetAllCryptosDatas()
        {
            try
            {
                var cryptos = await cryptoDataService.GetAllCrytosDatas();
                return Ok(cryptos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("crypto/{id}/price")]
        public async Task<ActionResult<decimal>> GetCryptoPrice(int id)
        {
            try
            {
                var price = await cryptoDataService.GetCryptoPrice(id);
                return Ok(price);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("crypto")]
        public async Task<IActionResult> UpdateCryptoData([FromBody] Crypto crypto)
        {
            try
            {
                await cryptoDataService.UpdateCryptoData(crypto);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("crypto/{id}")]
        public async Task<IActionResult> DeleteCrypto(int id)
        {
            try
            {
                await cryptoDataService.DeleteCrypto(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("crypto")]
        public async Task<IActionResult> AddCrypto([FromBody] Crypto crypto)
        {
            try
            {
                await cryptoDataService.AddCrypto(crypto);
                return CreatedAtAction(nameof(GetCryptoData), new { id = crypto.Id }, crypto);
            }
            catch (ArgumentNullException)
            {
                return BadRequest("Crypto already exists");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // CustomerDataService APIs
        [HttpGet("customer/{id}")]
        public async Task<ActionResult<Customer>> GetCustomerData(int id)
        {
            try
            {
                var customer = await customerDataService.GetCustomerData(id);
                if (customer == null) return NotFound();
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("customers")]
        public async Task<ActionResult<List<Customer>>> GetAllCustomersDatas()
        {
            try
            {
                var customers = await customerDataService.GetAllCustomersDatas();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("customer/{id}/wallet")]
        public async Task<ActionResult<string>> GetCustomerWalletAddress(int id)
        {
            try
            {
                var walletAddress = await customerDataService.GetCustomerWalletAddress(id);
                if (walletAddress == null) return NotFound();
                return Ok(walletAddress);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("customer/{id}/orders")]
        public async Task<ActionResult<List<Order>>> GetAllCustomerOrders(int id)
        {
            try
            {
                var orders = await customerDataService.GetAllCustomerOrders(id);
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("customer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                await customerDataService.UpdateCustomer(customer);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                await customerDataService.DeleteCustomer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("customer")]
        public async Task<IActionResult> AddCustomer([FromBody] Customer customer)
        {
            try
            {
                await customerDataService.AddCustomer(customer);
                return CreatedAtAction(nameof(GetCustomerData), new { id = customer.Id }, customer);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // OrderDataService APIs
        [HttpGet("order/{id}")]
        public async Task<ActionResult<Order>> GetOrderData(int id)
        {
            try
            {
                var order = await orderDataService.GetOrderData(id);
                if (order == null) return NotFound();
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("orders")]
        public async Task<ActionResult<List<Order>>> GetAllOrders()
        {
            try
            {
                var orders = await orderDataService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("order")]
        public async Task<IActionResult> AddOrder([FromBody] Order order)
        {
            try
            {
                await orderDataService.AddOrder(order);
                return CreatedAtAction(nameof(GetOrderData), new { id = order.Id }, order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("order/{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            try
            {
                await orderDataService.DeleteOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromBody] Order order)
        {
            try
            {
                await orderDataService.UpdateOrder(order);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // OrderItemsDataService APIs
        [HttpGet("orderitem/{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
            try
            {
                var orderItem = await orderItemsDataService.GetOrderItem(id);
                if (orderItem == null) return NotFound();
                return Ok(orderItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("orderitems/{orderId}")]
        public async Task<ActionResult<List<OrderItem>>> GetAllOrderItem(int orderId)
        {
            try
            {
                var orderItems = await orderItemsDataService.GetAllOrderItem(orderId);
                return Ok(orderItems);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("orderitem")]
        public async Task<IActionResult> AddOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await orderItemsDataService.AddOrderItem(orderItem);
                return CreatedAtAction(nameof(GetOrderItem), new { id = orderItem.Id }, orderItem);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("orderitem/{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            try
            {
                await orderItemsDataService.DeleteOrderItem(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("orderitem")]
        public async Task<IActionResult> UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await orderItemsDataService.UpdateOrderItem(orderItem);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
