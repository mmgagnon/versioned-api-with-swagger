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
	[ApiVersion("2.0")]
	[Route("api/weather/v{api-version:apiVersion}/ByPathSameClass")]
	public class ByPathSameClassController : ControllerBase
	{
		[HttpGet("read"), MapToApiVersion("1.0")]
		public WeatherResponse GetV1()
		{
			return new WeatherResponse() { Summary = "v1 by path, different controllers" };
		}

		[HttpGet("read"), MapToApiVersion("2.0")]
		public WeatherResponse GetV2()
		{
			return new WeatherResponse() { Summary = "v2 by path, different controllers" };
		}
	}
}
