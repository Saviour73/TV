using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TVApi.Model;
using TVApi.Repository;

// TVController.cs
[Route("api/[controller]")]
[ApiController]
public class TVController : ControllerBase
{
    private readonly IRepository<TV> _tvRepository;

    public TVController(IRepository<TV> tvRepository)
    {
        _tvRepository = tvRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TV>> Get()
    {
        var tvs = _tvRepository.GetAll();
        return Ok(tvs);
    }

    [HttpGet("{id}")]
    public ActionResult<TV> Get(int id)
    {
        var tv = _tvRepository.GetById(id);
        if (tv == null)
            return NotFound();
        return Ok(tv);
    }

    [HttpPost]
    public ActionResult Post([FromBody] TV tv)
    {
        _tvRepository.Add(tv);
        return Ok(tv.Id);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] TV tv)
    {
        var existingTV = _tvRepository.GetById(id);
        if (existingTV == null)
            return NotFound();

        existingTV.Brand = tv.Brand;
        existingTV.Model = tv.Model;
        existingTV.Price = tv.Price;

        _tvRepository.Update(existingTV);
        return NoContent();
    }



    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var tv = _tvRepository.GetById(id);
        if (tv == null)
            return NotFound();

        _tvRepository.Delete(tv);
        return NoContent();
    }


}
