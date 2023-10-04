using Microsoft.AspNetCore.Mvc;
using Sample.Scrutor.Interfaces;

namespace Sample.Scrutor.Controllers;

[ApiController]
[Route("[controller]")]
public class Scrutor : ControllerBase
{
	private readonly IUserService _userService;
	private readonly IGroupService _groupService;

	public Scrutor(IUserService userService, IGroupService groupService)
	{
		_userService = userService;
		_groupService = groupService;
	}


	[HttpPost]
	public Task<IActionResult> CheckScrutor()
	{
		var okUser = _userService.ReturnOk();
		var okGroup = _groupService.ReturnOk();

		return Task.FromResult<IActionResult>(Ok());
	}
}