using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Common;
using Domain;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VR2Projekt.Models.AccountViewModels;
using VR2Projekt.Services;

namespace VR2Projekt.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccController : Controller
    {
       
    }
   

    }