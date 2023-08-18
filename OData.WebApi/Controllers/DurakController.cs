using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using OData.WebApi.Infrastructure.Context;

namespace OData.WebApi.Controllers;
[Route("api/[controller]")]
[ApiController]
//[EnableQuery]
public class DurakController : ControllerBase
{
    private DurakDbContext dbContext;

    public DurakController(DurakDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    [EnableQuery]
    public ActionResult GetStudents()
    {
        var result = dbContext.durak_liste.AsQueryable(); //AsQueryable ile bütün dataları getirmeden filtreleme gibi işlemleri yapılabilir.

        return Ok(result);
    }

    /*Örnek yapılabilecek endpointler
        * https://localhost:7180/api/Durak?select=id,durak_no
        * https://localhost:7180/api/Durak?filter=id eq 1
        * https://localhost:7180/api/Durak?orderby=id desc
    */


}
