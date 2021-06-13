using System;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
	[ApiController]
	[Route("api/[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ILogger _logger;

		public AccountController(
			UserManager<ApplicationUser> userManager,
			ILoggerFactory loggerFactory)
		{
			_userManager = userManager;
			_logger = loggerFactory.CreateLogger<AccountController>();
		}        //

		// POST: /Account/Register
		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterUser model, string returnUrl = null)
		{
			try
			{
				var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
				var result = await _userManager.CreateAsync(user, model.Password);
				if (result.Succeeded)
				{
					_logger.LogInformation(3, "User created a new account with password.");
				}
				return Ok(result);
			}
			catch (Exception Ex) {
				return BadRequest(Ex);
			}
		}
	}
}
