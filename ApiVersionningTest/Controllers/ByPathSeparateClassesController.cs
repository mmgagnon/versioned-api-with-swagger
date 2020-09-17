using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersionningTest.Controllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/weather/v{api-version:apiVersion}/ByPathSeparateClasses")]
	public class ByPathSeparateClassesV1Controller : ControllerBase
	{
		[HttpGet("read")]
		public WeatherResponse Get()
		{
			return new WeatherResponse() { Summary = "v1 by path, different controllers" };
		}
	}

	[ApiController]
	[ApiVersion("2.0")]
	[Route("api/weather/v{api-version:apiVersion}/ByPathSeparateClasses")]
	public class ByPathSeparateClassesV2Controller : ControllerBase
	{
		[HttpGet("read")]
		public WeatherResponse Get()
		{
			return new WeatherResponse() { Summary = "v2 by path, different controllers" };
		}
	}
}
